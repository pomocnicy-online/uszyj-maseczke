using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Helpers;

namespace UszyjMaseczke.Application.DTOs
{
    public class OfferHelpDto
    {
        public IEnumerable<OfferHelpPositionDto> Requests { get; set; }
        public CreateHelperDto Helper { get; set; }
    }
}