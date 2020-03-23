using System.Collections.Generic;

namespace UszyjMaseczke.Application.DTOs.Prints
{
    public class PrintRequestDto
    {
        public string Description { get; set; }
        public IEnumerable<PrintRequestPositionDto> Positions { get; set; }
    }
}