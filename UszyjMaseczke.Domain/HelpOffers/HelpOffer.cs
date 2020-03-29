using UszyjMaseczke.Domain.DisinfectionMeasures;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Helpers;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Other;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.Print;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Domain.SewingSupplies;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Domain.HelpOffers
{
    public class HelpOffer
    {
        public int Id { get; set; }
        public virtual Request Request { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
        public virtual Helper Helper { get; set; }
        public virtual MaskRequest MaskSupplies { get; set; }
        public virtual GloveRequest GloveSupplies { get; set; }
        public virtual DisinfectionMeasureRequest DisinfectionMeasureSupplies { get; set; }
        public virtual SuitRequest SuitSupplies { get; set; }
        public virtual GroceryRequest GrocerySupplies { get; set; }
        public virtual OtherCleaningMaterialRequest OtherCleaningMaterialSupplies { get; set; }
        public virtual PsychologicalSupportRequest PsychologicalSupportSupplies { get; set; }
        public virtual SewingSuppliesRequest SewingSuppliesSupplies { get; set; }
        public virtual OtherRequest OtherSupplies { get; set; }
        public virtual PrintRequest PrintSupplies { get; set; }
    }
}