namespace ItemManagementSystem.Domain.Dto.Request
{
    public class UpdateStatusRequestDto
    {
        public string Status { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
