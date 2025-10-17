using Connectius.Application.DTOs;
using Connectius.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Connectius.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;

    public UserController(CreateUserHandler createUserHandler)
    {
        _createUserHandler = createUserHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        await _createUserHandler.HandleAsync(userDto);
        return Created();
    }
}