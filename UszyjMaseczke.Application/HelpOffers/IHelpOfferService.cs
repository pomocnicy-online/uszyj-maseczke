using System.Threading;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;

namespace UszyjMaseczke.Application.HelpOffers
{
    public interface IHelpOfferService
    {
        Task OfferHelpAsync(OfferHelpDto createRequestDto, CancellationToken cancellationToken);
    }
}