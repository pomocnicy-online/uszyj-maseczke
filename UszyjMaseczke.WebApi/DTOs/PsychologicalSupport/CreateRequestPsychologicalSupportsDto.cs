using System.Collections.Generic;

namespace UszyjMaseczke.WebApi.DTOs.PsychologicalSupport
{
    public class CreateRequestPsychologicalSupportsDto
    {
        public List<PsychologicalSupportDto> PsychologicalSupports { get; set; }
    }
}