using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RequestsController));
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

        [ProducesResponseType(typeof(Request), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _requestRepository.GetAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while getting request by id {id}");
                Logger.Error(e.StackTrace);
                throw e;
            }
        }

        [ProducesResponseType(typeof(ICollection<AggregatedRequestsView>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _viewRepository.ListAggregatedRequestsView();
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.Error("Error while getting request");
                Logger.Error(e.StackTrace);
                throw e;
            }
        }

        [ProducesResponseType(typeof(ICollection<AggregatedRequestsView>), 200)]
        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetByCity(string city)
        {
            try
            {
                var result = await _viewRepository.ListAggregatedRequestsViewByCity(city);
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while getting requests by city {city}");
                Logger.Error(e.StackTrace);
                throw e;
            }
        }

        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto)
        {
            try
            {
                var result = await _requestService.CreateRequestAsync(createRequestDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.Error("Error while creating DTO request");
                Logger.Error(e.StackTrace);
                throw e;
            }
        }
    }
}