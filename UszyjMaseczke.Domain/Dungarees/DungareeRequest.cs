using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.Dungarees
{
    public class DungareeRequest
    {
        public int Id { get; set; }
        public DungareeType DungareeType { get; set; }
        public int Quantity { get; set; }
        public Request Request { get; set; }
    }
}