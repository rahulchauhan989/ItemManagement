namespace ItemManagementSystem.Domain.Dto.Request
{
    public class ItemRequestFilterDto
    {
        public string? RequestNumber { get; set; }
        public string? Status { get; set; }
        // public string? UserName { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
