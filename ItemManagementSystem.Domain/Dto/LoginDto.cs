using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.Dto;

public class LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
