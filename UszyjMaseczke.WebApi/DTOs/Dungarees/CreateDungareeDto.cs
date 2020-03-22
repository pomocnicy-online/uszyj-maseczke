using UszyjMaseczke.Domain.Dungarees;

namespace UszyjMaseczke.WebApi.DTOs.Dungarees
{
    public class CreateDungareeDto
    {
        public DungareeType DungareeType { get; set; }
        public int Quantity { get; set; }
    }
}