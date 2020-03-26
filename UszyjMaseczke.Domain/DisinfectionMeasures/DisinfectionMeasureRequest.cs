using System.Collections.Generic;

namespace UszyjMaseczke.Domain.DisinfectionMeasures
{
    public class DisinfectionMeasureRequest
    {
        public int Id { get; set; }
        public virtual ICollection<DisinfectionMeasureRequestPosition> Positions { get; set; }
        public int TotalCount { get; set; }
    }
}