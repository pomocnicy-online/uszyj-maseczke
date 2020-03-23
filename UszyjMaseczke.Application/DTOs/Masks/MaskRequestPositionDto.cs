using UszyjMaseczke.Domain;

namespace UszyjMaseczke.Application.DTOs.Masks
{
    public class MaskRequestPositionDto
    {
        public UsageType UsageType { get; set; }
        public int Quantity { get; set; }
        public Style Style { get; set; }
    }
}