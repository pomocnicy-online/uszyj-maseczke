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
    public class OfferHelpPositionDto
    {
        public int RequestId { get; set; }
        public string AdditionalComment { get; set; }
        public MaskRequestDto Masks { get; set; }
        public GloveRequestDto Gloves { get; set; }
        public GroceryRequestDto Groceries { get; set; }
        public DisinfectionMeasureRequestDto DisinfectionMeasures { get; set; }
        public SuitRequestDto Suits { get; set; }
        public OtherCleaningMaterialRequestDto OtherCleaningMaterials { get; set; }
        public PsychologicalSupportDto PsychologicalSupport { get; set; }
        public SewingSuppliesRequestDto SewingSupplies { get; set; }
        public OtherRequestDto Others { get; set; }
        public PrintRequestDto Prints { get; set; }
        public DeliveryDto Delivery { get; set; }
    }
}