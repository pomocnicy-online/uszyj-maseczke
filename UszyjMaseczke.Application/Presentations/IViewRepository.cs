using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Application.Presentations
{
    public interface IViewRepository
    {
        Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsView(CancellationToken cancellationToken);
        Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsViewByCity(string city, CancellationToken cancellationToken);
        Task<IEnumerable<RequestedCitiesView>> ListRequestedCitiesView(CancellationToken cancellationToken);
    }
}