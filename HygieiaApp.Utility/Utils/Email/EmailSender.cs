using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HygieiaApp.Utility.Utils.Email;

public class EmailSender : IEmailSender
{
    public string SecretKey { get; set; }

    public EmailSender(IConfiguration _configuration)
    {
        SecretKey = _configuration.GetValue<string>("SendGrid:SecretKey");
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SendGridClient(SecretKey);

        var from = new EmailAddress("ad46874@oss.unist.hr", "Hygieia");
        var to = new EmailAddress(email);
        var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        return client.SendEmailAsync(message);
    }
    
}