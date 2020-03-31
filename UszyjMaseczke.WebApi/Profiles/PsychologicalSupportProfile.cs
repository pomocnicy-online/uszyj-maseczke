using AutoMapper;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Domain.PsychologicalSupport;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class PsychologicalSupportProfile : Profile
    {
        public PsychologicalSupportProfile()
        {
            CreateMap<PsychologicalSupportRequest, PsychologicalSupportDto>();
            CreateMap<PsychologicalSupportDto, PsychologicalSupportRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}