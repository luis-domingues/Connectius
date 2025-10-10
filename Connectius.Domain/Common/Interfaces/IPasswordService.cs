using Connectius.Domain.ValueObjects;

namespace Connectius.Domain.Common.Interfaces;

public interface IPasswordService
{
    string CreateHash(Password plainText);
    bool VerifyHash(Password plainText, string hashedPassword);
}