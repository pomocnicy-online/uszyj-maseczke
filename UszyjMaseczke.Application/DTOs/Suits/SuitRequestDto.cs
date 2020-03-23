using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Gloves;

namespace UszyjMaseczke.Application.DTOs.Suits
{
    public class SuitRequestDto
    {
        public string Description { get; set; }
        public IEnumerable<GloveRequestPositionDto> Positions { get; set; }
    }
}