namespace Connectius.Application.DTOs;

public class UserDto
{
    public string DisplayName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}