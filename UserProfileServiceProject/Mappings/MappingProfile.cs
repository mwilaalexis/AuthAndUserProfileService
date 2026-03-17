using UserProfileServiceProject.DTOs;
using UserProfileServiceProject.Entities;

namespace UserProfileServiceProject.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Entities.Profile, ProfileDto>()
                .ForMember(dest => dest.Bmi, opt => opt.MapFrom(src =>
                    src.HeightCm.HasValue && src.WeightKg.HasValue && src.HeightCm.Value > 0
                        ? Math.Round(src.WeightKg.Value / (src.HeightCm.Value / 100m * src.HeightCm.Value / 100m), 1)
                        : (decimal?)null))
                .ForMember(dest => dest.Allergies,
                    opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Allergies)
                        ? new List<string>()
                        : src.Allergies.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()));

           
            CreateMap<ProfileUpdateDto, Entities.Profile>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateProfileDto, Profile>()
      .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
      .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
      .ForMember(dest => dest.Allergies,
          opt => opt.MapFrom(src => src.Allergies != null ? string.Join(",", src.Allergies) : null));


            CreateMap<ProfileUpdateDto, Entities.Profile>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Allergies,
                    opt => opt.MapFrom(src => src.Allergies != null ? string.Join(",", src.Allergies) : null));
        }
    }
}