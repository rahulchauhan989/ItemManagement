using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto.Request
{
    public class UpdateStatusRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
