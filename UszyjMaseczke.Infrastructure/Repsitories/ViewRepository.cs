using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Application.Presentations;

namespace UszyjMaseczke.Infrastructure.Repsitories
{
    public class ViewRepository : IViewRepository
    {
        private readonly UszyjMaseczkeDbContext _dbContext;

        public ViewRepository(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsView(CancellationToken cancellationToken)
        {
            return await _dbContext.AggregatedRequestsViews.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<AggregatedRequestsView>> ListAggregatedRequestsViewByCity(string city, CancellationToken cancellationToken)
        {
            return await _dbContext.AggregatedRequestsViews.Where(x => x.City == city).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}