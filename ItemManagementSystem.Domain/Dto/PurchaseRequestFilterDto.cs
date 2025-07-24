namespace ItemManagementSystem.Domain.Dto
{
    public class PurchaseRequestFilterDto
    {
        public string? InvoiceNumber { get; set; }
        public string? UserName { get; set; }
        public string? SortBy { get; set; } = "Date";
        public string? SortDirection { get; set; } = "desc";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
