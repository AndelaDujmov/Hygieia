using Microsoft.AspNetCore.Identity.UI.Services;

namespace HygieiaApp.Utility.Utils.Email;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        
        return Task.CompletedTask;
    }
}