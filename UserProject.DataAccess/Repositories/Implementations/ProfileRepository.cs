using Microsoft.EntityFrameworkCore;
using UserProject.DataAccess.Data;
using UserProject.DataAccess.Entities;
using UserProject.DataAccess.Repositories.Interfaces;

namespace UserProfileServiceProject.Repositories.Implementations
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Profile?> GetByProfileIdAsync(Guid userId)
        {
            return await _context.Profiles
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
           
        }

        public async Task UpdateAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public async Task DeleteAsync(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> CreateAsync(Profile Profile)
        {
            _context.Profiles.Add(Profile);
            await _context.SaveChangesAsync();

            return Profile;
        }
    }
}
