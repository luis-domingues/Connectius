using Connectius.Application.Common.DTOs;
using Connectius.Application.Common.Exceptions;
using Connectius.Domain.Interfaces;
using MediatR;

namespace Connectius.Application.User.Queries.GetUserByQuery;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepostory _userRepostory;

    public GetUserByIdQueryHandler(IUserRepostory userRepostory)
    {
        _userRepostory = userRepostory;
    }
    
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepostory.GetByIdAsync(request.UserId);
        if (user == null)
            throw new UserNotFoundException(request.UserId);

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.Username.Value,
            Email = user.Email.Value,
            PhoneNumber = user.PhoneNumber.Value,
            IsActive = user.IsActive
        };
    }
}