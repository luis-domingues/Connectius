using Connectius.Domain.Interfaces;

namespace Connectius.Domain.Events;

public class UserDeleted : IDomainEvents
{
    public Guid UserId { get; }
    public string Username { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public DateTime OccurredOn { get; }

    public UserDeleted(
        Guid userId, 
        string username, 
        string phoneNumber, 
        string email)
    {
        UserId = userId;
        Username = username;
        PhoneNumber = phoneNumber;
        Email = email;
        OccurredOn = DateTime.UtcNow;
    }
}