using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Requests;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto)
        {
            var result = await _requestService.CreateRequestAsync(createRequestDto);
            return Ok(result);
        }
    }
}