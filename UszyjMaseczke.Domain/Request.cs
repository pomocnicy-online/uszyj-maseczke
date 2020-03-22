using System.Collections.Generic;
using UszyjMaseczke.Domain.Dungarees;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Domain
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
    }
}