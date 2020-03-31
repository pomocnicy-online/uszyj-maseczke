using AutoMapper;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class OtherCleaningMaterialsProfile : Profile
    {
        public OtherCleaningMaterialsProfile()
        {
            CreateMap<OtherCleaningMaterialRequest, OtherCleaningMaterialRequestDto>();
            CreateMap<OtherCleaningMaterialRequestPosition, OtherCleaningMaterialRequestPositionDto>();
            CreateMap<OtherCleaningMaterialRequestDto, OtherCleaningMaterialRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<OtherCleaningMaterialRequestPositionDto, OtherCleaningMaterialRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}