using Connectius.Domain.Interfaces;

namespace Connectius.Domain.Events;

public class UserPhoneModified : IDomainEvents
{
    public Guid  UserId { get; }
    public string OldPhoneNumber { get; }
    public string NewPhoneNumber { get; }
    public DateTime OccurredOn { get; }

    public UserPhoneModified(Guid userId, string oldPhoneNumber, string newPhoneNumber)
    {
        UserId = userId;
        OldPhoneNumber = oldPhoneNumber;
        NewPhoneNumber = newPhoneNumber;
        OccurredOn = DateTime.Now;
    }
}