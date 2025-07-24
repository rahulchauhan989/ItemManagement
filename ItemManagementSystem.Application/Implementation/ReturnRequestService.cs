using System.Linq.Expressions;
using AutoMapper;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Dto.Return;
using ItemManagementSystem.Domain.Exception;
using ItemManagementSystem.Infrastructure.Interface;

namespace ItemManagementSystem.Application.Implementation;

public class ReturnRequestService : IReturnRequestService
{
    private readonly IRepository<ReturnRequest> _returnRequestRepo;
    private readonly IRepository<ReturnRequestDetail> _ReturnRequestDetailRepo;
    private readonly IRepository<ItemModel> _itemModelRepo;
    private readonly IRepository<Status> _statusRepo;
    private readonly IRepository<ItemRequestDetail> _ItemRequestDetailRepo;
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepo;

    public ReturnRequestService(
        IRepository<ReturnRequest> returnRequestRepo,
        IRepository<ReturnRequestDetail> ReturnRequestDetailRepo,
        IRepository<ItemModel> itemModelRepo,
        IRepository<ItemRequest> itemRequestRepo,
        IRepository<ItemRequestDetail> ItemRequestDetailRepo,
        IMapper mapper,
        IRepository<User> userRepo,
        IRepository<Status> statusRepo)
    {
        _returnRequestRepo = returnRequestRepo;
        _ReturnRequestDetailRepo = ReturnRequestDetailRepo;
        _itemModelRepo = itemModelRepo;
        _ItemRequestDetailRepo = ItemRequestDetailRepo;
        _mapper = mapper;
        _userRepo = userRepo;
        _statusRepo = statusRepo;
    }

    public async Task<ReturnRequestResponseDto?> GetReturnRequestByIdAsync(int id)
    {
        var entity = await _returnRequestRepo.GetByIdAsync(id);
        if (entity == null || entity.IsDeleted)
            return null;
        int userId = entity.CreatedBy;
        var user = await _userRepo.GetByIdAsync(userId);
        string userName = user!.Name;

        var items = await _ReturnRequestDetailRepo.FindIncludingAsync(
            i => i.ReturnRequestId == entity.Id && !i.IsDeleted,
            new Expression<Func<ReturnRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

        var itemDtos = items.Select(i => new ReturnRequestDetailResponseDto
        {
            Quantity = i.Quantity,
            ItemModelName = i.ItemModel?.Name,
            ItemTypeName = i.ItemModel?.ItemType?.Name
        }).ToList();

        string statusName = string.Empty;
        if (entity.StatusId != 0)
        {
            var status = await _statusRepo.GetByIdAsync(entity.StatusId);
            if (status != null)
            {
                statusName = status.Name;
            }
        }

        return new ReturnRequestResponseDto
        {
            Id = entity.Id,
            ReturnRequestNumber = entity.ReturnRequestNumber!,
            Status = statusName,
            CreatedAt = entity.CreatedAt,
            Items = itemDtos,
            UserName = userName
        };
    }

    public async Task EditReturnRequestWithStatusAsync(int id, int userId, ItemManagementSystem.Domain.Dto.Return.EditReturnRequestWithStatusDto dto)
    {
        var request = await _returnRequestRepo.GetByIdAsync(id);
        if (request == null || request.IsDeleted)
            throw new NullObjectException(AppMessages.ReturnRequestNotFound);

        if (request.UserId != userId)
            throw new CustomException(AppMessages.cannotEditOtherRequest);

        // Validate duplicate ItemModelId in dto.Items
        var duplicateItemModelIds = dto.Items.GroupBy(i => i.ItemModelId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicateItemModelIds.Any())
        {
            throw new CustomException($"Duplicate ItemModelId(s) found in request: {string.Join(", ", duplicateItemModelIds)}");
        }

        // Validate allowed status transitions if status changed
        if (request.StatusId != (int)dto.Status)
        {
            var allowedTransitions = new Dictionary<int, List<int>>
            {
                { (int)StatusEnum.Draft, new List<int> { (int)StatusEnum.Pending, (int)StatusEnum.Cancelled } },
                { (int)StatusEnum.Pending, new List<int> { (int)StatusEnum.Cancelled } }
            };

            if (!allowedTransitions.TryGetValue(request.StatusId, out var allowedNewStatuses) || !allowedNewStatuses.Contains((int)dto.Status))
            {
                throw new CustomException($"Invalid status transition from {((StatusEnum)request.StatusId).ToString()} to {dto.Status.ToString()}");
            }
        }

        foreach (var item in dto.Items)
        {
            var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
            if (itemModel == null || itemModel.IsDeleted)
            {
                throw new CustomException($"ItemModel with ID {item.ItemModelId} not found or deleted.");
            }
        }

        var approvedUserRequests = await _ItemRequestDetailRepo.FindAsync(ri =>
            ri.CreatedBy == userId && !ri.IsDeleted && ri.ItemRequest.StatusId == (int)StatusEnum.Approved);

        var itemAvailability = approvedUserRequests
            .GroupBy(i => i.ItemModelId)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

        foreach (var item in dto.Items)
        {
            if (!itemAvailability.ContainsKey(item.ItemModelId) || item.Quantity > itemAvailability.GetValueOrDefault(item.ItemModelId, 0))
                throw new CustomException($"User doesn't own enough of item ID: {item.ItemModelId}");
        }

        var existingItems = await _ReturnRequestDetailRepo.FindAsync(i => i.ReturnRequestId == id && !i.IsDeleted);

        var existingItemsDict = existingItems.ToDictionary(i => i.ItemModelId);

        var dtoItemModelIds = dto.Items.Select(i => i.ItemModelId).ToHashSet();
        foreach (var existingItem in existingItems)
        {
            if (!dtoItemModelIds.Contains(existingItem.ItemModelId))
            {
                await _ReturnRequestDetailRepo.DeleteAsync(existingItem);
            }
        }

        foreach (var item in dto.Items)
        {
            if (existingItemsDict.TryGetValue(item.ItemModelId, out var existingItem))
            {
                existingItem.Quantity = item.Quantity;
                await _ReturnRequestDetailRepo.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = new ReturnRequestDetail
                {
                    ReturnRequestId = id,
                    ItemModelId = item.ItemModelId,
                    Quantity = item.Quantity,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow
                };
                await _ReturnRequestDetailRepo.AddAsync(newItem);
            }
        }

        if (request.StatusId != (int)dto.Status)
        {
            request.StatusId = (int)dto.Status;
        }

        request.UpdatedAt = DateTime.UtcNow;
        request.ModifiedBy = userId;
        await _returnRequestRepo.UpdateAsync(request);
    }

    public async Task<ReturnRequestDto> CreateReturnRequestWithStatusAsync(int userId, ReturnRequestCreateWithStatusDto dto, int statusId)
    {
        var statusEntity = await _statusRepo.FindAsync(s => s.Id == statusId);
        if (!statusEntity.Any())
        {
            throw new CustomException("Invalid status ID.");
        }

        if (dto.Items == null || !dto.Items.Any())
            throw new CustomException(AppMessages.InvalidReturnItems);

        // Check for duplicate ItemModelId in dto.Items
        var duplicateItemModelIds = dto.Items.GroupBy(i => i.ItemModelId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicateItemModelIds.Any())
        {
            throw new CustomException($"Duplicate ItemModelId(s) found in request: {string.Join(", ", duplicateItemModelIds)}");
        }

        foreach (var item in dto.Items)
        {
            var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
            if (itemModel == null || itemModel.IsDeleted)
            {
                throw new CustomException($"ItemModel with ID {item.ItemModelId} not found or deleted.");
            }
        }

        // For Pending or Draft status, check if user owns enough items using StatusEnum
        var statusEnum = (StatusEnum)statusId;
        if (statusEnum == StatusEnum.Pending || statusEnum == StatusEnum.Draft)
        {
            var approvedUserRequests = await _ItemRequestDetailRepo.FindAsync(ri =>
                ri.CreatedBy == userId && !ri.IsDeleted && ri.ItemRequest.StatusId == (int)StatusEnum.Approved);

            var itemAvailability = approvedUserRequests
                .GroupBy(i => i.ItemModelId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

            foreach (var item in dto.Items)
            {
                if (!itemAvailability.ContainsKey(item.ItemModelId) || item.Quantity > itemAvailability.GetValueOrDefault(item.ItemModelId, 0))
                    throw new CustomException($"User doesn't own enough of item ID: {item.ItemModelId} Available quantity: {itemAvailability.GetValueOrDefault(item.ItemModelId, 0)}");
            }
        }

        var returnEntity = new ReturnRequest
        {
            UserId = userId,
            ReturnRequestNumber = await GenerateReturnRequestNumberAsync(),
            StatusId = statusId,
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _returnRequestRepo.AddAsync(returnEntity);

        foreach (var item in dto.Items)
        {
            var entityItem = new ReturnRequestDetail
            {
                ReturnRequestId = returnEntity.Id,
                ItemModelId = item.ItemModelId,
                Quantity = item.Quantity,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _ReturnRequestDetailRepo.AddAsync(entityItem);
        }

        return new ReturnRequestDto
        {
            Id = returnEntity.Id,
            ReturnRequestNumber = returnEntity.ReturnRequestNumber,
            Status = statusEnum.ToString(),
            CreatedAt = returnEntity.CreatedAt,
            Items = dto.Items.Select(i => new ReturnRequestDetailDto
            {
                ItemModelId = i.ItemModelId,
                ItemModelName = string.Empty,
                ItemTypeId = 0,
                ItemTypeName = string.Empty,
                Quantity = i.Quantity
            }).ToList()
        };
    }

    private async Task<string> GenerateReturnRequestNumberAsync()
    {
        var today = DateTime.UtcNow.Date;
        var allRequests = await _returnRequestRepo.GetAllAsync();
        var todaysCount = allRequests.Count(r => r.CreatedAt.Date == today);
        var sequenceNumber = todaysCount + 1;
        var sequenceStr = sequenceNumber.ToString().PadLeft(3, '0');
        return $"RR{today:yyyyMMdd}{sequenceStr}";
    }

    public async Task<ReturnRequestDto> CreateReturnRequestAsync(int userId, ReturnRequestCreateDto dto)
    {
        if (dto.Items == null || !dto.Items.Any())
            throw new CustomException(AppMessages.InvalidReturnItems);

        foreach (var item in dto.Items)
        {
            var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
            if (itemModel == null || itemModel.IsDeleted)
            {
                throw new CustomException($"ItemModel with ID {item.ItemModelId} not found or deleted.");
            }
        }

        var approvedUserRequests = await _ItemRequestDetailRepo.FindAsync(ri =>
            ri.CreatedBy == userId && !ri.IsDeleted && ri.ItemRequest.StatusId == (int)StatusEnum.Approved);

        var itemAvailability = approvedUserRequests
            .GroupBy(i => i.ItemModelId)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

        foreach (var item in dto.Items)
        {
            if (!itemAvailability.ContainsKey(item.ItemModelId) || item.Quantity > itemAvailability.GetValueOrDefault(item.ItemModelId, 0))
                throw new CustomException($"User doesn't own enough of item ID: {item.ItemModelId} Available quantity: {itemAvailability.GetValueOrDefault(item.ItemModelId, 0)}");
        }

        var returnEntity = new ReturnRequest
        {
            UserId = userId,
            ReturnRequestNumber = await GenerateReturnRequestNumberAsync(),
            StatusId = (await _returnRequestRepo.FindAsync(s => s.StatusId == (int)StatusEnum.Pending)).FirstOrDefault()?.StatusId ?? 0,
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _returnRequestRepo.AddAsync(returnEntity);

        foreach (var item in dto.Items)
        {
            var entityItem = new ReturnRequestDetail
            {
                ReturnRequestId = returnEntity.Id,
                ItemModelId = item.ItemModelId,
                Quantity = item.Quantity,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _ReturnRequestDetailRepo.AddAsync(entityItem);
        }

        return new ReturnRequestDto
        {
            Id = returnEntity.Id,
            ReturnRequestNumber = returnEntity.ReturnRequestNumber,
            Status = StatusEnum.Pending.ToString(),
            CreatedAt = returnEntity.CreatedAt,
            Items = dto.Items.Select(i => new ReturnRequestDetailDto
            {
                ItemModelId = i.ItemModelId,
                ItemModelName = string.Empty,
                ItemTypeId = 0,
                ItemTypeName = string.Empty,
                Quantity = i.Quantity
            }).ToList()
        };
    }

    public async Task<PagedResultDto<ReturnRequestResponseDto>> GetUserReturnRequestsAsync(int userId, ReturnRequestFilterDto filter)
    {
        var filterProperties = new Dictionary<string, string?>();
        filterProperties.Add("UserId", userId.ToString());
        if (!string.IsNullOrEmpty(filter.Status))
        {
            var statusEntity = (await _statusRepo.FindAsync(s => s.Name == filter.Status)).FirstOrDefault();
            if (statusEntity == null)
            {
                throw new CustomException($"Invalid status filter: {filter.Status}");
            }
            filterProperties.Add("StatusId", statusEntity.Id.ToString());
        }
        if (!string.IsNullOrEmpty(filter.ReturnRequestNumber))
        {
            filterProperties.Add("ReturnRequestNumber", filter.ReturnRequestNumber);
        }

        var paged = await _returnRequestRepo.GetPagedWithMultipleFiltersAndSortAsync(
            filterProperties,
            filter.SortBy,
            filter.SortDirection,
            filter.Page,
            filter.PageSize);

        var result = new List<ReturnRequestResponseDto>();

        foreach (var entity in paged.Items)
        {
            var items = await _ReturnRequestDetailRepo.FindIncludingAsync(
                i => i.ReturnRequestId == entity.Id && !i.IsDeleted,
                new Expression<Func<ReturnRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

            var itemDtos = items.Select(i => new ReturnRequestDetailResponseDto
            {
                Quantity = i.Quantity,
                ItemModelName = i.ItemModel?.Name,
                ItemTypeName = i.ItemModel?.ItemType?.Name
            }).ToList();

            string statusName = string.Empty;
            if (entity.StatusId != 0)
            {
                var status = await _statusRepo.GetByIdAsync(entity.StatusId);
                if (status != null)
                {
                    statusName = status.Name;
                }
            }

            result.Add(new ReturnRequestResponseDto
            {
                Id = entity.Id,
                ReturnRequestNumber = entity.ReturnRequestNumber!,
                Status = statusName,
                CreatedAt = entity.CreatedAt,
                Items = itemDtos
            });
        }

        return new PagedResultDto<ReturnRequestResponseDto>
        {
            Items = result,
            TotalCount = paged.TotalCount,
            Page = paged.Page,
            PageSize = paged.PageSize
        };
    }

    public async Task UpdateReturnRequestStatusAsync(int id, int statusId, string? comment, int userId)
    {
        var request = await _returnRequestRepo.GetByIdAsync(id);
        if (request == null || request.IsDeleted)
            throw new NullObjectException(AppMessages.ReturnRequestNotFound);

        if (request.StatusId == statusId)
            throw new CustomException(AppMessages.AlreadyInSameStatus);

        var validStatuses = await _statusRepo.FindAsync(s => s.Id == statusId);
        if (!validStatuses.Any())
            throw new CustomException(AppMessages.InvalidRequest);

        var allowedTransitions = new Dictionary<int, List<int>>
        {
            { (int)StatusEnum.Pending, new List<int> { (int)StatusEnum.Rejected, (int)StatusEnum.Approved } }
        };

        if (!allowedTransitions.TryGetValue(request.StatusId, out var allowedNewStatuses) || !allowedNewStatuses.Contains(statusId))
        {
            throw new CustomException($"Invalid status transition from {((StatusEnum)request.StatusId).ToString()} to {((StatusEnum)statusId).ToString()}");
        }

        request.StatusId = statusId;
        request.UpdatedAt = DateTime.UtcNow;
        request.ModifiedBy = userId;

        if (statusId == (int)StatusEnum.Approved)
        {
            var returnRequestDetails = await _ReturnRequestDetailRepo.FindAsync(i => i.ReturnRequestId == id && !i.IsDeleted);
            foreach (var detail in returnRequestDetails)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(detail.ItemModelId);
                if (itemModel != null)
                {
                    itemModel.Quantity += detail.Quantity;
                    await _itemModelRepo.UpdateAsync(itemModel);
                }
            }
        }

        await _returnRequestRepo.UpdateAsync(request);
    }

    public async Task EditReturnRequestAsync(int id, int userId, ReturnRequestCreateDto dto)
    {
        var request = await _returnRequestRepo.GetByIdAsync(id);
        if (request == null || request.IsDeleted)
            throw new NullObjectException(AppMessages.ReturnRequestNotFound);

        if (request.UserId != userId)
            throw new CustomException(AppMessages.cannotEditOtherRequest);

        if (request.StatusId == (int)StatusEnum.Pending || request.StatusId == (int)StatusEnum.Draft)
        {
            foreach (var item in dto.Items)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
                if (itemModel == null || itemModel.IsDeleted)
                {
                    throw new CustomException($"ItemModel with ID {item.ItemModelId} not found or deleted.");
                }
            }

            var approvedUserRequests = await _ItemRequestDetailRepo.FindAsync(ri =>
                ri.CreatedBy == userId && !ri.IsDeleted && ri.ItemRequest.StatusId == (int)StatusEnum.Approved);

            var itemAvailability = approvedUserRequests
                .GroupBy(i => i.ItemModelId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

            foreach (var item in dto.Items)
            {
                if (!itemAvailability.ContainsKey(item.ItemModelId) || item.Quantity > itemAvailability.GetValueOrDefault(item.ItemModelId, 0))
                    throw new CustomException($"User doesn't own enough of item ID: {item.ItemModelId}");
            }

            var existingItems = await _ReturnRequestDetailRepo.FindAsync(i => i.ReturnRequestId == id && !i.IsDeleted);

            var existingItemsDict = existingItems.ToDictionary(i => i.ItemModelId);

            var dtoItemModelIds = dto.Items.Select(i => i.ItemModelId).ToHashSet();
            foreach (var existingItem in existingItems)
            {
                if (!dtoItemModelIds.Contains(existingItem.ItemModelId))
                {
                    await _ReturnRequestDetailRepo.DeleteAsync(existingItem);
                }
            }

            foreach (var item in dto.Items)
            {
                if (existingItemsDict.TryGetValue(item.ItemModelId, out var existingItem))
                {
                    existingItem.Quantity = item.Quantity;
                    await _ReturnRequestDetailRepo.UpdateAsync(existingItem);
                }
                else
                {
                    var newItem = new ReturnRequestDetail
                    {
                        ReturnRequestId = id,
                        ItemModelId = item.ItemModelId,
                        Quantity = item.Quantity,
                        IsDeleted = false,
                        CreatedBy = userId,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _ReturnRequestDetailRepo.AddAsync(newItem);
                }
            }
            request.UpdatedAt = DateTime.UtcNow;
            request.ModifiedBy = userId;
            await _returnRequestRepo.UpdateAsync(request);
        }
        else
        {
            throw new CustomException(AppMessages.OnlyPendingReqEditable);
        }
    }

    public async Task SaveDraftAsync(int userId, ReturnRequestCreateDto dto)
    {
        var returnEntity = new ReturnRequest
        {
            UserId = userId,
            ReturnRequestNumber = await GenerateReturnRequestNumberAsync(),
            StatusId = (await _returnRequestRepo.FindAsync(s => s.StatusId == (int)StatusEnum.Draft)).FirstOrDefault()?.StatusId ?? 0,
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _returnRequestRepo.AddAsync(returnEntity);

        foreach (var item in dto.Items)
        {
            var entityItem = new ReturnRequestDetail
            {
                ReturnRequestId = returnEntity.Id,
                ItemModelId = item.ItemModelId,
                Quantity = item.Quantity,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _ReturnRequestDetailRepo.AddAsync(entityItem);
        }
    }

    public async Task ChangeDraftToPendingAsync(int id, int userId)
    {
        var request = await _returnRequestRepo.GetByIdAsync(id);
        if (request == null || request.IsDeleted)
            throw new NullObjectException(AppMessages.ReturnRequestNotFound);

        if (request.UserId != userId)
            throw new CustomException(AppMessages.cannotEditOtherRequest);

        if (request.StatusId != (int)StatusEnum.Draft)
            throw new CustomException(AppMessages.OnlyDraftChangeToPending);

        var pendingStatusId = (await _returnRequestRepo.FindAsync(s => s.StatusId == (int)StatusEnum.Pending)).FirstOrDefault()?.StatusId ?? 0;

        request.StatusId = pendingStatusId;
        request.UpdatedAt = DateTime.UtcNow;
        request.ModifiedBy = userId;
        await _returnRequestRepo.UpdateAsync(request);
    }

    public async Task<PagedResultDto<ReturnRequestResponseDto>> GetAllReturnRequestsAsync(ReturnRequestFilterDto filter)
    {
        var filterProperties = new Dictionary<string, string?>();
        if (!string.IsNullOrEmpty(filter.Status))
        {
            var statusEntity = (await _statusRepo.FindAsync(s => s.Name == filter.Status)).FirstOrDefault();
            if (statusEntity == null)
            {
                throw new CustomException($"Invalid status filter: {filter.Status}");
            }
            filterProperties.Add("StatusId", statusEntity.Id.ToString());
        }
        if (!string.IsNullOrEmpty(filter.UserName))
        {
            filterProperties.Add("User.Name", filter.UserName);
        }
        if (!string.IsNullOrEmpty(filter.ReturnRequestNumber))
        {
            filterProperties.Add("ReturnRequestNumber", filter.ReturnRequestNumber);
        }

        var paged = await _returnRequestRepo.GetPagedWithMultipleFiltersAndSortAsync(
            filterProperties,
            filter.SortBy,
            filter.SortDirection,
            filter.Page,
            filter.PageSize);

        var result = new List<ReturnRequestResponseDto>();

        foreach (var entity in paged.Items)
        {
            var items = await _ReturnRequestDetailRepo.FindIncludingAsync(
                i => i.ReturnRequestId == entity.Id && !i.IsDeleted,
                new System.Linq.Expressions.Expression<Func<ReturnRequestDetail, object>>[] { i => i.ItemModel, i => i.ItemModel.ItemType });

            var itemDtos = items.Select(i => new ReturnRequestDetailResponseDto
            {
                Quantity = i.Quantity,
                ItemModelName = i.ItemModel?.Name,
                ItemTypeName = i.ItemModel?.ItemType?.Name
            }).ToList();

            var statusName = string.Empty;
            if (entity.StatusId != 0)
            {
                var status = await _statusRepo.GetByIdAsync(entity.StatusId);
                if (status != null)
                {
                    statusName = status.Name;
                }
            }

            var userName = string.Empty;
            var user = (await _userRepo.FindAsync(u => u.Id == entity.UserId && u.Active)).FirstOrDefault();
            if (user != null)
            {
                userName = user.Name;
            }

            result.Add(new ReturnRequestResponseDto
            {
                Id = entity.Id,
                ReturnRequestNumber = entity.ReturnRequestNumber!,
                Status = statusName,
                CreatedAt = entity.CreatedAt,
                Items = itemDtos,
                UserName = userName
            });
        }

        return new PagedResultDto<ReturnRequestResponseDto>
        {
            Items = result,
            TotalCount = paged.TotalCount,
            Page = paged.Page,
            PageSize = paged.PageSize
        };
    }

    public async Task CancelReturnRequestAsync(int id, int userId)
    {
        var request = await _returnRequestRepo.GetByIdAsync(id);
        if (request == null || request.IsDeleted)
            throw new NullObjectException(AppMessages.ReturnRequestNotFound);

        if (request.UserId != userId)
            throw new CustomException(AppMessages.cannotCancelOtherRequest);

        if (request.StatusId != (int)StatusEnum.Pending)
            throw new CustomException(AppMessages.OnlyPendingReqCancelable);

        request.StatusId = (await _returnRequestRepo.FindAsync(s => s.StatusId == (int)StatusEnum.Cancelled)).FirstOrDefault()?.StatusId ?? 0;
        request.UpdatedAt = DateTime.UtcNow;
        request.ModifiedBy = userId;
        await _returnRequestRepo.UpdateAsync(request);
    }
}
