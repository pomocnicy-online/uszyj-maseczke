using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Dungarees;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;

namespace UszyjMaseczke.Application.DTOs
{
    public class CreateRequestDto
    {
        public CreateRequestMedicalCentreDto MedicalCentre { get; set; }
        public IList<CreateRequestMaskRequestDto> MaskRequests { get; set; }
        public IList<CreateRequestGloveRequestDto> GloveRequests { get; set; }
        public List<CreateGroceryDto> Groceries { get; set; }
        public List<CreateDungareeDto> Dungaries { get; set; }
        public List<CreateOtherCleaningMaterialDto> OtherCleaningMaterials { get; set; }
        public List<PsychologicalSupportDto> PsychologicalSupports { get; set; }
    }
}