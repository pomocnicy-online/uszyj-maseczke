using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.WebApi.DTOs.OtherCleaningMaterials
{
    public class CreateOtherCleaningMaterialDto
    {
        public OtherCleaningMaterialType CreateOtherCleaningMaterialType { get; set; }
        public int Quantity { get; set; }
    }
}