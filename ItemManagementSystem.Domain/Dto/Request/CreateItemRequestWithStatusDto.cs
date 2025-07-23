using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto.Request
{
    public class CreateItemRequestWithStatusDto
    {
        [Required]
        public string Status { get; set; } = null!; // "Draft" or "Pending"

        [Required]
        public List<CreateItemRequestDetailDto> Items { get; set; } = new List<CreateItemRequestDetailDto>();
    }

    // Removed duplicate CreateItemRequestDetailDto class as it already exists in the namespace
}
