using System.Collections.Generic;
using ItemManagementSystem.Domain.Constants;

namespace ItemManagementSystem.Domain.Dto.Return
{
    public class EditReturnRequestWithStatusDto
    {
        public List<ReturnRequestItemDto> Items { get; set; } = new List<ReturnRequestItemDto>();
        public StatusEnum Status { get; set; }
    }

    public class ReturnRequestItemDto
    {
        public int ItemModelId { get; set; }
        public int Quantity { get; set; }
    }
}
