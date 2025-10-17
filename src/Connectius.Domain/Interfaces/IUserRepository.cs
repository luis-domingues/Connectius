using Connectius.Domain.Entities;

namespace Connectius.Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetUserByIdAsync(long id);
    Task<User> GetUserByUsernameAsync(long id, string username);
}