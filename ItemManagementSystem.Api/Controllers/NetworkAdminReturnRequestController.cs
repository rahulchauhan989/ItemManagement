using System.Net;
using ItemManagementSystem.Api.Helpers;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Dto.Return;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/admin-return-requests")]
    [Authorize(Roles = "Admin")]
    public class NetworkAdminReturnRequestController : ControllerBase
    {
        private readonly IReturnRequestService _returnRequestService;
        private readonly IItemTypeService _itemTypeService;

        public NetworkAdminReturnRequestController(IReturnRequestService returnRequestService, 
                                                   IItemTypeService itemTypeService)
        {
            _returnRequestService = returnRequestService;
            _itemTypeService = itemTypeService;
        }

        [HttpPost("list")]
        public async Task<ActionResult<ApiResponse>> GetAllReturnRequests([FromBody] ReturnRequestFilterDto dto)
        {
            var result = await _returnRequestService.GetAllReturnRequestsAsync(dto);
            return new ApiResponse(true, StatusCodes.Status200OK, result, AppMessages.GetAllReturnRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetReturnRequestById(int id)
        {
            var result = await _returnRequestService.GetReturnRequestByIdAsync(id);
            if (result == null)
                return NotFound(new ApiResponse(false, 404, null, AppMessages.ReturnRequestNotFound));
            return new ApiResponse(true, StatusCodes.Status200OK, result, AppMessages.GetRequestDetails);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateReturnRequestStatus(int id, [FromBody] UpdateReturnRequestStatusDto dto)
        {
            int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
            int statusId = (int)Enum.Parse(typeof(StatusEnum), dto.Status.ToString());
            await _returnRequestService.UpdateReturnRequestStatusAsync(id, statusId, dto.Comment, userId);
            return new ApiResponse(true, StatusCodes.Status200OK, null, AppMessages.ReturnRequestStatusUpdated);
        }
    }
}
