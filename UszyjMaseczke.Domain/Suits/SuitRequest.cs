using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Suits
{
    public class SuitRequest
    {
        public int Id { get; set; }
        public virtual ICollection<SuitRequestPosition> Positions { get; set; }
        public string Description { get; set; }
    }
}