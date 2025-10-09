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
        return await _context
            .Set<User>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<User> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(User user)
    {
        await _context
            .Set<User>()
            .AddAsync(user);
        
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}