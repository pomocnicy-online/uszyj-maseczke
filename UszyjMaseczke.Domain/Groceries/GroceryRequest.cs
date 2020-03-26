using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Groceries
{
    public class GroceryRequest
    {
        public int Id { get; set; }
        public virtual ICollection<GroceryRequestPosition> Positions { get; set; }
        public int TotalCount { get; set; }
    }
}