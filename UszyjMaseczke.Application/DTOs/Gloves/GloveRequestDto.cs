using System.Collections.Generic;

namespace UszyjMaseczke.Application.DTOs.Gloves
{
    public class GloveRequestDto
    {
        public string Description { get; set; }
        public IEnumerable<GloveRequestPositionDto> Positions { get; set; }
    }
}