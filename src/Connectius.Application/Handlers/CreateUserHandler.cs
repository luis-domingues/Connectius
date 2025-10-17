using Connectius.Application.DTOs;
using Connectius.Domain.Entities;
using Connectius.Domain.Interfaces;

namespace Connectius.Application.Handlers;

public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(UserDto userDto)
    {
        var newUser = new User(
            userDto.DisplayName,
            userDto.Username,
            userDto.Email,
            userDto.PasswordHash
            );

        await _userRepository.AddAsync(newUser);
    }
}