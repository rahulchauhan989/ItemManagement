using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto.Request;

public class PurchaseRequestCreateDto
{    public List<PurchaseRequestDetailCreateDto> Items { get; set; } = null!;
}

public class PurchaseRequestDetailCreateDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ItemModelId must be greater than 0.")]
    public int ItemModelId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public int Quantity { get; set; }
}