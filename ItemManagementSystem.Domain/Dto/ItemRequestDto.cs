using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto

{
    public class ItemRequestDto
    {
        public int Id { get; set; }
        public string? RequestNumber { get; set; }
        public string? UserName { get; set; }
        public int UserId { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ItemRequestDetailDto>? Items { get; set; }
        public string? Comment { get; set; }
    }

    public class ItemRequestDetailDto
    {
        [Required]
        public int ItemModelId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
        public int? ItemTypeId { get; set; }
        public string? ItemTypeName { get; set; }
        public string? ItemModelName { get; set; }
    }

    public class ItemsRequestDto
    {
        [Required]
        public int ItemModelId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}
