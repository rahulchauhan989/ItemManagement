using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;

namespace ItemManagementSystem.Application.Interface;

public interface IItemRequestService
{
    Task<PagedResultDto<ItemManagementSystem.Domain.Dto.Request.ItemRequestResponseDto>> GetRequestsAsync(ItemsRequestFilterDto filter);
    Task ChangeRequestStatusAsync(int id, int statusId, string? comment, int userId);
    Task EditItemRequestAsync(int requestId, ItemRequestEditDto editDto, int userId);
}
