using System.Linq.Expressions;
using AutoMapper;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataContext;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemRequestResponseDto = ItemManagementSystem.Domain.Dto.Request.ItemRequestResponseDto;
using ItemRequestDetailResponseDto = ItemManagementSystem.Domain.Dto.Request.ItemRequestDetailResponseDto;
using ItemManagementSystem.Domain.Exception;
using ItemManagementSystem.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace ItemManagementSystem.Application.Implementation
{
    public class ItemRequestService : IItemRequestService
    {
        private readonly IRepository<ItemRequest> _itemRequestRepo;
        private readonly IRepository<Status> _statusRepo;
        private readonly IRepository<ItemRequestDetail> _ItemRequestDetailRepo;
        private readonly IRepository<ItemModel> _itemModelRepo;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepo;
        private readonly IUserItemRequestService _userItemRequestService;

        private readonly Dictionary<(int currentStatus, int newStatus), bool> _allowedTransitions = new()
        {
            { ((int)StatusEnum.Pending, (int)StatusEnum.Approved), true },
            { ((int)StatusEnum.Pending, (int)StatusEnum.Rejected), true }
        };

        public ItemRequestService(
            IRepository<ItemRequest> itemRequestRepo,
            IRepository<ItemRequestDetail> ItemRequestDetailRepo,
            IRepository<ItemModel> itemModelRepo,
            IMapper mapper,
            IRepository<User> userRepo,
            IUserItemRequestService userItemRequestService,
            IRepository<Status> statusRepo)
        {
            _itemRequestRepo = itemRequestRepo;
            _ItemRequestDetailRepo = ItemRequestDetailRepo;
            _itemModelRepo = itemModelRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _userItemRequestService = userItemRequestService;
            _statusRepo = statusRepo;
        }
        public async Task<PagedResultDto<ItemRequestResponseDto>> GetRequestsAsync(ItemsRequestFilterDto filter)
        {
            var filterProperties = new Dictionary<string, string?>();
            if (!string.IsNullOrEmpty(filter.RequestNumber))
            {
                filterProperties.Add("RequestNumber", filter.RequestNumber);
            }
            if (!string.IsNullOrEmpty(filter.UserName))
            {
                filterProperties.Add("User.Name", filter.UserName);
            }

            var paged = await _itemRequestRepo.GetPagedWithMultipleFiltersAndSortAsync(
                filterProperties,
                filter.SortBy,
                filter.SortDirection,
                filter.Page,
                filter.PageSize);

            paged.Items = paged.Items.Where(i => i.StatusId != (int)StatusEnum.Draft).ToList();

            var result = new List<ItemRequestResponseDto>();

            foreach (var entity in paged.Items)
            {
                var items = await _ItemRequestDetailRepo.FindIncludingAsync(
                    i => i.ItemRequestId == entity.Id && !i.IsDeleted,
                    new System.Linq.Expressions.Expression<Func<ItemRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

                var itemDtos = items.Select(i => new ItemRequestDetailResponseDto
                {
                    Quantity = i.Quantity,
                    ItemModelName = i.ItemModel?.Name,
                    ItemTypeName = i.ItemModel?.ItemType?.Name
                }).ToList();

                var user = (await _userRepo.FindAsync(u => u.Id == entity.UserId && u.Active)).FirstOrDefault();
                if (user == null)
                    throw new NullObjectException(AppMessages.UserNotFound);

                result.Add(new ItemRequestResponseDto
                {
                    Id = entity.Id,
                    RequestNumber = entity.RequestNumber!,
                    Status = Enum.IsDefined(typeof(StatusEnum), entity.StatusId) ? ((StatusEnum)entity.StatusId).ToString() : string.Empty,
                    CreatedAt = entity.CreatedAt,
                    Items = itemDtos
                });
            }

            return new PagedResultDto<ItemRequestResponseDto>
            {
                Items = result,
                TotalCount = paged.TotalCount,
                Page = paged.Page,
                PageSize = paged.PageSize
            };
        }


        public async Task ChangeRequestStatusAsync(int id, int statusId, string? comment, int userId)
        {
            var request = await _itemRequestRepo.GetByIdAsync(id);
            if (request == null)
                throw new NullObjectException(AppMessages.ItemRequestNotFound);

            var validStatuses = await _statusRepo.FindAsync(s => s.Id == statusId);
            if (!validStatuses.Any())
                throw new CustomException($"Invalid status ID: {statusId}");

            if (request.StatusId == statusId)
                throw new CustomException($"Request is already in the specified status.");

            var currentStatusId = request.StatusId;
            var newStatusId = statusId;

            if (!_allowedTransitions.ContainsKey((currentStatusId, newStatusId)))
            {
                throw new CustomException($"Invalid status transition from {((StatusEnum)currentStatusId).ToString()} to {((StatusEnum)newStatusId).ToString()}");
            }

            if (newStatusId == (int)StatusEnum.Approved)
            {
                var ItemRequestDetails = await _ItemRequestDetailRepo.FindAsync(x => x.ItemRequestId == id && !x.IsDeleted);

                foreach (var item in ItemRequestDetails)
                {
                    var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
                    if (itemModel == null)
                        throw new NullObjectException($"ItemModel with ID {item.ItemModelId} not found.");
                    if (itemModel.Quantity < item.Quantity)
                        throw new CustomException($"Not enough quantity for item: {itemModel.Name}");

                    itemModel.Quantity -= item.Quantity;
                    await _itemModelRepo.UpdateAsync(itemModel);
                }
            }

            request.StatusId = statusId;
            request.UpdatedAt = DateTime.UtcNow;
            request.ModifiedBy = userId;
            request.Comment = comment;
            await _itemRequestRepo.UpdateAsync(request);
        }
        public async Task EditItemRequestAsync(int requestId, ItemRequestEditDto editDto, int userId)
        {
            var request = await _itemRequestRepo.GetByIdAsync(requestId);
            if (request == null)
                throw new NullObjectException(AppMessages.ItemRequestNotFound);

            if (request.UserId != userId)
                throw new CustomException(AppMessages.cannotEditOtherRequest);

            if (request.StatusId != (int)StatusEnum.Draft && request.StatusId != (int)StatusEnum.Pending)
            {
                throw new CustomException(AppMessages.OnlyPendingReqEditable);
            }

            // Validate duplicate itemModelId in editDto.Items
            var duplicateItemModelIds = editDto.Items.GroupBy(i => i.ItemModelId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateItemModelIds.Any())
            {
                throw new CustomException($"Duplicate ItemModelId(s) found in request: {string.Join(", ", duplicateItemModelIds)}");
            }

            // Validate and update status if provided and different
            if (!string.IsNullOrEmpty(editDto.Status))
            {
                if (!Enum.TryParse<StatusEnum>(editDto.Status, true, out var statusEnum))
                {
                    throw new CustomException($"Invalid status: {editDto.Status}");
                }
                int newStatusId = (int)statusEnum;

                if (newStatusId != request.StatusId)
                {
                    var currentStatusId = request.StatusId;
                    if (!_userItemRequestService.IsValidStatusTransition(currentStatusId, newStatusId))
                    {
                        throw new CustomException($"Invalid status transition from {((StatusEnum)currentStatusId).ToString()} to {editDto.Status}");
                    }

                    await _userItemRequestService.UpdateStatusAsync(requestId, newStatusId, null, userId);
                }
            }

            var existingItems = await _ItemRequestDetailRepo.FindAsync(i => i.ItemRequestId == requestId && !i.IsDeleted);
            var existingItemsDict = existingItems.ToDictionary(i => i.ItemModelId);

            var editItemModelIds = editDto.Items.Select(i => i.ItemModelId).ToHashSet();
            foreach (var existingItem in existingItems)
            {
                if (!editItemModelIds.Contains(existingItem.ItemModelId))
                {
                    existingItem.IsDeleted = true;
                    await _ItemRequestDetailRepo.UpdateAsync(existingItem);
                }
            }

            foreach (var itemEdit in editDto.Items)
            {
                if (itemEdit.Quantity > 0)
                {
                    var item = await _itemModelRepo.GetByIdAsync(itemEdit.ItemModelId);
                    if (item == null || item.IsDeleted)
                        throw new CustomException(AppMessages.ItemModelNotFound);
                    if (itemEdit.Quantity > item.Quantity)
                        throw new CustomException($"Requested quantity for item {item.Name} exceeds available stock.{item.Quantity}");

                    if (existingItemsDict.TryGetValue(itemEdit.ItemModelId, out var existingItem))
                    {
                        existingItem.Quantity = itemEdit.Quantity;
                        existingItem.IsDeleted = false; // Unmark deleted if previously deleted
                        await _ItemRequestDetailRepo.UpdateAsync(existingItem);
                    }
                    else
                    {
                        var newItem = new ItemRequestDetail
                        {
                            ItemRequestId = requestId,
                            ItemModelId = itemEdit.ItemModelId,
                            Quantity = itemEdit.Quantity,
                            CreatedBy = userId,
                            IsDeleted = false
                        };
                        await _ItemRequestDetailRepo.AddAsync(newItem);
                    }
                }
                else if (itemEdit.Quantity == 0)
                {
                    if (existingItemsDict.TryGetValue(itemEdit.ItemModelId, out var existingItem))
                    {
                        existingItem.IsDeleted = true;
                        await _ItemRequestDetailRepo.UpdateAsync(existingItem);
                    }
                }
            }
            request.UpdatedAt = DateTime.UtcNow;
            request.ModifiedBy = userId;
            await _itemRequestRepo.UpdateAsync(request);
        }
    }
}
