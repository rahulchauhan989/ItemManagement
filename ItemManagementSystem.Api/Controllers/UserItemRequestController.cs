using System.Net;
using ItemManagementSystem.Api.Helpers;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagementSystem.Api.Controllers;

[ApiController]
[Route("api/user-item-requests")]
public class UserItemRequestController : ControllerBase
{
    private readonly IUserItemRequestService _UserItemReqService;
    private readonly IItemTypeService _itemTypeService;
    private readonly IRepository<Status> _statusRepo;

    private readonly IItemRequestService _itemRequestService;

    public UserItemRequestController(IUserItemRequestService service, IItemTypeService itemTypeService, IItemRequestService itemRequestService, IRepository<Status> statusRepo)
    {
        _itemTypeService = itemTypeService;
        _UserItemReqService = service;
        _itemRequestService = itemRequestService;
        _statusRepo = statusRepo;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> CreateOrSaveUserItemRequest([FromBody] CreateItemRequestWithStatusDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        if (!Enum.TryParse<StatusEnum>(dto.Status, true, out var statusEnum))
        {
            return BadRequest(new ApiResponse(false, StatusCodes.Status400BadRequest, null,AppMessages.InvalidStatus));
        }
        await _UserItemReqService.CreateRequestWithStatusAsync(userId, dto, statusEnum);
        string message = statusEnum == StatusEnum.Draft ? AppMessages.ItemSavedAsDraft : AppMessages.UserCreatedItemReq;
        int statusCode = statusEnum == StatusEnum.Draft ? StatusCodes.Status200OK : StatusCodes.Status201Created;
        return new ApiResponse(true, statusCode, null, message);
    }

    [HttpPost("my-request")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> GetMyItemRequestsPost([FromBody] ItemManagementSystem.Domain.Dto.ItemRequestFilterDto filter)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var pagedList = await _UserItemReqService.GetRequestsByUserPagedAsync(userId, filter);
        return new ApiResponse(true, StatusCodes.Status200OK, pagedList, AppMessages.GetMyRequests);
    }


    [HttpPut("status-update/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> UpdateStatus(int id, [FromBody] ItemManagementSystem.Domain.Dto.Request.UpdateStatusRequestDto dto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        var statusEntity = (await _statusRepo.FindAsync(s => s.Name == dto.Status)).FirstOrDefault();
        if (statusEntity == null)
        {
            return BadRequest(new ApiResponse(false, StatusCodes.Status400BadRequest, null, $"Invalid status: {dto.Status}"));
        }
        int statusId = statusEntity.Id;
        await _UserItemReqService.UpdateStatusAsync(id, statusId, dto.Comment, userId);
        return new ApiResponse(true, StatusCodes.Status200OK, null, $"Item request status updated to {dto.Status}");
    }

    [HttpPut("edit/{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ApiResponse>> EditItemRequest(int id, [FromBody] ItemRequestEditDto editDto)
    {
        int userId = UserHelper.GetUserIdFromRequest(Request, _itemTypeService);
        await _itemRequestService.EditItemRequestAsync(id, editDto, userId);
        return new ApiResponse(true,(int) HttpStatusCode.OK, null, AppMessages.ItemRequestUpdated);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse>> GetUserItemRequestById(int id)
    {
        var result = await _UserItemReqService.GetUserItemRequestByIdAsync(id);
        return new ApiResponse(true, StatusCodes.Status200OK, result, AppMessages.GetRequestDetails);
    }
}
