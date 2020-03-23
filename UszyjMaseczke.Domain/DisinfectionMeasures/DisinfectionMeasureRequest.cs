using System.Collections.Generic;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.DisinfectionMeasures
{
    public class DisinfectionMeasureRequest
    {
        public int Id { get; set; }
        public virtual ICollection<DisinfectionMeasureRequestPosition> Positions { get; set; }
    }
}