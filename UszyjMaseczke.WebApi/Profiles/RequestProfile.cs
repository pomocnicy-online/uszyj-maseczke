using AutoMapper;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Application.DTOs.Requests;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.WebApi.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, AwaitingRequestDto>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MedicalCentreCity, opt => opt.MapFrom(src => src.MedicalCentre.City))
                .ForMember(dest => dest.MedicalCentreName, opt => opt.MapFrom(src => src.MedicalCentre.LegalName))
                .ForMember(dest => dest.Demands.Masks, opt => opt.MapFrom(src => src.MaskRequest))
                .ForMember(dest => dest.Demands.Gloves, opt => opt.MapFrom(src => src.GlovesRequest))
                .ForMember(dest => dest.Demands.Groceries, opt => opt.MapFrom(src => src.GroceryRequest))
                .ForMember(dest => dest.Demands.Others, opt => opt.MapFrom(src => src.OtherRequest))
                .ForMember(dest => dest.Demands.Prints, opt => opt.MapFrom(src => src.PrintRequest))
                .ForMember(dest => dest.Demands.Suits, opt => opt.MapFrom(src => src.SuitRequest))
                .ForMember(dest => dest.Demands.DisinfectionMeasures, opt => opt.MapFrom(src => src.DisinfectionMeasureRequest))
                .ForMember(dest => dest.Demands.PsychologicalSupport, opt => opt.MapFrom(src => src.PsychologicalSupportRequest))
                .ForMember(dest => dest.Demands.SewingSupplies, opt => opt.MapFrom(src => src.SewingSuppliesRequest))
                .ForMember(dest => dest.Demands.OtherCleaningMaterials, opt => opt.MapFrom(src => src.OtherCleaningMaterialRequest));
        }
    }

    public class MaskProfile : Profile
    {
        public MaskProfile()
        {
            CreateMap<MaskRequest, MaskRequestDto>();
            CreateMap<MaskRequestPosition, MaskRequestPositionDto>();
        }
    }

    public class GloveProfile : Profile
    {
        public GloveProfile()
        {
            CreateMap<GloveRequest, GloveRequestDto>();
            CreateMap<GloveRequestPosition, GloveRequestPositionDto>();
        }
    }

    public class GroceriesProfile : Profile
    {
        public GroceriesProfile()
        {
            CreateMap<GroceryRequest, GroceryRequestDto>();
            CreateMap<GroceryRequestPosition, GroceryRequestPositionDto>();
        }
    }
}