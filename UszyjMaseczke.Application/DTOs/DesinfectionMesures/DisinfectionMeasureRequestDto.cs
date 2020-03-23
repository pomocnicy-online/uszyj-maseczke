using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Groceries;

namespace UszyjMaseczke.Application.DTOs.DesinfectionMesures
{
    public class DisinfectionMeasureRequestDto
    {
        public IEnumerable<DisinfectionMeasureRequestPositionDto> Positions { get; set; }
    }
}