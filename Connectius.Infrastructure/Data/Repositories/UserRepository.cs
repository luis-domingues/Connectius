using Connectius.Domain.Entities;
using Connectius.Domain.Interfaces;
using Connectius.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Connectius.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepostory
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<User> GetByUsernameAsync(string username)
    {
        return _context.Users
            .FirstOrDefaultAsync(x => x.Username.Value == username);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Users.AnyAsync(x => x.Id == id);
    }
}