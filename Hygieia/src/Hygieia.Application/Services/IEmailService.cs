using Hygieia.Application.Common.Email;

namespace Hygieia.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
