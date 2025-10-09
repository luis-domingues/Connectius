using Connectius.Application.Common.Interfaces;
using Connectius.Domain.Events;
using MediatR;

namespace Connectius.Application.User.EventsHandlers;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly IEmailService _emailService;
    private readonly IAnalyticsService _analyticsService;

    public UserCreatedEventHandler(IEmailService emailService, IAnalyticsService analyticsService)
    {
        _emailService = emailService;
        _analyticsService = analyticsService;
    }
    
    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}