using UszyjMaseczke.Application.DTOs.DesinfectionMesures;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Application.DTOs.Others;
using UszyjMaseczke.Application.DTOs.Prints;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Application.DTOs.SewingSuppliesRequest;
using UszyjMaseczke.Application.DTOs.Suits;

namespace UszyjMaseczke.Application.DTOs
{
    public class CreateRequestDto
    {
        public CreateRequestMedicalCentreDto MedicalCentre { get; set; }
        public MaskRequestDto MaskRequest { get; set; }
        public GloveRequestDto GloveRequest { get; set; }
        public GroceryRequestDto GroceryRequest { get; set; }
        public DisinfectionMeasureRequestDto DisinfectionMeasureRequest { get; set; }
        public SuitRequestDto SuitRequest { get; set; }
        public OtherCleaningMaterialRequestDto OtherCleaningMaterialRequest { get; set; }
        public PsychologicalSupportDto PsychologicalSupportRequest { get; set; }
        public SewingSuppliesRequestDto SewingSuppliesRequest { get; set; }
        public OtherRequestDto OtherRequest { get; set; }
        public PrintRequestDto PrintRequest { get; set; }
    }
}