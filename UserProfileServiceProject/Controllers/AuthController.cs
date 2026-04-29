using Microsoft.AspNetCore.Mvc;
using UserProject.Core.DTOs;
using UserProject.Core.Services.Interfaces;

namespace UserProfileServiceProject.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok(new { message = "Registration successful." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest dto)
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.RefreshToken))
                return BadRequest(new { message = "Refresh token is required.." });

            try
            {
                var response = await _authService.RefreshTokenAsync(request.RefreshToken);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.RefreshToken))
                return BadRequest(new { message = "A refresh token is required." });

            await _authService.RevokeRefreshTokenAsync(request.RefreshToken);
            return Ok(new { message = "Successfully logged out." });
        }
    }
}