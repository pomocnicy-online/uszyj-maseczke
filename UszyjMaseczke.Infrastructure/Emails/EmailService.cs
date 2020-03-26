using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using SendGrid;
using SendGrid.Helpers.Mail;
using UszyjMaseczke.Application.Emails;

namespace UszyjMaseczke.Infrastructure.Emails
{
    public class EmailService : IEmailSender
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EmailService));
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken)
        {
            try
            {
                var client = new SendGridClient(_emailConfiguration.ApiKey);
                var msg = CreateEmailMessage(message);
                await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                Logger.Error("Error while sending email");
                Logger.Error(e.StackTrace);
            }
        }                                

        private SendGridMessage CreateEmailMessage(EmailMessage message)
        {
            var sender = new EmailAddress(_emailConfiguration.FromEmail, _emailConfiguration.FromSender);
            var recipents = message.To.Select(x => new EmailAddress(x));

            return MailHelper.CreateSingleEmailToMultipleRecipients(sender, recipents.ToList(), message.Subject,
                message.PlainTextContent, message.HtmlContent);
        }
    }
}