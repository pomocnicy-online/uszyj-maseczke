using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.HelpOffers;
using UszyjMaseczke.Domain.HelpOffers;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/offerHelp")]
    [Produces("application/json")]
    public class OfferHelpController : ControllerBase
    {
        private readonly IHelpOfferService _helpOfferService;
        private readonly IHelpOfferRepository _helpOfferRepository;

        public OfferHelpController(IHelpOfferService helpOfferService, IHelpOfferRepository helpOfferRepository)
        {
            _helpOfferService = helpOfferService;
            _helpOfferRepository = helpOfferRepository;
        }

        [ProducesResponseType(typeof(HelpOffer), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _helpOfferRepository.GetAsync(id, cancellationToken);
            return Ok(result);
        }

        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [HttpPost(Name = "OfferHelp")]
        public async Task<IActionResult> CreateRequest([FromBody] OfferHelpDto offerHelpDto, CancellationToken cancellationToken)
        {
            var result = await _helpOfferService.OfferHelpAsync(offerHelpDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new {id = result}, result);
        }
    }
}