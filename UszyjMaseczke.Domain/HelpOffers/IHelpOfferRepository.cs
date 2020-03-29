using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Domain.HelpOffers
{
    public interface IHelpOfferRepository
    {
        Task SaveAsync(HelpOffer request, CancellationToken cancellationToken);
        Task<HelpOffer> GetAsync(int id, CancellationToken cancellationToken);
    }
}