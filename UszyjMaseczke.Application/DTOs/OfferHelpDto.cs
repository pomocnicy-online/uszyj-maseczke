using UszyjMaseczke.Application.DTOs.DesinfectionMesures;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.Helpers;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Application.DTOs.Others;
using UszyjMaseczke.Application.DTOs.Prints;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Application.DTOs.SewingSuppliesRequest;
using UszyjMaseczke.Application.DTOs.Suits;

namespace UszyjMaseczke.Application.DTOs
{
    public class OfferHelpDto
    {
        public int MedicalCentreId { get; set; }
        public int RequestId { get; set; }
        public CreateHelperDto Helper { get; set; }
        public MaskRequestDto MaskSupplies { get; set; }
        public GloveRequestDto GloveSupplies { get; set; }
        public GroceryRequestDto GrocerySupplies { get; set; }
        public DisinfectionMeasureRequestDto DisinfectionMeasureSupplies { get; set; }
        public SuitRequestDto SuitSupplies { get; set; }
        public OtherCleaningMaterialRequestDto OtherCleaningMaterialSupplies { get; set; }
        public PsychologicalSupportDto PsychologicalSupportSupplies { get; set; }
        public SewingSuppliesRequestDto SewingSuppliesSupplies { get; set; }
        public OtherRequestDto OtherSupplies { get; set; }
        public PrintRequestDto PrintSupplies { get; set; }
    }
}