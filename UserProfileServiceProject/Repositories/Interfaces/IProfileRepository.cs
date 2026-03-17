using Microsoft.EntityFrameworkCore;
using UserProfileServiceProject.Data;
using UserProfileServiceProject.DTOs;
using UserProfileServiceProject.Entities;

namespace UserProfileServiceProject.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile> GetByUserIdAsync(Guid userId);

        Task AddAsync(Profile profile);

        Task UpdateAsync(Profile profile);

        Task DeleteAsync(Profile profile);

        Task SaveChangesAsync();
        Task<Profile> CreateAsync(Profile dto);
    }
}
