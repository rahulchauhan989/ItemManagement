using ItemManagementSystem.Api.Helpers;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
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
    private readonly IItemTypeService _itemTypeService;
    private readonly IRepository<ItemManagementSystem.Domain.DataModels.Status> _statusRepo;

    public ReturnRequestController(IReturnRequestService returnRequestService, IItemTypeService itemTypeService, IRepository<ItemManagementSystem.Domain.DataModels.Status> statusRepo)
    {
        _itemTypeService = itemTypeService;
        _returnRequestService = returnRequestService;
        _statusRepo = statusRepo;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> CreateOrSaveReturnRequest([FromBody] ReturnRequestCreateWithStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var statusEntity = (await _statusRepo.FindAsync(s => s.Name == dto.Status)).FirstOrDefault();
        if (statusEntity == null)
        {
            return BadRequest(new ApiResponse(false, 400, null, $"Invalid status: {dto.Status}"));
        }
        int statusId = statusEntity.Id;
        var result = await _returnRequestService.CreateReturnRequestWithStatusAsync(userId, dto, statusId);
        string message = dto.Status == "Draft" ? AppMessages.ReturnRequestDraftSaved : AppMessages.ReturnRequestCreated;
        int statusCode = dto.Status == "Draft" ? 200 : 201;
        return new ApiResponse(true, statusCode, result, message);
    }

    [HttpPost("my-requests")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> GetUserReturnRequestsPost([FromBody] ReturnRequestFilterDto filter)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var result = await _returnRequestService.GetUserReturnRequestsAsync(userId, filter);
        return new ApiResponse(true, 200, result, AppMessages.GetMyReturnRequests);
    }

    // [HttpPost("all-request")]
    // [Authorize(Roles = "Admin")]
    // public async Task<ActionResult<ApiResponse>> GetAllReturnRequestsPost([FromBody] ReturnRequestFilterDto filter)
    // {
    //     var result = await _returnRequestService.GetAllReturnRequestsAsync(filter);
    //     return new ApiResponse(true, 200, result, AppMessages.GetAllReturnRequests);
    // }

    [HttpPut("status-update/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> UpdateStatus(int id, [FromBody] UpdateReturnRequestStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var statusEntity = (await _statusRepo.FindAsync(s => s.Name == dto.Status)).FirstOrDefault();
        if (statusEntity == null)
        {
            return BadRequest(new ApiResponse(false, 400, null, $"Invalid status: {dto.Status}"));
        }
        int statusId = statusEntity.Id;
        await _returnRequestService.UpdateReturnRequestStatusAsync(id, statusId, dto.Comment, userId);
        return new ApiResponse(true, 200, null, $"Return request status updated to {dto.Status}");
    }

    [HttpPut("edit/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> EditReturnRequest(int id, [FromBody] ItemManagementSystem.Domain.Dto.Return.EditReturnRequestWithStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        await _returnRequestService.EditReturnRequestWithStatusAsync(id, userId, dto);
        return new ApiResponse(true, 204, null, AppMessages.ReturnRequestUpdated);
    }

}
