using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Application.DTOs
{
    public class CreateRequestMaskRequestDto
    {
        public MaskType MaskType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public MaskSize MaskSize { get; set; }
    }
}