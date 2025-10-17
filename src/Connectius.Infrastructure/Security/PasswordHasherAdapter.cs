using Connectius.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Connectius.Infrastructure.Security;

public class PasswordHasherAdapter : IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();
    
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(null, password);
    }
}