using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs.OtherCleaningMaterials
{
    public class CreateRequestOtherCleaningMaterialsDto
    {
        public List<CreateOtherCleaningMaterialDto> OtherCleaningMaterials { get; set; }
    }
}