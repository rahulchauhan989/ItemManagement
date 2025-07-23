namespace ItemManagementSystem.Domain.Dto.Return
{
    public class UpdateReturnRequestStatusDto
    {
        public string Status { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
