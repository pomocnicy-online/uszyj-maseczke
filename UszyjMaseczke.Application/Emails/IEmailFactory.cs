using System.Threading.Tasks;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Application.Emails
{
    public interface IEmailFactory
    {
        Task<string> MakeRequestRegisteredEmail(Request request);
    }
}