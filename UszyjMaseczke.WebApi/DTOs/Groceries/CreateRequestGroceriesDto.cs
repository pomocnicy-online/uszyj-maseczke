using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs.Groceries
{
    public class CreateRequestGroceriesDto
    {
        public List<CreateGroceryDto> Groceries { get; set; }
    }
}