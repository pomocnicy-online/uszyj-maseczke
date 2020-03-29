using log4net;
using MailKit.Security;
using MimeKit;
using UszyjMaseczke.WebApi.Configuration.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace UszyjMaseczke.Infrastructure.Message.Mail
{
    public class MailMessageService : IMessageService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MailMessageService));

        private readonly MailConfiguration _mailConfiguration;
        
        public MailMessageService(MailConfiguration mailConfiguration)
        {
            _mailConfiguration = mailConfiguration;
        }

        public void send(Domain.Message.Message message)
        {
            var mimeMessage = new MimeMessage();
            
            mimeMessage.From.Add(new MailboxAddress(_mailConfiguration.DisplayName, _mailConfiguration.Email));
            mimeMessage.To.Add(new MailboxAddress(message.Receiver));
            mimeMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message.Content;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            send(mimeMessage);
        }

        private void send(MimeMessage message)
        {
            using (var client = new SmtpClient ())
            {
                client.Connect(_mailConfiguration.Host, _mailConfiguration.Port, SecureSocketOptions.SslOnConnect);

                client.Authenticate(_mailConfiguration.Email, _mailConfiguration.Password);

                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}