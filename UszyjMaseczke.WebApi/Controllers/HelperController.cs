using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Domain.Helpers;
using UszyjMaseczke.Infrastructure;

namespace UszyjMaseczke.WebApi.Controllers
{
    [Route("api/Helper")]
    [Produces("application/json")]
    public class HelperController : ControllerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HelperController));
        private readonly UszyjMaseczkeDbContext _dbContext;

        public HelperController(UszyjMaseczkeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "CreateHelperRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateHelperRequestDto createRequestDto)
        {
            var request = new HelperRequest
            {
                Helper = new Helper
                {
                    FirstName = createRequestDto.Helper.FirstName,
                    LastName = createRequestDto.Helper.LastName,
                    City = createRequestDto.Helper.City,
                    Email = createRequestDto.Helper.Email,
                    Street = createRequestDto.Helper.Street,
                    ApartmentNumber = createRequestDto.Helper.ApartmentNumber,
                    BuildingNumber = createRequestDto.Helper.BuildingNumber,
                    PhoneNumber = createRequestDto.Helper.PhoneNumber
                }
            };
            try
            {
                await _dbContext.AddAsync(request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Logger.Error("Error while creating helper request");
                Logger.Error(e.StackTrace);
            }

            return Ok();
        }
    }
}