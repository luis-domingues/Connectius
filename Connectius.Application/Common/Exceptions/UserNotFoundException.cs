namespace Connectius.Application.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id) : base("Usuário não encontrado.") { }
}