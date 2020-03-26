using UszyjMaseczke.Domain.Print;

namespace UszyjMaseczke.Application.DTOs.Prints
{
    public class PrintRequestPositionDto
    {
        public PrintType PrintType { get; set; }
        public int Quantity { get; set; }
    }
}