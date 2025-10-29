using Connectius.Domain.Entities;

namespace Connectius.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token);