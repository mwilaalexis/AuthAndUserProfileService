using System.ComponentModel.DataAnnotations;

namespace UserProject.DataAccess.Entities
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Token { get; set; } = string.Empty;

        [Required]
        public Guid UserId { get; set; }    
        [Required]
        public DateTime ExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRevoked { get; set; } = false;

        public string? ReplacedByToken { get; set; }   

        public User? User { get; set; }
    }
}