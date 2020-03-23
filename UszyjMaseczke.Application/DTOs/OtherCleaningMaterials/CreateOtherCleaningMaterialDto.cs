using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.Application.DTOs.OtherCleaningMaterials
{
    public class CreateOtherCleaningMaterialDto
    {
        public OtherCleaningMaterialType CreateOtherCleaningMaterialType { get; set; }
        public int Quantity { get; set; }
    }
}