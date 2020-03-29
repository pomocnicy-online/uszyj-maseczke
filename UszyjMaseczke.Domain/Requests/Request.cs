using UszyjMaseczke.Domain.DisinfectionMeasures;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Other;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.Print;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.SewingSupplies;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Domain.Requests
{
    public class Request
    {
        public int Id { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
        public virtual MaskRequest MaskRequest { get; set; }
        public virtual GloveRequest GlovesRequest { get; set; }
        public virtual DisinfectionMeasureRequest DisinfectionMeasureRequest { get; set; }
        public virtual SuitRequest SuitRequest { get; set; }
        public virtual GroceryRequest GroceryRequest { get; set; }
        public virtual OtherCleaningMaterialRequest OtherCleaningMaterialRequest { get; set; }
        public virtual PsychologicalSupportRequest PsychologicalSupportRequest { get; set; }
        public virtual SewingSuppliesRequest SewingSuppliesRequest { get; set; }
        public virtual OtherRequest OtherRequest { get; set; }
        public virtual PrintRequest PrintRequest { get; set; }
    }
}