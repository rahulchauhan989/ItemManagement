using System.Linq.Expressions;
using AutoMapper;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Exception;
using ItemManagementSystem.Infrastructure.Interface;

namespace ItemManagementSystem.Application.Services;

    public class UserItemRequestService : IUserItemRequestService
    {
        private readonly IRepository<ItemRequest> _requestRepo;
        private readonly IRepository<ItemRequestDetail> _ItemRequestDetailRepo;
        private readonly IRepository<ItemModel> _itemModelRepo;
        private readonly IMapper _mapper;

        private readonly Dictionary<(int currentStatus, int newStatus), bool> _allowedTransitions = new()
        {
            { ((int)StatusEnum.Draft, (int)StatusEnum.Pending), true },
            { ((int)StatusEnum.Draft, (int)StatusEnum.Cancelled), true },
            { ((int)StatusEnum.Pending, (int)StatusEnum.Cancelled), true }
        };

        public UserItemRequestService(
            IRepository<ItemRequest> requestRepo,
            IRepository<ItemRequestDetail> ItemRequestDetailRepo,
            IRepository<ItemModel> itemModelRepo,
            IMapper mapper)
        {
            _requestRepo = requestRepo;
            _ItemRequestDetailRepo = ItemRequestDetailRepo;
            _itemModelRepo = itemModelRepo;
            _mapper = mapper;
        }

        public async Task<ItemRequestResponseDto> CreateRequestAsync(int userId, CreateItemRequestDto dto)
        {
            // Implement the method or throw NotImplementedException if not used
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<ItemRequestResponseDto>> GetRequestsByUserPagedAsync(int userId, ItemManagementSystem.Domain.Dto.ItemRequestFilterDto filter)
        {
            var filterProperties = new Dictionary<string, string?>();
            filterProperties.Add("UserId", userId.ToString());

            if (!string.IsNullOrEmpty(filter.RequestNumber))
            {
                filterProperties.Add("RequestNumber", filter.RequestNumber);
            }

            var parameter = Expression.Parameter(typeof(ItemRequest), "x");

            Expression userIdExpression = Expression.Equal(
                Expression.Property(parameter, nameof(ItemRequest.UserId)),
                Expression.Constant(userId)
            );

            Expression combinedExpression = userIdExpression;

            var lambda = Expression.Lambda<Func<ItemRequest, bool>>(combinedExpression, parameter);

            var pagedResult = await _requestRepo.GetPagedAsyncWithIncludes(
                lambda,
                q => q.OrderBy(r => r.CreatedAt),
                filter.Page,
                filter.PageSize,
                i => i.Status);

            var resultItems = new List<ItemRequestResponseDto>();
            foreach (var r in pagedResult.Items)
            {
                var items = await _ItemRequestDetailRepo.FindIncludingAsync(
                    i => i.ItemRequestId == r.Id && !i.IsDeleted,
                    new System.Linq.Expressions.Expression<Func<ItemRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

                resultItems.Add(new ItemRequestResponseDto
                {
                    Id = r.Id,
                    RequestNumber = r.RequestNumber!,
                    Status = r.Status?.Name ?? string.Empty,
                    CreatedAt = r.CreatedAt,
                    Items = items.Select(i => new ItemRequestDetailResponseDto
                    {
                        Quantity = i.Quantity,
                        ItemModelName = i.ItemModel?.Name,
                        ItemTypeName = i.ItemModel?.ItemType?.Name
                    }).ToList()
                });
            }

            return new PagedResultDto<ItemRequestResponseDto>
            {
                Items = resultItems,
                TotalCount = pagedResult.TotalCount,
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize
            };
        }

        private async Task<string> GenerateRequestNumberAsync()
        {
            var today = DateTime.UtcNow.Date;
            var allRequests = await _requestRepo.GetAllAsync();
            var todaysCount = allRequests.Count(r => r.CreatedAt.Date == today);
            var sequenceNumber = todaysCount + 1;
            var sequenceStr = sequenceNumber.ToString().PadLeft(3, '0');
            return $"REQ{today:yyyyMMdd}{sequenceStr}";
        }

    public async Task UpdateStatusAsync(int id, int statusId, string? comment, int userId)
    {
        var entity = await _requestRepo.GetByIdAsync(id);
        if (entity == null || entity.IsDeleted)
            throw new NullObjectException(AppMessages.ItemRequestNotFound);

        var validStatuses = await _requestRepo.FindAsync(s => s.StatusId == statusId);
        if (!validStatuses.Any())
            throw new CustomException($"Invalid status ID: {statusId}");

        if (entity.StatusId == statusId)
            throw new CustomException($"Request is already in the specified status.");

        var currentStatusId = entity.StatusId;
        var newStatusId = statusId;

        if (!_allowedTransitions.ContainsKey((currentStatusId, newStatusId)))
        {
            throw new CustomException($"Invalid status transition from {((StatusEnum)currentStatusId).ToString()} to {((StatusEnum)newStatusId).ToString()}");
        }

        entity.StatusId = statusId;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.ModifiedBy = userId;
        entity.Comment = comment;
        await _requestRepo.UpdateAsync(entity);
    }

    public bool IsValidStatusTransition(int currentStatusId, int newStatusId)
    {
        return _allowedTransitions.ContainsKey((currentStatusId, newStatusId));
    }

    public async Task<ItemRequestWithIdsResponseDto?> GetUserItemRequestByIdAsync(int id)
    {
        var entity = await _requestRepo.GetByIdAsync(id);
        if (entity == null || entity.IsDeleted)
            throw new NullObjectException(AppMessages.ItemRequestNotFound);
        var items = await _ItemRequestDetailRepo.FindIncludingAsync(
            i => i.ItemRequestId == entity.Id && !i.IsDeleted,
            new System.Linq.Expressions.Expression<Func<ItemRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

        var statusName = Enum.IsDefined(typeof(StatusEnum), entity.StatusId) ? ((StatusEnum)entity.StatusId).ToString() : string.Empty;

        var response = new ItemRequestWithIdsResponseDto
        {
            Id = entity.Id,
            RequestNumber = entity.RequestNumber,
            Status = statusName,
            CreatedAt = entity.CreatedAt,
            Items = items.Select(i => new ItemRequestDetailWithIdsResponseDto
            {
                ItemModelId = i.ItemModelId,
                ItemTypeId = i.ItemModel?.ItemTypeId ?? 0,
                ItemModelName = i.ItemModel?.Name,
                ItemTypeName = i.ItemModel?.ItemType?.Name,
                Quantity = i.Quantity
            }).ToList()
        };
        if (response == null || response.Items == null || !response.Items.Any())
            throw new NullObjectException(AppMessages.ItemRequestNotFound);

        return response;
    }

    public async Task<ItemRequestResponseDto> CreateRequestWithStatusAsync(int userId, CreateItemRequestWithStatusDto dto, StatusEnum status)
    {
        if (status != StatusEnum.Draft && status != StatusEnum.Pending)
        {
            throw new ArgumentException(AppMessages.AllowedStatuses);
        }

        var duplicateItemModelIds = dto.Items.GroupBy(i => i.ItemModelId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicateItemModelIds.Any())
        {
            throw new CustomException($"Duplicate ItemModelId(s) found in request: {string.Join(", ", duplicateItemModelIds)}");
        }

        foreach (var reqItem in dto.Items)
        {
            var item = await _itemModelRepo.GetByIdAsync(reqItem.ItemModelId);
            if (item == null || item.IsDeleted)
                throw new CustomException(AppMessages.ItemModelNotFound);
            if ((status == StatusEnum.Pending || status == StatusEnum.Draft) && reqItem.Quantity > item.Quantity)
                throw new CustomException($"Requested quantity for item {item.Name} exceeds available stock.");
        }

        var entity = _mapper.Map<ItemRequest>(dto);
        entity.UserId = userId;
        entity.RequestNumber = await GenerateRequestNumberAsync();
        entity.StatusId = (int)status;
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;

        await _requestRepo.AddAsync(entity);

        var itemRequestDetails = _mapper.Map<List<ItemRequestDetail>>(dto.Items);
        foreach (var itemRequestDetail in itemRequestDetails)
        {
            itemRequestDetail.ItemRequestId = entity.Id;
            itemRequestDetail.CreatedBy = userId;
            itemRequestDetail.CreatedAt = DateTime.UtcNow;
            await _ItemRequestDetailRepo.AddAsync(itemRequestDetail);
        }

        return new ItemRequestResponseDto
        {
            Id = entity.Id,
            RequestNumber = entity.RequestNumber,
            Status = status.ToString(),
            CreatedAt = entity.CreatedAt,
            Items = dto.Items.Select(item => new ItemRequestDetailResponseDto
            {
                Quantity = item.Quantity,
                ItemModelName = null,
                ItemTypeName = null
            }).ToList()
        };
    }

    public async Task ChangeStatusAsync(int requestId, int userId)
    {
        var entity = await _requestRepo.GetByIdAsync(requestId);
        if (entity == null || entity.IsDeleted)
            throw new NullObjectException(AppMessages.ItemRequestNotFound);

        if (entity.UserId != userId)
            throw new CustomException(AppMessages.cannotEditOtherRequest);

        if (entity.Status?.Name == StatusEnum.Draft.ToString())
        {
            entity.StatusId = (await _requestRepo.FindAsync(s => s.Status.Name == StatusEnum.Pending.ToString())).FirstOrDefault()?.Id ?? 0;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.ModifiedBy = userId;
            await _requestRepo.UpdateAsync(entity);
        }
        else if (entity.Status?.Name == StatusEnum.Pending.ToString())
        {
            entity.StatusId = (await _requestRepo.FindAsync(s => s.Status.Name == StatusEnum.Cancelled.ToString())).FirstOrDefault()?.Id ?? 0;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.ModifiedBy = userId;
            await _requestRepo.UpdateAsync(entity);
        }
        else
        {
            throw new CustomException("Only requests with status Draft or Pending can be changed or cancelled.");
        }
    }

    public async Task ChangeDraftToPendingAsync(int requestId, int userId)
    {
        var entity = await _requestRepo.GetByIdAsync(requestId);
        if (entity == null || entity.IsDeleted)
            throw new NullObjectException(AppMessages.ItemRequestNotFound);

        if (entity.UserId != userId)
            throw new CustomException(AppMessages.cannotEditOtherRequest);

        if (entity.Status?.Name != StatusEnum.Draft.ToString())
            throw new CustomException(AppMessages.OnlyDraftChangeToPending);

        entity.StatusId = (await _requestRepo.FindAsync(s => s.Status.Name == StatusEnum.Pending.ToString())).FirstOrDefault()?.Id ?? 0;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.ModifiedBy = userId;
        await _requestRepo.UpdateAsync(entity);
    }
}
