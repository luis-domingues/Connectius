using Connectius.Domain.Exceptions;

namespace Connectius.Domain.ValueObjects;

public class Password : IEquatable<Password>
{
    public string Value { get; }

    public Password(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length < 6 || !HasMinimumComplexity(value))
            throw new InvalidPasswordFormat();
        
        Value = value;
    }

    private static bool HasMinimumComplexity(string value)
    {
        return 
            value.Any(char.IsUpper) &&
            value.Any(char.IsLower) &&
            value.Any(char.IsDigit);
    }

    public bool Equals(Password? other)
    {
        if (other == null)
            return false;
        
        return other.Value == Value;
    }
    
    public override bool Equals(object? obj) => Equals(obj as Password);
    
    public override int GetHashCode() => Value.GetHashCode();
    
    public static bool operator ==(Password? left, Password? right) => left.Equals(right);
    
    public static bool operator !=(Password? left, Password? right) => !(left == right);
}