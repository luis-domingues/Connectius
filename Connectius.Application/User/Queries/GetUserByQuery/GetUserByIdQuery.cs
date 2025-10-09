using Connectius.Application.Common.DTOs;
using MediatR;

namespace Connectius.Application.User.Queries.GetUserByQuery;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid UserId { get; set; }
}