using Connectius.Domain.Entities;

namespace Connectius.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}