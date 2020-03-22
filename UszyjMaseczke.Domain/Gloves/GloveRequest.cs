using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Gloves
{
    public class GloveRequest
    {
        public int Id { get; set; }
        public IList<GloveRequestPosition> GloveRequests { get; set; }
    }
}