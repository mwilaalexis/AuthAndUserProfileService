using Microsoft.AspNetCore.Http;

namespace UserProject.Core.DTOs
{
    public class UpdateProfileDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? BiologicalSex { get; set; }
        public double? WeightKg { get; set; }
        public double? HeightCm { get; set; }
        public string? ActivityLevel { get; set; }
        public string? Goal { get; set; }
        public string? Allergies { get; set; }
        public string? DietType { get; set; }

        public IFormFile? ProfileImage { get; set; }
    }

}
