using Microsoft.EntityFrameworkCore;
using UserProject.DataAccess.Data;
using UserProject.DataAccess.Entities;
using UserProject.DataAccess.Repositories.Interfaces;

namespace UserProject.DataAccess.Repositories.Implementations
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;   

        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == token);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RevokeAllUserTokensAsync(string userId)
        {
            Guid userGuid = Guid.Parse(userId);
            var tokens = await _context.RefreshTokens
                .Where(rt => rt.UserId == userGuid && !rt.IsRevoked)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }
        }

        public async Task<bool> IsTokenValidAsync(string token)
        {
            var refreshToken = await GetByTokenAsync(token);
            return refreshToken != null
                && !refreshToken.IsRevoked
                && refreshToken.ExpiresAt > DateTime.UtcNow;
        }
    }
}