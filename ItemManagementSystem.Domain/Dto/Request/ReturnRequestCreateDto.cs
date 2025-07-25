namespace ItemManagementSystem.Domain.Dto.Request;

using ItemManagementSystem.Domain.Dto.Request;

public class ReturnRequestCreateDto
{
    public List<CreateReturnRequestDetailDto> Items { get; set; } = new();
}

public class ReturnRequestDetailDto
{
    public int ItemModelId { get; set; }
    public string? ItemModelName { get; set; }
    public int ItemTypeId { get; set; }
    public string? ItemTypeName { get; set; }
    public int Quantity { get; set; }
}

public class ReturnRequestFilterDto
{
    public string? Status { get; set; }
    public string? ReturnRequestNumber { get; set; }
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; } = "desc";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? UserName { get; set; }

}

public class ReturnRequestDto
{
    public int Id { get; set; }
    public string ReturnRequestNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public List<ReturnRequestDetailDto> Items { get; set; } = new();
}