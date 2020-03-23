using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IRequestRepository _requestRepository;

        public RequestsController(IRequestService requestService, IRequestRepository requestRepository)
        {
            _requestService = requestService;
            _requestRepository = requestRepository;
        }

        [ProducesResponseType(typeof(ICollection<Request>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _requestRepository.GetAsync());
        }

        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto)
        {
            var result = await _requestService.CreateRequestAsync(createRequestDto);
            return Ok(result);
        }
    }
}