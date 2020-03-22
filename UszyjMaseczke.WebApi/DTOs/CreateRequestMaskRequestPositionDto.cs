using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestMaskRequestPositionDto
    {
        public MaskType MaskType { get; set; }
        public int Quantity { get; set; }
    }
}