using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs.Dungarees
{
    public class CreateRequestDungariesDto
    {
        public List<CreateDungareeDto> Dungaries { get; set; }
    }
}