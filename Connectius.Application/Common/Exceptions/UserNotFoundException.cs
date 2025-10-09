namespace Connectius.Application.User.EventsHandlers;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id) : base("Usuário não encontrado.") { }
}