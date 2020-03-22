using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs
{
    public class CreateRequestDto
    {
        public CreateRequestMedicalCentreDto MedicalCentre { get; set; }
        public IList<CreateRequestMaskRequestDto> MaskRequests { get; set; }
        public IList<CreateRequestGloveRequestDto> GloveRequests { get; set; }

    }
}