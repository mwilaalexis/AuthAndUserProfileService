using Microsoft.AspNetCore.Http;

namespace UserProject.Core.DTOs
{
    public class CreateProfileDto
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? BiologicalSex { get; set; }
        public decimal? WeightKg { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public decimal? HeightCm { get; set; }
        public string? ActivityLevel { get; set; }
        public string? Goal { get; set; }
        public string? Allergies { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int Age { get; set; }
        public string DietType { get; set; }
    }
}
