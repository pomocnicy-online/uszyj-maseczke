using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.Application.DTOs.Groceries
{
    public class CreateGroceryDto
    {
        public GroceryType GroceryType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}