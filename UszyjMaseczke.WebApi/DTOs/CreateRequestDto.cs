using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestDto
    {
        public CreateRequestMedicalCentreDto MedicalCentre { get; set; }
        public IList<CreateRequestMaskRequestPositionDto> MaskRequests { get; set; }
    }
}