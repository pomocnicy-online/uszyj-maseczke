using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;

namespace UszyjMaseczke.Application.Requests
{
    public interface IRequestService
    {
        Task<int> CreateRequestAsync(CreateRequestDto createRequestDto);
    }
}