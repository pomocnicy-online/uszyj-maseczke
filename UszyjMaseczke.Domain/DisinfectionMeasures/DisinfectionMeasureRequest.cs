using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.DisinfectionMeasures
{
    public class DisinfectionMeasureRequest
    {
        public int Id { get; set; }
        public DisinfectionMeasureType DisinfectionMeasureType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}