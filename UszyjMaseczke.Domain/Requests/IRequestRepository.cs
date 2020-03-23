using System.Collections.Generic;
using System.Threading.Tasks;

namespace UszyjMaseczke.Domain.Requests
{
    public interface IRequestRepository
    {
        Task<Request> GetAsync(int id);
        Task<IEnumerable<Request>> GetAsync();
        Task SaveAsync(Request request);
    }
}