namespace UszyjMaseczke.Domain.Masks
{
    public class MaskRequestPosition
    {
        public int Id { get; set; }
        public UsageType UsageType { get; set; }
        public int Quantity { get; set; }
        public Style Style { get; set; }
    }
}