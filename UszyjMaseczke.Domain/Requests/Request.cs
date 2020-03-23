using System.Collections.Generic;
using UszyjMaseczke.Domain.DisinfectionMeasures;
using UszyjMaseczke.Domain.Dungarees;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.PsychologicalSupport;

namespace UszyjMaseczke.Domain.Requests
{
    public class Request
    {
        public int Id { get; set; }
        public virtual MedicalCentre.MedicalCentre MedicalCentre { get; set; }
        public virtual ICollection<MaskRequest> MaskRequests { get; set; }
        public virtual ICollection<GloveRequest> GlovesRequests { get; set; }
        public virtual ICollection<GroceryRequest> GroceryRequestPositions { get; set; }
        public virtual ICollection<OtherCleaningMaterialRequest> OtherCleaningMaterialRequestPositions { get; set; }
        public virtual ICollection<PsychologicalSupportRequest> PsychologicalSupportRequestPositions { get; set; }
        public virtual ICollection<DungareeRequest> DungareeRequestPositions { get; set; }
        public virtual ICollection<DisinfectionMeasureRequest> DisinfectionMeasureRequestPositions { get; set; }

    }
}