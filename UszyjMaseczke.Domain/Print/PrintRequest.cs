using System.Collections.Generic;

namespace UszyjMaseczke.Domain.Print
{
    public class PrintRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PrintRequestPosition> Positions { get; set; }
    }
}