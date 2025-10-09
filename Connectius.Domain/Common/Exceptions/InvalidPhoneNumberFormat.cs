namespace Connectius.Domain.Exceptions;

public class InvalidPhoneNumberFormat : Exception
{
    public InvalidPhoneNumberFormat()
        : base("O número de telefone no formato errado. Utilize apenas números") { }
}