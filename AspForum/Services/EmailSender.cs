using AspForum.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute("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", subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("aspforumtest@gmail.com", "apikey"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}


//dotnet user-secrets set SendGridUser apikey  --project C:\Users\Admin\source\repos\AspForum\aspforum\AspForum
//dotnet user-secrets set SendGridKey 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  --project C:\Users\Admin\source\repos\AspForum\aspforum\AspForum