using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto.Return;
using ItemManagementSystem.Domain.Exception;
using ItemManagementSystem.Infrastructure.Interface;

namespace ItemManagementSystem.Application.Implementation
{
    public class UserReturnRequestService : IUserReturnRequestService
    {
        private readonly IRepository<ReturnRequest> _returnRequestRepo;
        private readonly IRepository<Status> _statusRepo;

        public UserReturnRequestService(
            IRepository<ReturnRequest> returnRequestRepo,
            IRepository<Status> statusRepo)
        {
            _returnRequestRepo = returnRequestRepo;
            _statusRepo = statusRepo;
        }

        public async Task UpdateUserReturnRequestStatusAsync(int id, int userId, string newStatus)
        {
            var request = await _returnRequestRepo.GetByIdAsync(id);
            if (request == null || request.IsDeleted)
                throw new NullObjectException(AppMessages.ReturnRequestNotFound);

            if (request.UserId != userId)
                throw new CustomException(AppMessages.cannotEditOtherRequest);

            var statusEntity = (await _statusRepo.FindAsync(s => s.Name == newStatus)).FirstOrDefault();
            if (statusEntity == null)
                throw new CustomException($"Invalid status: {newStatus}");

            int newStatusId = statusEntity.Id;

            var allowedTransitions = new Dictionary<int, List<int>>
            {
                { (int)StatusEnum.Draft, new List<int> { (int)StatusEnum.Pending, (int)StatusEnum.Cancelled } },
                { (int)StatusEnum.Pending, new List<int> { (int)StatusEnum.Cancelled } }
            };

            if (!allowedTransitions.TryGetValue(request.StatusId, out var allowedNewStatuses) || !allowedNewStatuses.Contains(newStatusId))
            {
                throw new CustomException($"Invalid status transition from {((StatusEnum)request.StatusId).ToString()} to {newStatus}");
            }

            request.StatusId = newStatusId;
            request.UpdatedAt = DateTime.UtcNow;
            request.ModifiedBy = userId;

            await _returnRequestRepo.UpdateAsync(request);
        }
    }
}
