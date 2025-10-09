using Connectius.Domain.Interfaces;

namespace Connectius.Domain.Events;

public class UserPasswordModified : IDomainEvents
{
    public Guid UserId { get; }
    public DateTime OccurredOn { get; }

    public UserPasswordModified(Guid userId)
    {
        UserId = userId;
        OccurredOn = DateTime.UtcNow;
    }
}