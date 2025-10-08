using Connectius.Domain.Events;
using Connectius.Domain.Interfaces;
using Connectius.Domain.ValueObjects;

namespace Connectius.Domain.Entities;

public class User
{
    private readonly List<IDomainEvents> _domainEvents = new();
    
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Username Username { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public string HashedPassword { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime ProfileCreationDate { get; private set; }
    public DateTime? ProfileDeletedDate { get; private set; }
    public IReadOnlyCollection<IDomainEvents> DomainEvents => _domainEvents.AsReadOnly();
    
    private User() { }//for ef core

    public User(
        string name,
        Username username,
        PhoneNumber phoneNumber,
        Email email,
        string hashedPassword,
        DateTime birthDate)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        HashedPassword = hashedPassword ?? throw new ArgumentNullException(nameof(hashedPassword));
        BirthDate = birthDate;
        IsActive = true;
        ProfileCreationDate = DateTime.UtcNow;
        ProfileDeletedDate = null;
        
        var userCreated = new UserCreated(
            Id,
            name,
            Username.Value,
            PhoneNumber.Value,
            Username.Value
            );
        
        _domainEvents.Add(userCreated);
    }

    //soft delete
    public void Delete()
    {
        if(ProfileDeletedDate.HasValue)
            return;
        
        IsActive = false;
        ProfileDeletedDate = DateTime.UtcNow;
        
        _domainEvents.Add(new UserDeleted(
            Id,
            Username.Value,
            PhoneNumber.Value,
            Email.Value
            )
        );
    }

    public void ChangeName(string newName)
    {
        if(Name.Equals(newName))
            return;
        
        var oldName = Name;
        Name = newName;
        
        _domainEvents.Add(new UserNameChanged(
            Id,
            oldName,
            newName));
    }

    public void ChangeEmail(Email newEmail)
    {
        if(Email.Equals(newEmail))
            return;
        
        var oldEmail = Email;
        Email = newEmail;
        
        _domainEvents.Add(new UserEmailChanged(
            Id,
            oldEmail.Value,
            newEmail.Value
            )
        );
    }

    public void ChangePhoneNumber(PhoneNumber newPhoneNumber)
    {
        if(PhoneNumber.Equals(newPhoneNumber))
            return;
        
        var oldPhoneNumber = PhoneNumber;
        PhoneNumber = newPhoneNumber;
        
        _domainEvents.Add(new UserPhoneChanged(
            Id,
            oldPhoneNumber.Value,
            newPhoneNumber.Value));
    }
}