using UserProfileServiceProject.DTOs;

namespace UserProfileServiceProject.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDto> CreateProfileAsync(CreateProfileDto dto);
        Task DeleteProfileAsync(Guid userId);
        Task<ProfileDto> GetProfile(Guid userId);
        Task<ProfileDto> UpdateProfileAsync(Guid userId, ProfileDto dto);
    }
}