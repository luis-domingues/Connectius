using Connectius.Domain.Exceptions;

namespace Connectius.Domain.ValueObjects;

public class Username : IEquatable<Username>
{
    public string Value { get; }

    public Username(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length < 3)
            throw new InvalidUsernameFormat(value);
        
        Value = value.Trim();
    }

    public bool Equals(Username? other)
    {
        if(other is null)
            return false;
        
        return other.Value == Value;
    }
    
    public override bool Equals(object? obj) => Equals(obj as Username);
    
    public override int GetHashCode() => Value.GetHashCode();
    
    public override string ToString() => Value;
}