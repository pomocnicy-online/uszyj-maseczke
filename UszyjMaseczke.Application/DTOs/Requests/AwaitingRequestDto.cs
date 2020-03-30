namespace UszyjMaseczke.Application.DTOs.Requests
{
    public class AwaitingRequestDto
    {
        public int RequestId { get; set; }
        public string MedicalCentreName { get; set; }
        public string MedicalCentreCity { get; set; }
        public AwaitingRequestDemandsDto Demands { get; set; }
    }
}