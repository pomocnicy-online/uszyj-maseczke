using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.DTOs.Requests;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestService _requestService;
        private readonly IViewRepository _viewRepository;

        public RequestsController(IRequestService requestService, IViewRepository viewRepository,
            IRequestRepository requestRepository)
        {
            _requestService = requestService;
            _viewRepository = viewRepository;
            _requestRepository = requestRepository;
        }

        [ProducesResponseType(typeof(AwaitingRequestDto), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _requestService.GetAwaitingRequestsAsync(id, cancellationToken);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ICollection<AggregatedRequestsView>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _viewRepository.ListAggregatedRequestsView(cancellationToken);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ICollection<AwaitingRequestDto>), 200)]
        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetByCity(string city, CancellationToken cancellationToken)
        {
            var result = await _requestService.GetAwaitingRequestsByCityAsync(city, cancellationToken);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ICollection<string>), 200)]
        [HttpGet("city")]
        public async Task<IActionResult> GetRequestedCities(CancellationToken cancellationToken)
        {
            var result = await _viewRepository.ListRequestedCitiesView(cancellationToken);
            return Ok(result.Select(x => x.City));
        }

        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto, CancellationToken cancellationToken)
        {
            var result = await _requestService.CreateRequestAsync(createRequestDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new {id = result}, result);
        }

        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [HttpDelete("{token}", Name = "RemoveRequest")]
        public async Task<IActionResult> RemoveRequest(string token, CancellationToken cancellationToken)
        {
            await _requestRepository.RemoveByToken(token, cancellationToken);
            return NoContent();
        }
    }
}