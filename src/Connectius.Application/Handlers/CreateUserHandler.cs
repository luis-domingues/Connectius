using Connectius.Application.DTOs;
using Connectius.Application.Interfaces;
using Connectius.Domain.Entities;
using Connectius.Domain.Interfaces;

namespace Connectius.Application.Handlers;

public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task HandleAsync(UserDto userDto)
    {
        string passwordHash = _passwordHasher.HashPassword(userDto.PasswordHash);
        var newUser = new User(
            userDto.DisplayName,
            userDto.Username,
            userDto.Email,
            passwordHash
            );

        await _userRepository.AddAsync(newUser);
    }
}