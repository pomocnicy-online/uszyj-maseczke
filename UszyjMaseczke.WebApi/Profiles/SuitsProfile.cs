using AutoMapper;
using UszyjMaseczke.Application.DTOs.Suits;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class SuitsProfile : Profile
    {
        public SuitsProfile()
        {
            CreateMap<SuitRequest, SuitRequestDto>();
            CreateMap<SuitRequestPosition, SuitRequestPositionDto>();
            CreateMap<SuitRequestDto, SuitRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SuitRequestPositionDto, SuitRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}