namespace Connectius.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string DisplayName,
    string Username,
    string Email,
    string Token);