using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Masks
{
    public class MaskRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TotalCount { get; set; }
        public virtual ICollection<MaskRequestPosition> Positions { get; set; }
    }
}