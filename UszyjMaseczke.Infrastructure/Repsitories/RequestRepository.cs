using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Infrastructure.Repsitories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly UszyjMaseczkeDbContext _dbContext;

        public RequestRepository(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Request> GetAsync(int id)
        {
            return _dbContext.Requests.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Request>> GetAsync()
        {
            return await _dbContext.Requests.ToListAsync();
        }

        public async Task SaveAsync(Request request)
        {
            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}