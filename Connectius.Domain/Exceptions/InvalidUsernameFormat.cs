namespace Connectius.Domain.Exceptions;

public class InvalidUsernameFormat : Exception
{
    public InvalidUsernameFormat(string username) 
        : base($"O username '{username}' não deverá ser vazio ou conter menos que 3 caracteres") { }
}