using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Domain.Requests
{
    public interface IRequestRepository
    {
        Task<Request> GetAsync(int id, CancellationToken cancellationToken);
        Task<Request> GetLazyAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Request>> GetAsync(CancellationToken cancellationToken);
        Task SaveAsync(Request request, CancellationToken cancellationToken);
        Task RemoveByToken(string token, CancellationToken cancellationToken);
    }
}