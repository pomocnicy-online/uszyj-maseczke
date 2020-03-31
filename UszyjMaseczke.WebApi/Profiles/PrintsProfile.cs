using AutoMapper;
using UszyjMaseczke.Application.DTOs.Prints;
using UszyjMaseczke.Domain.Print;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class PrintsProfile : Profile
    {
        public PrintsProfile()
        {
            CreateMap<PrintRequest, PrintRequestDto>();
            CreateMap<PrintRequestPosition, PrintRequestPositionDto>();
            CreateMap<PrintRequestDto, PrintRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<PrintRequestPositionDto, PrintRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}