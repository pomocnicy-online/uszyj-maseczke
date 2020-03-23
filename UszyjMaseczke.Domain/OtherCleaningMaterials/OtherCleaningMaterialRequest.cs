using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.OtherCleaningMaterials
{
    public class OtherCleaningMaterialRequest
    {
        public int Id { get; set; }
        public OtherCleaningMaterialType OtherCleaningMaterialType { get; set; }
        public int Quantity { get; set; }
        public Request Request { get; set; }
    }
}