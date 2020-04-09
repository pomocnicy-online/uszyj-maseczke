using AutoMapper;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Domain.PsychologicalSupport;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}