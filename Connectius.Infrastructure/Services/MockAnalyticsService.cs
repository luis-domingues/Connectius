using Connectius.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Connectius.Infrastructure.Services;

public class MockAnalyticsService : IAnalyticsService
{
    private readonly ILogger<MockAnalyticsService> _logger;

    public MockAnalyticsService(ILogger<MockAnalyticsService> logger)
    {
        _logger = logger;
    }
    
    public Task TrackUserCreated(Guid id, string username)
    {
        _logger.LogInformation("MOCK: Gostaria de acompanhar a criação de {UserId} com o nickname {Username}", id, username);
        return Task.CompletedTask;
    }

    public Task TrackUserLogin(Guid id)
    {
        _logger.LogInformation("MOCK: Gostaria de acompanhar o login de {UserId}", id);
        return Task.CompletedTask;
    }

    public Task TrackUserAction(Guid id, string action, Dictionary<string, object> parameters)
    {
        _logger.LogInformation("MOCK: Gostaria de acompanhar esta ação {Action} de {UserId}", action, id);
        return Task.CompletedTask;
    }
}