using Connectius.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Connectius.Infrastructure.Services;

public class MockEmailService : IEmailService
{
    private readonly ILogger<MockEmailService> _logger;

    public MockEmailService(ILogger<MockEmailService> logger)
    {
        _logger = logger;
    }
    
    public Task SendWelcomeEmail(string email, string name)
    {
        _logger.LogInformation("MOCK: Gostaria de enviar para {Email} de {Name}", email, name);
        return Task.CompletedTask;
    }

    public Task SendPasswordResetEmail(string email, string name)
    {
        _logger.LogInformation("MOCK: Gostaria de enviar um e-mail de redefinição de senha para {Email}", email);
        return Task.CompletedTask;
    }

    public Task SendEmailChangedNotification(string email, string oldMail)
    {
        _logger.LogInformation("MOCK: Gostaria de enviar uma notificação de alteração por e-mail para {Email}", email);
        return Task.CompletedTask;
    }
}