using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto.Request
{
    public class CreateItemRequestDetailDto
    {
        [Required]
        public int ItemModelId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}
