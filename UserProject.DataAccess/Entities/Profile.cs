using System.ComponentModel.DataAnnotations;

namespace UserProject.DataAccess.Entities
{
    public class Profile
    {
        [Key]
        public Guid UserId { get; set; }         
        public string? FullName { get; set; }  = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }=string.Empty;
        public string? BiologicalSex { get; set; } = string.Empty;
        public decimal? WeightKg { get; set; } = 0;
        public decimal? HeightCm { get; set; } = 0;    
        public string? ActivityLevel { get; set; }  = string.Empty;
        public string? Goal { get; set; } = string.Empty;         
        public string? Allergies { get; set; }  = string.Empty; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public User User { get;  set; }
        public int Age { get;  set; }
        public string DietType { get;  set; } = string.Empty;
    }
}