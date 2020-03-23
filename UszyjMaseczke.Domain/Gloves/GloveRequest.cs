using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Gloves
{
    public class GloveRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GloveRequestPosition> Positions { get; set; }
    }
}