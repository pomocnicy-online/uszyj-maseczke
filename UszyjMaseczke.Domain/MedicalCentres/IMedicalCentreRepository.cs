using System.Threading;
using System.Threading.Tasks;

namespace UszyjMaseczke.Domain.MedicalCentres
{
    public interface IMedicalCentreRepository
    {
        Task<MedicalCentre> GetAsync(int id, CancellationToken cancellationToken);
    }
}