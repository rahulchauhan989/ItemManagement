using System.Threading.Tasks;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Dto.Return;

namespace ItemManagementSystem.Application.Interface
{
    public interface IReturnRequestService
    {
        Task<ReturnRequestDto> CreateReturnRequestWithStatusAsync(int userId, ReturnRequestCreateWithStatusDto dto, int statusId);
        Task<ReturnRequestDto> CreateReturnRequestAsync(int userId, ReturnRequestCreateDto dto);
        Task<PagedResultDto<ReturnRequestResponseDto>> GetUserReturnRequestsAsync(int userId, ReturnRequestFilterDto filter);
        Task UpdateReturnRequestStatusAsync(int id, int statusId, string? comment, int userId);
        Task<PagedResultDto<ReturnRequestResponseDto>> GetAllReturnRequestsAsync(ReturnRequestFilterDto filter);
        Task EditReturnRequestAsync(int id, int userId, ReturnRequestCreateDto dto);
        Task EditReturnRequestWithStatusAsync(int id, int userId, EditReturnRequestWithStatusDto dto);
        Task<ReturnRequestResponseDto?> GetReturnRequestByIdAsync(int id);
        Task CancelReturnRequestAsync(int id, int userId);
        Task SaveDraftAsync(int userId, ReturnRequestCreateDto dto);
        Task ChangeDraftToPendingAsync(int id, int userId);
    }
}
