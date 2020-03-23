using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Gloves
{
    public class GloveRequest
    {
        public int Id { get; set; }
        public GloveType GloveType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public GloveSize GloveSize { get; set; }
    }
}