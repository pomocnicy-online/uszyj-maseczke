using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.Dungarees;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.PsychologicalSupport;
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
                GroceryRequestPositions = createRequestDto.Groceries
                    .Select(x => new GroceryRequest
                    {
                        GroceryType = x.GroceryType,
                        Quantity = x.Quantity
                    })
                    .ToList(),
                OtherCleaningMaterialRequestPositions = createRequestDto.OtherCleaningMaterials
                    .Select(x=>new OtherCleaningMaterialRequest
                    {
                        OtherCleaningMaterialType = x.CreateOtherCleaningMaterialType,
                        Quantity = x.Quantity
                    }).ToList(),
                DungareeRequestPositions = createRequestDto.Dungaries
                    .Select(x=>new DungareeRequest
                    {
                        DungareeType = x.DungareeType,
                        Quantity = x.Quantity
                    }).ToList(),
                PsychologicalSupportRequestPositions = createRequestDto.PsychologicalSupports
                    .Select(x=>new PsychologicalSupportRequest
                    {
                        Description = x.Description
                    }).ToList()
            };

            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}