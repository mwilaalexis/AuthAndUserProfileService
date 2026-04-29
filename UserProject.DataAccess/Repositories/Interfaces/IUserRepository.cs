using UserProject.DataAccess.Entities;

namespace UserProject.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(Guid id);

        Task AddAsync(User user);

        Task SaveChangesAsync();
        Task UpdateAsync(User user);
        Task<IEnumerable<User>> GetAllUsers(int page, int pageSize);
        Task DeleteAsync(User user);
    }
}
