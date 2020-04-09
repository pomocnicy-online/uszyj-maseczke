using AutoMapper;
using UszyjMaseczke.Application.DTOs.Requests;
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
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src));

            CreateMap<Request, AwaitingRequestDemandsDto>()
                .ForMember(dest => dest.Gloves, opt => opt.MapFrom(src => src.GlovesRequest))
                .ForMember(dest => dest.Masks, opt => opt.MapFrom(src => src.MaskRequest))
                .ForMember(dest => dest.Groceries, opt => opt.MapFrom(src => src.GroceryRequest))
                .ForMember(dest => dest.DisinfectionMeasures, opt => opt.MapFrom(src => src.DisinfectionMeasureRequest))
                .ForMember(dest => dest.Suits, opt => opt.MapFrom(src => src.SuitRequest))
                .ForMember(dest => dest.OtherCleaningMaterials, opt => opt.MapFrom(src => src.OtherCleaningMaterialRequest))
                .ForMember(dest => dest.PsychologicalSupport, opt => opt.MapFrom(src => src.PsychologicalSupportRequest))
                .ForMember(dest => dest.SewingSupplies, opt => opt.MapFrom(src => src.SewingSuppliesRequest))
                .ForMember(dest => dest.Others, opt => opt.MapFrom(src => src.OtherRequest))
                .ForMember(dest => dest.Prints, opt => opt.MapFrom(src => src.PrintRequest))
                .ForMember(dest => dest.Delivery, opt => opt.MapFrom(src => src.DeliveryRequest));
        }
    }
}