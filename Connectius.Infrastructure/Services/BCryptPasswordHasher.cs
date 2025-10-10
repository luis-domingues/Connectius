using Connectius.Domain.Interfaces;

namespace Connectius.Infrastructure.Services;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string HashPassword(string plainText)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainText);
    }

    public bool VerifyPassword(string plainText, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainText, hashedPassword);
    }
}