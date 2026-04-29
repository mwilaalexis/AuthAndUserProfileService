using UserProject.DataAccess.Entities;

namespace UserProject.DataAccess.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<bool> IsTokenValidAsync(string token);
        Task RevokeAllUserTokensAsync(string userId);
        Task SaveChangesAsync();
    }
}