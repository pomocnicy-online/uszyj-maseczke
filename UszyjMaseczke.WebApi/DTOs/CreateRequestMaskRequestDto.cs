using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestMaskRequestDto
    {
        public MaskType MaskType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}