using System.Text.RegularExpressions;
using Connectius.Domain.Exceptions;

namespace Connectius.Domain.ValueObjects;

public class PhoneNumber : IEquatable<PhoneNumber>
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length != 11)
            throw new InvalidPhoneNumberFormat();
        
        if(!Regex.IsMatch(value, "^[0-9]{11}$"))
            throw new InvalidPhoneNumberFormat();
        
        Value = value;
    }

    public bool Equals(PhoneNumber? other)
    {
        if(other is null)
            return false;
        
        return other.Value == Value;
    }
    
    public override bool Equals(object obj) => Equals(obj as PhoneNumber);
    
    public override int GetHashCode() => Value.GetHashCode();
    
    public override string ToString() => Value;
}