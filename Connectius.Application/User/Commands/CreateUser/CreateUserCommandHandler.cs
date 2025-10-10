using Connectius.Domain.Common.Interfaces;
using Connectius.Domain.Interfaces;
using Connectius.Domain.Services;
using Connectius.Domain.ValueObjects;
using MediatR;

namespace Connectius.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepostory _userRepository;
    private readonly IPasswordService _passwordService;

    public CreateUserCommandHandler(
        IUserRepostory userRepository,
        IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var username = new Username(request.Username);
        var email = new Email(request.Email);
        var phoneNumber = new PhoneNumber(request.PhoneNumber);
        var password = new Password(request.Password);

        var hashedPassword = _passwordService.CreateHash(password);
        
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