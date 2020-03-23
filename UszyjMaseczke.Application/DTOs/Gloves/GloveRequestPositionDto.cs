using UszyjMaseczke.Domain;

namespace UszyjMaseczke.Application.DTOs.Gloves
{
    public class GloveRequestPositionDto
    {
        public Material Material { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
    }
}