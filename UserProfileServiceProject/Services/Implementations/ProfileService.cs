using AutoMapper;
using UserProfileServiceProject.DTOs;
using UserProfileServiceProject.Entities;
using UserProfileServiceProject.Repositories.Interfaces;
using UserProfileServiceProject.Services.Interfaces;

namespace UserProfileServiceProject.Services.Implementations
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
            var profile = await _profileRepository.GetByUserIdAsync(userId) ?? throw new Exception("this profile doesn't exist");
            await _profileRepository.DeleteAsync(profile);
        }
        public async Task<ProfileDto> CreateProfileAsync(CreateProfileDto dto)
        {
            var profile = mapper.Map<Entities.Profile>(dto);
            profile.UserId = dto.UserId;
            var ExistingProfile = await _profileRepository.GetByUserIdAsync(dto.UserId);
            if (ExistingProfile == null)
            {
                await _profileRepository.CreateAsync(profile);

                return mapper.Map<ProfileDto>(profile);
            }
            throw new Exception("Alredy Exist");
        }

        public async Task<ProfileDto> GetProfile(Guid userId)
        {
            var  profile = await _profileRepository.GetByUserIdAsync(userId);
            if (profile == null || profile.Goal == null)
                throw new InvalidOperationException("Profile not found");

            return mapper.Map<ProfileDto>(profile);
        }

        public async Task<ProfileDto> UpdateProfileAsync(Guid userId, ProfileDto dto)
        {
            var profile = await _profileRepository.GetByUserIdAsync(userId);

            profile.WeightKg = dto.WeightKg;
            profile.HeightCm = dto.HeightCm;
            profile.DietType = dto.DietType;
            profile.Goal = dto.Goal;

            await _profileRepository.UpdateAsync(profile);
            await _profileRepository.SaveChangesAsync();

            return mapper.Map<ProfileDto>(profile);
        }
    }
}
