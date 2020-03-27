using System.Collections.Generic;
using System.Threading;
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

        public Task<Request> GetAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Requests
                .Include(x => x.MedicalCentre)
                .Include(x => x.MaskRequest)
                .Include(x => x.MaskRequest.Positions)
                .Include(x => x.GlovesRequest)
                .Include(x => x.GlovesRequest.Positions)
                .Include(x => x.DisinfectionMeasureRequest)
                .Include(x => x.DisinfectionMeasureRequest.Positions)
                .Include(x => x.SuitRequest)
                .Include(x => x.SuitRequest.Positions)
                .Include(x => x.GroceryRequest)
                .Include(x => x.GroceryRequest.Positions)
                .Include(x => x.OtherCleaningMaterialRequest)
                .Include(x => x.OtherCleaningMaterialRequest.Positions)
                .Include(x => x.PsychologicalSupportRequest)
                .Include(x => x.SewingSuppliesRequest)
                .Include(x => x.OtherRequest)
                .Include(x => x.PrintRequest)
                .Include(x => x.PrintRequest.Positions)
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Request>> GetAsync(CancellationToken cancellationToken)
        {
            return await _dbContext
                .Requests
                .Include(x => x.MedicalCentre)
                .Include(x => x.MaskRequest)
                .Include(x => x.MaskRequest.Positions)
                .Include(x => x.GlovesRequest)
                .Include(x => x.GlovesRequest.Positions)
                .Include(x => x.DisinfectionMeasureRequest)
                .Include(x => x.DisinfectionMeasureRequest.Positions)
                .Include(x => x.SuitRequest)
                .Include(x => x.SuitRequest.Positions)
                .Include(x => x.GroceryRequest)
                .Include(x => x.GroceryRequest.Positions)
                .Include(x => x.OtherCleaningMaterialRequest)
                .Include(x => x.OtherCleaningMaterialRequest.Positions)
                .Include(x => x.PsychologicalSupportRequest)
                .Include(x => x.SewingSuppliesRequest)
                .Include(x => x.OtherRequest)
                .Include(x => x.PrintRequest)
                .Include(x => x.PrintRequest.Positions)
                .ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(Request request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(request, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}