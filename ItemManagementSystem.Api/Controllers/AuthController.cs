using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailSender _emailSender;

        public AuthController(IAuthService authService, IEmailSender emailSender)
        {
            _authService = authService;
            _emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto.Email, dto.Password);

            var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            Response.Cookies.Append("jwt_token", token, cookieOptions);

            return new ApiResponse(true, 200, token, AppMessages.LoginSuccess);
        }

        [HttpPost("logout")]
        public ActionResult<ApiResponse> Logout()
        {
            if (Request.Cookies.ContainsKey("jwt_token"))
            {
                Response.Cookies.Delete("jwt_token");
            }
            return new ApiResponse(true, 200, null, AppMessages.logout);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<ApiResponse>> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var token = _authService.GenerateJwtToken(dto.Email);

            string resetLink = Url.Action("ResetPassword", "Auth", new { token = Uri.EscapeDataString(token) }, Request.Scheme)!;

            string emailBody = $"Click <a href='{resetLink}'>here</a> to reset your password.";
            if (!await _authService.isEmailExist(dto.Email))
            {
                return new ApiResponse(false, 404, null, AppMessages.EmailNotFound);
            }

            await _emailSender.SendEmailAsync(dto.Email, "Reset Password", emailBody);

            return new ApiResponse(true, 200, null, AppMessages.ResetLinkSent);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ApiResponse>> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            await _authService.ResetPasswordAsync(dto.Token, dto.NewPassword);

            return new ApiResponse(true, 200, null, AppMessages.PasswordResetSuccess);
        }
    }
}