using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Application.Emails
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message, CancellationToken cancellationToken);
    }
}