using UserProfileServiceProject.DTOs;

namespace UserProfileServiceProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task RegisterAsync(RegisterDto dto);
    }
}