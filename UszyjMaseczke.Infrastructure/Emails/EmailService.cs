using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using SendGrid;
using SendGrid.Helpers.Mail;
using DotLiquid;
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

        public async Task SendAsync<T>(EmailMessage<T> message, CancellationToken cancellationToken)
        {
            try
            {
                var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_APIKEY"));
                var msg = CreateEmailMessage(message);
                await client.SendEmailAsync(msg, cancellationToken);
            }
            catch (Exception e)
            {
                Logger.Error($"Sending email failed. Provided message {e.Message}");
                Logger.Error(e.StackTrace);
            }
        }

        private SendGridMessage CreateEmailMessage<T>(EmailMessage<T> message)
        {
            var @assembly = Assembly.GetAssembly(this.GetType());
            var templateName = $"UszyjMaseczke.Infrastucture.Emails.Templates.{message.Template.ToString()}.html";

            var content = string.Empty;

            using (var stream = @assembly.GetManifestResourceStream(templateName))
            {
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            var renderedHtml = Render(content, message.Body);

            var sender = new EmailAddress(_emailConfiguration.FromEmail, _emailConfiguration.FromSender);

            return MailHelper.CreateSingleEmailToMultipleRecipients(sender,
                message.To.Select(t => new EmailAddress(t)).ToList(), message.Subject, string.Empty,
                renderedHtml);
        }

        private static string Render(string template, object body)
        {
            var payload = Hash.FromAnonymousObject(body, true);
            var parsedTemplate = Template.Parse(template);
            return parsedTemplate.Render(payload);
        }
    }
}