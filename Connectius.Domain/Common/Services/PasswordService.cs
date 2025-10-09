using Connectius.Domain.Interfaces;
using Connectius.Domain.ValueObjects;

namespace Connectius.Domain.Services;

public class PasswordService
{
    private readonly IPasswordHasher _passwordHasher;

    public PasswordService(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string CreateHash(Password password)
    {
        return _passwordHasher.HashPassword(password.Value);
    }

    public bool VerifyHash(Password providedPassword, string storedHash)
    {
        return _passwordHasher.VerifyPassword(providedPassword.Value, storedHash);
    }
}