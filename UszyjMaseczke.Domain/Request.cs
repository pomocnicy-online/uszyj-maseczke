using System.Collections.Generic;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Domain
{
    public class Request
    {
        public int Id { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
        public virtual ICollection<MaskRequest> MaskRequests { get; set; }
    }
}