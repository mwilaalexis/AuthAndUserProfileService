using UserProfileServiceProject.Entities;

namespace UserProfileServiceProject.Security
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}