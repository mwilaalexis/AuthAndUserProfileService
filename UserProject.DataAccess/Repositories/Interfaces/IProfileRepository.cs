using UserProject.DataAccess.Entities;

namespace UserProject.DataAccess.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile?> GetByProfileIdAsync(Guid userId);

        Task AddAsync(Profile profile);

        Task UpdateAsync(Profile profile);

        Task DeleteAsync(Profile profile);

        Task SaveChangesAsync();
        Task<Profile> CreateAsync(Profile Profile);
    }
}
