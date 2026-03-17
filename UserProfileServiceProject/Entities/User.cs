using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserProfileServiceProject.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public Profile? Profile { get; set; }
    }
}
