using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Application.Exceptions;
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

        public async Task<Request> GetLazyAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Requests
                .Include(x => x.MedicalCentre)
                .SingleOrDefaultAsync(x => x.Id == id && x.Active, cancellationToken);

            if (result == null)
                throw new NotFoundException($"Could not find active Request of following id: {id}");

            return result;
        }

        public async Task<Request> GetAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Requests
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
                .Include(x => x.DeliveryRequest)
                .SingleOrDefaultAsync(x => x.Id == id && x.Active, cancellationToken);

            if (result == null)
                throw new NotFoundException($"Could not find active Request of following id: {id}");

            return result;
        }

        public async Task<IEnumerable<Request>> GetByCityAsync(string id, CancellationToken cancellationToken)
        {
            return await _dbContext.Requests
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
                .Include(x => x.DeliveryRequest)
                .Where(x => x.MedicalCentre.City.ToUpper() == id.ToUpper() && x.Active)
                .ToListAsync(cancellationToken);
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
                .Include(x => x.DeliveryRequest)
                .Where(x => x.Active)
                .ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(Request request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(request, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveByToken(string token, CancellationToken cancellationToken)
        {
            var request = await _dbContext.Requests.SingleOrDefaultAsync(x => x.RemovalToken == token, cancellationToken);
            request.Active = false;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}