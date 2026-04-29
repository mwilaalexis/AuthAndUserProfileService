using System.Security.Claims;
using UserProject.DataAccess.Entities;

namespace UserProject.Core.Security
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();           // ← Nouvelle méthode
        ClaimsPrincipal? ValidateToken(string token); // Optionnel mais utile
    }
}