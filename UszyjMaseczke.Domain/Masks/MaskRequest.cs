using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Masks
{
    public class MaskRequest
    {
        public int Id { get; set; }
        public IList<MaskRequestPosition> MaskRequests { get; set; }
    }
}