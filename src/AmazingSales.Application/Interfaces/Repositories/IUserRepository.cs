using AmazingSales.Domain.Entities;

namespace AmazingSales.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User, long>
    {
        Task<User> GetUserByEmail(string email);
    }
}
