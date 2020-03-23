using System.Collections.Generic;

namespace UszyjMaseczke.Application.DTOs.Masks
{
    public class MaskRequestDto
    {
        public string Description { get; set; }
        public IEnumerable<MaskRequestPositionDto> Positions { get; set; }
    }
}