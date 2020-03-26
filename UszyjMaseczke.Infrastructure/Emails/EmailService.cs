using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using UszyjMaseczke.Application.Emails;

namespace UszyjMaseczke.Infrastructure.Emails
{
    public class EmailService : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken)
        {
            var mimeMessage = CreateEmailMessage(message);
            await SendInternalAsync(mimeMessage, cancellationToken);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.AddRange(message.To.Select(InternetAddress.Parse));
            emailMessage.Cc.AddRange(message.Cc.Select(InternetAddress.Parse));
            emailMessage.Bcc.AddRange(message.Bcc.Select(InternetAddress.Parse));

            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private async Task SendInternalAsync(MimeMessage mailMessage, CancellationToken cancellationToken)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTlsWhenAvailable, cancellationToken);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password, cancellationToken);
                await client.SendAsync(mailMessage, cancellationToken);
            }
            finally
            {
                await client.DisconnectAsync(true, cancellationToken);
            }
        }
    }
}