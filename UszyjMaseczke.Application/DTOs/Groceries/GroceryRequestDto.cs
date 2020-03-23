using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.Application.DTOs.Groceries
{
    public class GroceryRequestDto
    {
        public IEnumerable<GroceryRequestPositionDto> Positions { get; set; }
    }
}