namespace UserProject.Core.DTOs
{
    public record ProfileDto
    {
        public Guid UserId { get; set; }
        public int Age { get; set; }
        public string? FullName { get; set; }
        public string? ProfileUrl { get; set; } = string.Empty;
        public string? Role { get; set; } = "user";
        public string? Email { get; set; }
        public string? BiologicalSex { get; set; }
        public decimal? WeightKg { get; set; }
        public decimal? HeightCm { get; set; }
        public decimal? Bmi { get; set; }       
        public string? ActivityLevel { get; set; }
        public string? Goal { get; set; }
        public List<string> Allergies { get; set; }  
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set  ; }
        public string DietType { get;  set; }
    }
}