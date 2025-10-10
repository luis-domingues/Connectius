using Connectius.Application.User.Commands.CreateUser;
using Connectius.Application.User.Queries.GetUserByQuery;
using MediatR;

namespace Connectius.WebUI.Routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/user");
        
        group.MapPost("/", CreateUserCommand);
        group.MapGet("/{id:guid}", GetUserByIdQuery);
    }

    public record CreateUserRequest(
        string Name,
        string Username,
        string Email,
        string PhoneNumber,
        string Password,
        DateTime BirthDate);

    private static async Task<IResult> CreateUserCommand(
        CreateUserRequest request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new CreateUserCommand
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password,
                BirthDate = request.BirthDate
            };

            var userId = await mediator.Send(command, cancellationToken);
            return Results.Created($"/api/v1/user/{userId}", userId);
        }
        catch (Exception exception)
        {
            return Results.BadRequest(new { error = exception.Message });
        }
    }

    private static async Task<IResult> GetUserByIdQuery(
        Guid id,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUserByIdQuery { UserId = id };
            var user = await mediator.Send(query, cancellationToken);

            return user is not null
                ? Results.Ok(user)
                : Results.NotFound();
        }
        catch (Exception exception)
        {
            return Results.BadRequest(new { error = exception.Message });
        }
    }
}