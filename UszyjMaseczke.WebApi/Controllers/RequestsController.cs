using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IViewRepository _viewRepository;
        private readonly IRequestRepository _requestRepository;


        public RequestsController(IRequestService requestService, IViewRepository viewRepository, IRequestRepository requestRepository)
        {
            _requestService = requestService;
            _viewRepository = viewRepository;
            _requestRepository = requestRepository;
        }

        [ProducesResponseType(typeof(Request), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _requestRepository.GetAsync(id));
        }

        [ProducesResponseType(typeof(ICollection<AggregatedRequestsView>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _viewRepository.ListAggregatedRequestsView());
        }

        [ProducesResponseType(typeof(ICollection<AggregatedRequestsView>), 200)]
        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetByCity(string city)
        {
            return Ok(await _viewRepository.ListAggregatedRequestsViewByCity(city));
        }

        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto)
        {
            var result = await _requestService.CreateRequestAsync(createRequestDto);
            return Ok(result);
        }
    }
}