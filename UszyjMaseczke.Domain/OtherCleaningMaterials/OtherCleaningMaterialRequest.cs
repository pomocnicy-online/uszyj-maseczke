using System.Collections.Generic;

namespace UszyjMaseczke.Domain.OtherCleaningMaterials
{
    public class OtherCleaningMaterialRequest
    {
        public int Id { get; set; }
        public virtual ICollection<OtherCleaningMaterialRequestPosition> Positions { get; set; }
        public int TotalCount { get; set; }
    }
}