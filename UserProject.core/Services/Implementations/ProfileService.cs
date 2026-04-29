using AutoMapper;
using UserProject.Core.DTOs;
using UserProject.Core.Services.Interfaces;
using UserProject.DataAccess.Repositories.Interfaces;
using Profile = UserProject.DataAccess.Entities.Profile;

namespace UserProject.Core.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            this.mapper = mapper;
        }

        public async Task DeleteProfileAsync(Guid userId)
        {
            var profile = await _profileRepository.GetByProfileIdAsync(userId) ?? throw new Exception("this profile doesn't exist");
            await _profileRepository.DeleteAsync(profile);
        }

        public async Task<ProfileDto> CreateProfileAsync(CreateProfileDto dto)
        {
            var existing = await _profileRepository.GetByProfileIdAsync(dto.UserId);
            if (existing != null)
                throw new Exception("Profile already exists");

            var profile = mapper.Map<Profile>(dto);
            profile.UserId = dto.UserId;


            if (dto.ProfileImage != null)
            {
                var fileName = $"{Guid.NewGuid()}_{dto.ProfileImage.FileName}";
                var filePath = Path.Combine("wwwroot/profile-images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ProfileImage.CopyToAsync(stream);
                }

                profile.ProfileUrl = $"https://localhost:7004/profile-images/{fileName}";
            }

            await _profileRepository.CreateAsync(profile);

            return mapper.Map<ProfileDto>(profile);
        }


        public async Task<ProfileDto> GetProfile(Guid userId)
        {
            var profile = await _profileRepository.GetByProfileIdAsync(userId);
            if (profile == null || profile.Goal == null)
                throw new InvalidOperationException("Profile not found");

            return mapper.Map<ProfileDto>(profile);
        }
        public async Task<UserProfileSummary> GetProfileSummary(Guid userId)
        {
            var profile = await _profileRepository.GetByProfileIdAsync(userId);

            if (profile == null || profile.Goal == null)
                throw new InvalidOperationException("Profile not found");

            return mapper.Map<UserProfileSummary>(profile);
        }

        public async Task<ProfileDto> UpdateProfileAsync(Guid userId, UpdateProfileDto dto)
        {
            var profile = await _profileRepository.GetByProfileIdAsync(userId);

            if (profile == null)
            {
                profile = mapper.Map<Profile>(dto);
                profile.UserId = userId;
                profile.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                mapper.Map(dto, profile);
                profile.UpdatedAt = DateTime.UtcNow;
            }


            if (dto.ProfileImage != null)
            {
                var fileName = $"{Guid.NewGuid()}_{dto.ProfileImage.FileName}";
                var filePath = Path.Combine("wwwroot/profile-images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ProfileImage.CopyToAsync(stream);
                }

                profile.ProfileUrl = $"https://localhost:7004/profile-images/{fileName}";
            }

            await _profileRepository.SaveChangesAsync();

            return mapper.Map<ProfileDto>(profile);
        }


    }
}
