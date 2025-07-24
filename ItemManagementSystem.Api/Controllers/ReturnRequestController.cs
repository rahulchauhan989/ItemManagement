using ItemManagementSystem.Api.Helpers;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Dto.Return;
using ItemManagementSystem.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagementSystem.Api.Controllers;

[ApiController]
[Route("api/return-request")]
public class ReturnRequestController : ControllerBase
{
    private readonly IReturnRequestService _returnRequestService;
    private readonly IUserReturnRequestService _userReturnRequestService;
    private readonly IItemTypeService _itemTypeService;
    private readonly IRepository<Status> _statusRepo;

    public ReturnRequestController(IReturnRequestService returnRequestService, IUserReturnRequestService userReturnRequestService, IItemTypeService itemTypeService, IRepository<ItemManagementSystem.Domain.DataModels.Status> statusRepo)
    {
        _itemTypeService = itemTypeService;
        _returnRequestService = returnRequestService;
        _userReturnRequestService = userReturnRequestService;
        _statusRepo = statusRepo;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> CreateOrSaveReturnRequest([FromBody] ReturnRequestCreateWithStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var statusEntity = (await _statusRepo.FindAsync(s => s.Name == dto.Status.Trim())).FirstOrDefault();
        if (statusEntity == null)
        {
            return BadRequest(new ApiResponse(false, 400, null, $"Invalid status: {dto.Status}"));
        }
        int statusId = statusEntity.Id;
        var result = await _returnRequestService.CreateReturnRequestWithStatusAsync(userId, dto, statusId);
        string message = dto.Status == "Draft" ? AppMessages.ReturnRequestDraftSaved : AppMessages.ReturnRequestCreated;
        int statusCode = dto.Status == "Draft" ? StatusCodes.Status200OK : StatusCodes.Status201Created;
        return new ApiResponse(true, statusCode, null, message);
    }

    [HttpPost("my-requests")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> GetUserReturnRequestsPost([FromBody] ReturnRequestFilterDto filter)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var result = await _returnRequestService.GetUserReturnRequestsAsync(userId, filter);
        return new ApiResponse(true, StatusCodes.Status200OK, result, AppMessages.GetMyReturnRequests);
    }

    [HttpPut("status-update/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> UpdateStatus(int id, [FromBody] UpdateReturnRequestStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var statusEntity = (await _statusRepo.FindAsync(s => s.Name == dto.Status.Trim())).FirstOrDefault();
        if (statusEntity == null)
        {
            return BadRequest(new ApiResponse(false, StatusCodes.Status400BadRequest, null, $"Invalid status: {dto.Status}"));
        }
        int statusId = statusEntity.Id;
        await _userReturnRequestService.UpdateUserReturnRequestStatusAsync(id, userId, dto.Status.ToString());
        return new ApiResponse(true, StatusCodes.Status200OK, null, $"Return request status updated to {dto.Status}");
    }

    [HttpPut("edit/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> EditReturnRequest(int id, [FromBody] EditReturnRequestWithStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        await _returnRequestService.EditReturnRequestWithStatusAsync(id, userId, dto);
        return new ApiResponse(true, StatusCodes.Status204NoContent, null, AppMessages.ReturnRequestUpdated);
    }

}
