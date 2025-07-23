
namespace ItemManagementSystem.Domain.Dto;

using ItemManagementSystem.Domain.Dto.Request;

public class CreateItemRequestDto
{
    public List<CreateItemRequestDetailDto> Items { get; set; } = new List<CreateItemRequestDetailDto>();
}
