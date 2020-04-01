using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Application.Emails
{
    public interface IEmailSender
    {
        Task SendAsync<T>(EmailMessage<T> message, CancellationToken cancellationToken);
    }
}