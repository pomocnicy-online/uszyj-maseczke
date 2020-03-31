using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Groceries;

namespace UszyjMaseczke.Application.DTOs.OtherCleaningMaterials
{
    public class OtherCleaningMaterialRequestDto
    {
        public IEnumerable<OtherCleaningMaterialRequestPositionDto> Positions { get; set; }
    }
}