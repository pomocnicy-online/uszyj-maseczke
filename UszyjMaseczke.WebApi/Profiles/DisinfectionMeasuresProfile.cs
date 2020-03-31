using AutoMapper;
using UszyjMaseczke.Application.DTOs.DesinfectionMesures;
using UszyjMaseczke.Domain.DisinfectionMeasures;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class DisinfectionMeasuresProfile : Profile
    {
        public DisinfectionMeasuresProfile()
        {
            CreateMap<DisinfectionMeasureRequest, DisinfectionMeasureRequestDto>();
            CreateMap<DisinfectionMeasureRequestPosition, DisinfectionMeasureRequestPositionDto>();
            CreateMap<DisinfectionMeasureRequestDto, DisinfectionMeasureRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<DisinfectionMeasureRequestPositionDto, DisinfectionMeasureRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}