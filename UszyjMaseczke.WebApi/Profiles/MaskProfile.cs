using AutoMapper;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class MaskProfile : Profile
    {
        public MaskProfile()
        {
            CreateMap<MaskRequest, MaskRequestDto>();
            CreateMap<MaskRequestPosition, MaskRequestPositionDto>();
            CreateMap<MaskRequestDto, MaskRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<MaskRequestPositionDto, MaskRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}