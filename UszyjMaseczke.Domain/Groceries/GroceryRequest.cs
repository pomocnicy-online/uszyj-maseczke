using System.Collections.Generic;
using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.Domain.Groceries
{
    public class GroceryRequest
    {
        public int Id { get; set; }
        public virtual ICollection<GroceryRequestPosition> Positions { get; set; }
    }
}