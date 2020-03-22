namespace UszyjMaseczke.Domain.DisinfectionMeasures
{
    public class DisinfectionMeasureRequest
    {
        public int Id { get; set; }
        public DisinfectionMeasureType DisinfectionMeasureType { get; set; }
        public int Quantity { get; set; }
        public Request Request { get; set; }
    }
}