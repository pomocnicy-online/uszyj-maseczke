using AutoMapper;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class GroceriesProfile : Profile
    {
        public GroceriesProfile()
        {
            CreateMap<GroceryRequest, GroceryRequestDto>();
            CreateMap<GroceryRequestPosition, GroceryRequestPositionDto>();
            CreateMap<GroceryRequestDto, GroceryRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<GroceryRequestPositionDto, GroceryRequestPosition>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}