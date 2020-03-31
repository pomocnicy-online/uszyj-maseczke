using System.Threading;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.DTOs.Requests;

namespace UszyjMaseczke.Application.Requests
{
    public interface IRequestService
    {
        Task<int> CreateRequestAsync(CreateRequestDto createRequestDto, CancellationToken cancellationToken);
        Task<AwaitingRequestDto> GetAwaitingRequestsAsync(int requestId, CancellationToken cancellationToken);
    }
}