namespace Connectius.Domain.Exceptions;

public class InvalidPasswordFormat : Exception
{
    public InvalidPasswordFormat() : base("A senha não pode ser vazia e deve possuir 6 caracteres.") { }
}