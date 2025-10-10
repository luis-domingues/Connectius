using Connectius.Domain.Common.Interfaces;
using Connectius.Domain.Interfaces;
using Connectius.Domain.ValueObjects;

namespace Connectius.Domain.Services;

public class PasswordService : IPasswordService
{
    private readonly IPasswordHasher _passwordHasher;

    public PasswordService(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    
    public string CreateHash(Password plainText)
    {
        return _passwordHasher.HashPassword(plainText.Value);
    }

    public bool VerifyHash(Password plainText, string hashedPassword)
    {
        return _passwordHasher.VerifyPassword(plainText.Value, hashedPassword);
    }
}