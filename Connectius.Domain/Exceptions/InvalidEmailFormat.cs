namespace Connectius.Domain.Exceptions;

public class InvalidEmailFormat : Exception
{
    public InvalidEmailFormat() : base($"O formato do e-mail está inválido") { }
}