using UszyjMaseczke.Domain.Gloves;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestGloveRequestDto
    {
        public GloveType GloveType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

    }
}