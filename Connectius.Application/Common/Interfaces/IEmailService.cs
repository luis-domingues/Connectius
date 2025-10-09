namespace Connectius.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendWelcomeEmail(string email, string name);
    Task SendPasswordResetEmail(string email, string name);
    Task SendEmailChangedNotification(string email, string oldMail);
}