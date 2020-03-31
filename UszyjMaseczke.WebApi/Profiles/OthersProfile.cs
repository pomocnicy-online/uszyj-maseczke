using AutoMapper;
using UszyjMaseczke.Application.DTOs.Others;
using UszyjMaseczke.Domain.Other;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class OthersProfile : Profile
    {
        public OthersProfile()
        {
            CreateMap<OtherRequest, OtherRequestDto>();
            CreateMap<OtherRequestDto, OtherRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}