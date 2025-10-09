using Connectius.Domain.Interfaces;
using MediatR;

namespace Connectius.Domain.Events;

public class UserCreated : IDomainEvents, INotification
{
    public Guid UserId { get; }
    public string Name { get; }
    public string Username { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public DateTime OccurredOn { get; }

    public UserCreated(
        Guid userId, 
        string name, 
        string username, 
        string phoneNumber, 
        string email
        )
    {
        UserId = userId;
        Name = name;
        Username = username;
        PhoneNumber = phoneNumber;
        Email = email;
        OccurredOn = DateTime.UtcNow;
    }
}