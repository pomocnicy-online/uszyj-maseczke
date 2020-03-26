using System.Collections.Generic;

namespace UszyjMaseczke.Application.DTOs.DesinfectionMesures
{
    public class DisinfectionMeasureRequestDto
    {
        public IEnumerable<DisinfectionMeasureRequestPositionDto> Positions { get; set; }
    }
}