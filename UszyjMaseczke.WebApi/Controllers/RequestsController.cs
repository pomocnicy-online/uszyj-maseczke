using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentre;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.WebApi.DTOs;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/requests")]
    [Produces("application/json")]
    public class RequestsController : ControllerBase
    {
        private readonly UszyjMaseczkeDbContext _dbContext;

        public RequestsController(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Requests.ToListAsync());
        }

        [HttpPost(Name = "CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto)
        {
            var request = new Request
            {
                MedicalCentre = new MedicalCentre
                {
                    City = createRequestDto.MedicalCentre.City,
                    Email = createRequestDto.MedicalCentre.Email,
                    Street = createRequestDto.MedicalCentre.Street,
                    ApartmentNumber = createRequestDto.MedicalCentre.ApartmentNumber,
                    BuildingNumber = createRequestDto.MedicalCentre.BuildingNumber,
                    LegalName = createRequestDto.MedicalCentre.LegalName,
                    PhoneNumber = createRequestDto.MedicalCentre.PhoneNumber
                },
                MaskRequests = new List<MaskRequest>(),
                GlovesRequests = new List<GloveRequest>()
            };
            foreach (var maskRequest in createRequestDto.MaskRequests)
            {
                request.MaskRequests.Add(new MaskRequest()
                {
                    Quantity = maskRequest.Quantity,
                    MaskType = maskRequest.MaskType,
                    Description = maskRequest.Description
                });
            }
            foreach (var maskRequest in createRequestDto.GloveRequests)
            {
                request.GlovesRequests.Add(new GloveRequest()
                {
                    Quantity = maskRequest.Quantity,
                    GloveType = maskRequest.GloveType,
                    Description = maskRequest.Description

                });
            }
            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}