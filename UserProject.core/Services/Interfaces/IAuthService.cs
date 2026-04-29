using UserProject.Core.DTOs;

namespace UserProject.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest dto);
        Task<LoginResponse> RefreshTokenAsync(string refreshToken);
        Task RegisterAsync(RegisterDto dto);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}