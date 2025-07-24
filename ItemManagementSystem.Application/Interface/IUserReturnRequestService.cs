using System.Threading.Tasks;
using ItemManagementSystem.Domain.Dto.Return;

namespace ItemManagementSystem.Application.Interface
{
    public interface IUserReturnRequestService
    {
        Task UpdateUserReturnRequestStatusAsync(int id, int userId, string newStatus);
    }
}
