using Connectius.Domain.Entities;
using Connectius.Domain.Interfaces;
using Connectius.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Connectius.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }
    public async Task AddAsync(User user)
    {
        _userDbContext.Users.Add(user);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        return await _userDbContext.Users.FindAsync(id);
    }

    public async Task<User> GetUserByUsernameAsync(long id, string username)
    {
        return await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id
                                                                   && x.Username == username);
    }
}