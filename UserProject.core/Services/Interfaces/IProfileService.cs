using UserProject.Core.DTOs;

namespace UserProject.Core.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDto> CreateProfileAsync(CreateProfileDto dto);
        Task DeleteProfileAsync(Guid userId);
        Task<ProfileDto> GetProfile(Guid userId);
        Task<UserProfileSummary> GetProfileSummary(Guid userId);
        Task<ProfileDto> UpdateProfileAsync(Guid userId, UpdateProfileDto dto);
    }
}