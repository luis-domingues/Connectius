namespace Connectius.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string DisplayName,
    string Username,
    string Email,
    string Token);