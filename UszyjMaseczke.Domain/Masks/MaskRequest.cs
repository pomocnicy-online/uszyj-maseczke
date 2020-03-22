namespace UszyjMaseczke.Domain.Masks
{
    public class MaskRequest
    {
        public int Id { get; set; }
        public MaskType MaskType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}