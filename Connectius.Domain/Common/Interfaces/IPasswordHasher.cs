using Connectius.Domain.ValueObjects;

namespace Connectius.Domain.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string plainText);
    bool VerifyPassword(string plainText, string hashedPassword);
}