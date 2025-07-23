using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto.Request
{
    public class ReturnRequestCreateWithStatusDto
    {
        [Required]
        public string Status { get; set; } = null!; // "Draft" or "Pending"

        [Required]
        public List<ReturnRequestDetailInputDto> Items { get; set; } = new List<ReturnRequestDetailInputDto>();
    }

    public class ReturnRequestDetailInputDto
    {
        [Required]
        public int ItemModelId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

}
