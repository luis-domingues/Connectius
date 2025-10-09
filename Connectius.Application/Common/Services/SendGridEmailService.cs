using Connectius.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Connectius.Application.Services;

public class SendGridEmailService : IEmailService
{
    private readonly SendGridClient _sendGridClient;
    private readonly ILogger _logger;

    public SendGridEmailService(SendGridClient sendGridClient, ILogger<SendGridEmailService> logger)
    {
        _sendGridClient = sendGridClient;
        _logger = logger;
    }
    
    public async Task SendWelcomeEmail(string email, string name)
    {
        try
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress("luisdomingues117@gmail.com", "Connectius"),
                Subject = "Muito obrigado por se registrar no Connectius!",
                PlainTextContent = $"E ai, {name}! É bom te ter aqui (:\n\n" +
                                   $"Este é um projeto desenvolvido por Luís Paulo Domingues!",
                HtmlContent = $"<strong>E ai, {name}! É bom te ter aqui (:\n\n\"" +
                              $"Este é um projeto desenvolvido por Luís Paulo Domingues!</strong>"
            };

            message.AddTo(new EmailAddress(email, email));

            var response = await _sendGridClient.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Falha ao enviar e-mail de boas-vindas para {Email}. Status: {Status}", 
                    email, 
                    response.StatusCode);
            }
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Falha ao enviar e-mail de boas-vindas para {Email}.", email);
        }
    }

    public Task SendPasswordResetEmail(string email, string name)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailChangedNotification(string email, string oldMail)
    {
        throw new NotImplementedException();
    }
}