using System.Threading.Tasks;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;

namespace ItemManagementSystem.Application.Interface
{
    public interface IUserItemRequestService
    {
        Task ChangeDraftToPendingAsync(int requestId, int userId);
        Task<ItemRequestWithIdsResponseDto?> GetUserItemRequestByIdAsync(int id);
        Task UpdateStatusAsync(int id, int statusId, string? comment, int userId);
        Task<ItemRequestResponseDto> CreateRequestWithStatusAsync(int userId, CreateItemRequestWithStatusDto dto, Domain.Constants.StatusEnum status);
        Task<ItemRequestResponseDto> CreateRequestAsync(int userId, CreateItemRequestDto dto);
        Task<PagedResultDto<ItemRequestResponseDto>> GetRequestsByUserPagedAsync(int userId, Domain.Dto.ItemRequestFilterDto filter);
        bool IsValidStatusTransition(int currentStatusId, int newStatusId);
    }
}
