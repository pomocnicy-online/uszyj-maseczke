using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Application.Exceptions;
using UszyjMaseczke.Domain.HelpOffers;

namespace UszyjMaseczke.Infrastructure.Repsitories
{
    public class HelpOfferRepository : IHelpOfferRepository
    {
        private readonly UszyjMaseczkeDbContext _dbContext;

        public HelpOfferRepository(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(HelpOffer helpOffer, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(helpOffer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<HelpOffer> GetAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.HelpOffers
                .Include(x => x.MedicalCentre)
                .Include(x => x.Helper)
                .Include(x => x.Request)
                .Include(x => x.MaskSupplies)
                .Include(x => x.MaskSupplies.Positions)
                .Include(x => x.GloveSupplies)
                .Include(x => x.GloveSupplies.Positions)
                .Include(x => x.DisinfectionMeasureSupplies)
                .Include(x => x.DisinfectionMeasureSupplies.Positions)
                .Include(x => x.SuitSupplies)
                .Include(x => x.SuitSupplies.Positions)
                .Include(x => x.GrocerySupplies)
                .Include(x => x.GrocerySupplies.Positions)
                .Include(x => x.OtherCleaningMaterialSupplies)
                .Include(x => x.OtherCleaningMaterialSupplies.Positions)
                .Include(x => x.PsychologicalSupportSupplies)
                .Include(x => x.SewingSuppliesSupplies)
                .Include(x => x.OtherSupplies)
                .Include(x => x.PrintSupplies)
                .Include(x => x.PrintSupplies.Positions)
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if(result == null)
                throw new NotFoundException($"Could not find Help Offer of id: {id}");

            return result;
        }
    }
}