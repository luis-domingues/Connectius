namespace Connectius.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string DisplayName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public User(string displayName, string username, string email, string passwordHash)
    {
        Id = 0;
        DisplayName = displayName;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedOn = DateTime.UtcNow;
    }
}