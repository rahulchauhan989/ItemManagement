namespace ItemManagementSystem.Domain.Dto.Request;

public class ItemRequestResponseDto
{
    public int Id { get; set; }
    public string? RequestNumber { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public List<ItemRequestDetailResponseDto> Items { get; set; } = new List<ItemRequestDetailResponseDto>();
    public int StatusId { get; set; }
    public string? UserName { get; set; }
}
