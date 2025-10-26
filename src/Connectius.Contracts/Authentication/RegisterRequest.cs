namespace Connectius.Contracts.Authentication;

public record RegisterRequest(
    string DisplayName,
    string Username,
    string Email,
    string Password);