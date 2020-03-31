using AutoMapper;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Domain.Gloves;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class GloveProfile : Profile
    {
        public GloveProfile()
        {
            CreateMap<GloveRequest, GloveRequestDto>();
            CreateMap<GloveRequestPosition, GloveRequestPositionDto>();
            CreateMap<GloveRequestDto, GloveRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<GloveRequestPositionDto, GloveRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}