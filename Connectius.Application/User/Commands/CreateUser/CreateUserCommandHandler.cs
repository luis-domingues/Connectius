using Connectius.Domain.Interfaces;
using Connectius.Domain.ValueObjects;
using MediatR;

namespace Connectius.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepostory _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var username = new Username(request.Username);
        var email = new Email(request.Email);
        var phoneNumber = new PhoneNumber(request.PhoneNumber);
        var password = new Password(request.Password);
        
        var hashedPassword = _passwordHasher.HashPassword(password.Value);
        
        var user = new Domain.Entities.User(
            request.Name,
            username,
            phoneNumber,
            email,
            hashedPassword,
            request.BirthDate
            );
        
        await _userRepository.AddAsync(user);
        return user.Id;
    }
}