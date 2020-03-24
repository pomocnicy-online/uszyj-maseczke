using System.Collections.Generic;
using System.Threading.Tasks;

namespace UszyjMaseczke.Application.Presentations
{
    public interface IViewRepository
    {
        Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsView();
        Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsViewByCity(string city);
    }
}