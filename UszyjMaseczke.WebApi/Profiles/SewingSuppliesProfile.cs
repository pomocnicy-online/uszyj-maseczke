using AutoMapper;
using UszyjMaseczke.Application.DTOs.SewingSuppliesRequest;
using UszyjMaseczke.Domain.SewingSupplies;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class SewingSuppliesProfile : Profile
    {
        public SewingSuppliesProfile()
        {
            CreateMap<SewingSuppliesRequest, SewingSuppliesRequestDto>();
            CreateMap<SewingSuppliesRequestDto, SewingSuppliesRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}