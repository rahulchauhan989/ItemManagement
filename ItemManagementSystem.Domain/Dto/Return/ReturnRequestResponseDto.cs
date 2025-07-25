namespace ItemManagementSystem.Domain.Dto.Return;

public class ReturnRequestResponseDto
{
    public int Id { get; set; }
    public string? ReturnRequestNumber { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public List<ReturnRequestDetailResponseDto> Items { get; set; } = new List<ReturnRequestDetailResponseDto>();
    public string? UserName { get; set; }
}

public class ReturnRequestDetailResponseDto
{
    public string? ItemModelName { get; set; }
    public int Quantity { get; set; }
    public string? ItemTypeName { get; set; }
}
