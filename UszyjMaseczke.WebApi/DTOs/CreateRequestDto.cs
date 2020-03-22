using System.Collections.Generic;
using UszyjMaseczke.WebApi.DTOs.Dungarees;
using UszyjMaseczke.WebApi.DTOs.Groceries;
using UszyjMaseczke.WebApi.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.WebApi.DTOs.PsychologicalSupport;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestDto
    {
        public CreateRequestMedicalCentreDto MedicalCentre { get; set; }

        public List<CreateGroceryDto> Groceries { get; set; }
        public List<CreateDungareeDto> Dungaries { get; set; }
        public List<CreateOtherCleaningMaterialDto> OtherCleaningMaterials { get; set; }
        public List<PsychologicalSupportDto> PsychologicalSupports { get; set; }
    }
}