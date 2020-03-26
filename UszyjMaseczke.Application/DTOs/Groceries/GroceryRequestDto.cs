using System.Collections.Generic;

namespace UszyjMaseczke.Application.DTOs.Groceries
{
    public class GroceryRequestDto
    {
        public IEnumerable<GroceryRequestPositionDto> Positions { get; set; }
    }
}