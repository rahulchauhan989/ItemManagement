using ItemManagementSystem.Api.Helpers;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/item-requests")]
    [Authorize(Roles = "Admin")]
    public class NetworkAdminItemRequestController : ControllerBase
    {
        private readonly IItemRequestService _itemRequestService;
        private readonly IItemTypeService _itemTypeService;

        public NetworkAdminItemRequestController(IItemRequestService itemRequestService, IItemTypeService itemTypeService)
        {
            _itemRequestService = itemRequestService;
            _itemTypeService = itemTypeService;
        }

        [HttpPost("requests")]
        public async Task<ActionResult<ApiResponse>> GetItemRequestsPost([FromBody] ItemsRequestFilterDto filter)
        {
            var result = await _itemRequestService.GetRequestsAsync(filter);
            return new ApiResponse(true, StatusCodes.Status200OK, result, AppMessages.ItemItemRequestDetailsRetrieved);
        }

        [HttpPost("status/{id}")] 
        public async Task<ActionResult<ApiResponse>> ChangeItemRequestStatus(int id, [FromBody] ChangeStatusDto dto)
        {
            int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
            if (!Enum.TryParse<StatusEnum>(dto.Status, true, out var statusEnum))
            {
                return BadRequest(new ApiResponse(false, StatusCodes.Status400BadRequest, null, $"Invalid status: {dto.Status}"));
            }
            int statusId = (int)statusEnum;
            await _itemRequestService.ChangeRequestStatusAsync(id, statusId, dto.Comment, userId);
            return new ApiResponse(true, StatusCodes.Status200OK, null, $"Request status changed to {dto.Status}");
        }
    }
}