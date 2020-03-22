using System.Collections.Generic;
using UszyjMaseczke.Domain.Dungarees;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.PsychologicalSupport;

namespace UszyjMaseczke.Domain
{
    public class Request
    {
        public int Id { get; set; }
        public MedicalCentre MedicalCentre { get; set; }
        
        public virtual ICollection<GroceryRequest> GroceryRequestPositions { get; set; }
        public virtual ICollection<OtherCleaningMaterialRequest> OtherCleaningMaterialRequestPositions { get; set; }
        public virtual ICollection<PsychologicalSupportRequest> PsychologicalSupportRequestPositions { get; set; }
        public virtual ICollection<DungareeRequest> DungareeRequestPositions { get; set; }
    }
}