using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.Groceries
{
    public class GroceryRequest
    {
        public int Id { get; set; }
        public GroceryType GroceryType { get; set; }
        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}