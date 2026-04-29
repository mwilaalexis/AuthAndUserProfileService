using UserProject.Core.DTOs;

namespace UserProject.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddAccountAsync(ProfileDto profileDto);
        Task<UserDto> DeleteAccountAsync(Guid Id);
        Task<UserDto> DeleteUserAccountAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllUsers(int page, int pageSize);
        Task<UserDto> UpdateAccountAsync(ProfileDto profileDto);
        Task<UserDto> PromoteUserAccountAsync(string role, Guid userId);
    }
}