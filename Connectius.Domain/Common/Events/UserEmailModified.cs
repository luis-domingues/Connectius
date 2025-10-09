using Connectius.Domain.Interfaces;

namespace Connectius.Domain.Events;

public class UserEmailModified : IDomainEvents
{
    public Guid UserId { get; }
    public string OldEmail { get; }
    public string NewEmail { get; }
    public DateTime OccurredOn { get; }

    public UserEmailModified(
        Guid userId,
        string oldEmail,
        string newEmail
        )
    {
        UserId = userId;
        OldEmail = oldEmail;
        NewEmail = newEmail;
        OccurredOn = DateTime.UtcNow;
    }
}