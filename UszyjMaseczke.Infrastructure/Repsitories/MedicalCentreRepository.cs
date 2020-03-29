using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Application.Exceptions;
using UszyjMaseczke.Domain.MedicalCentres;

namespace UszyjMaseczke.Infrastructure.Repsitories
{
    public class MedicalCentreRepository : IMedicalCentreRepository
    {
        private readonly UszyjMaseczkeDbContext _dbContext;

        public MedicalCentreRepository(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MedicalCentre> GetAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.MedicalCentres
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (result == null)
                throw new NotFoundException($"Could not find MedicalCentre of following id: {id}");

            return result;
        }
    }
}