using Connectius.Application.Common.Interfaces.Persistence;
using Connectius.Domain.Entities;

namespace Connectius.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    
    public User? GetUserByEmail(string email)
    { 
        return _users.SingleOrDefault(x => x.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}