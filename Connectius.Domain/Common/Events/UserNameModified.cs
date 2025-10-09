using Connectius.Domain.Interfaces;

namespace Connectius.Domain.Events;

public class UserNameModified : IDomainEvents
{
    public Guid UserId { get; }
    public string OldName { get; }
    public string NewName { get; }
    public DateTime OccurredOn { get; }

    public UserNameModified(Guid userId, string oldName, string newName)
    {
        UserId = userId;
        OldName = oldName;
        NewName = newName;
        OccurredOn = DateTime.UtcNow;
    }
}