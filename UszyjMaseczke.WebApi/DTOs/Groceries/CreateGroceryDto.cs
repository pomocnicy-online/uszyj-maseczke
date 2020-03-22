using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.WebApi.DTOs.Groceries
{
    public class CreateGroceryDto
    {
        public GroceryType GroceryType { get; set; }
        public int Quantity { get; set; }
    }
}