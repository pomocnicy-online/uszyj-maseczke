using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.DTOs.DesinfectionMesures;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Application.DTOs.Others;
using UszyjMaseczke.Application.DTOs.Prints;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Application.DTOs.SewingSuppliesRequest;
using UszyjMaseczke.Application.DTOs.Suits;
using UszyjMaseczke.Domain.DisinfectionMeasures;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentre;
using UszyjMaseczke.Domain.Other;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.Print;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Domain.SewingSupplies;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Application.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<int> CreateRequestAsync(CreateRequestDto createRequestDto)
        {
            var medicalCentre = MapToMedicalCentre(createRequestDto.MedicalCentre);
            var maskRequests = createRequestDto.MaskRequest != null ? MapToMaskRequests(createRequestDto.MaskRequest) : default;
            var gloveRequests = createRequestDto.GloveRequest != null ? MapToGloveRequests(createRequestDto.GloveRequest) : default;
            var groceryRequests = createRequestDto.GroceryRequest != null ? MapToGroceryRequests(createRequestDto.GroceryRequest) : default;
            var disinfection = createRequestDto.DisinfectionMeasureRequest != null ? MapToDisinfectionMeasureRequest(createRequestDto.DisinfectionMeasureRequest) : default;
            var suits = createRequestDto.SuitRequest != null ? MapToSuitRequests(createRequestDto.SuitRequest) : default;
            var otherCleaningMaterialRequest = createRequestDto.OtherCleaningMaterialRequest != null
                ? MapToOtherCleaningMaterialRequest(createRequestDto.OtherCleaningMaterialRequest)
                : default;
            var psychologicalSupportRequest = createRequestDto.PsychologicalSupportRequest != null
                ? MapToPsychologicalSupportRequest(createRequestDto.PsychologicalSupportRequest)
                : default;
            var sewingSuppliesRequest = createRequestDto.SewingSuppliesRequest != null ? MapToSewingSuppliesRequest(createRequestDto.SewingSuppliesRequest) : default;
            var otherRequest = createRequestDto.OtherRequest != null ? MapToOtherRequest(createRequestDto.OtherRequest) : default;
            var printRequests = createRequestDto.PrintRequest != null ? MapToPrintRequests(createRequestDto.PrintRequest) : default;

            var request = new Request
            {
                MedicalCentre = medicalCentre,
                MaskRequest = maskRequests,
                GlovesRequest = gloveRequests,
                GroceryRequest = groceryRequests,
                DisinfectionMeasureRequest = disinfection,
                SuitRequest = suits,
                OtherCleaningMaterialRequest = otherCleaningMaterialRequest,
                PsychologicalSupportRequest = psychologicalSupportRequest,
                SewingSuppliesRequest = sewingSuppliesRequest,
                OtherRequest = otherRequest,
                PrintRequest = printRequests
            };

            await _requestRepository.SaveAsync(request);
            return request.Id;
        }

        private MedicalCentre MapToMedicalCentre(CreateRequestMedicalCentreDto createRequestMedicalCentreDto)
        {
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("City cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.Email))
                throw new ArgumentException("Email cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.Street))
                throw new ArgumentException("Street cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.BuildingNumber))
                throw new ArgumentException("BuildingNumber cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.LegalName))
                throw new ArgumentException("LegalName cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.PhoneNumber))
                throw new ArgumentException("PhoneNumber cannot be null");

            return new MedicalCentre
            {
                City = createRequestMedicalCentreDto.City,
                Email = createRequestMedicalCentreDto.Email,
                Street = createRequestMedicalCentreDto.Street,
                ApartmentNumber = createRequestMedicalCentreDto.ApartmentNumber,
                BuildingNumber = createRequestMedicalCentreDto.BuildingNumber,
                LegalName = createRequestMedicalCentreDto.LegalName,
                PhoneNumber = createRequestMedicalCentreDto.PhoneNumber,
                PostalCode = createRequestMedicalCentreDto.PostalCode
            };
        }


        private static MaskRequest MapToMaskRequests(MaskRequestDto maskRequest)
        {
            var result = new MaskRequest();
            result.Description = maskRequest.Description;
            result.TotalCount = 0;
            result.Positions = new List<MaskRequestPosition>();
            foreach (var request in maskRequest.Positions)
            {
                result.Positions.Add(new MaskRequestPosition
                {
                    Quantity = request.Quantity,
                    Style = request.Style,
                    UsageType = request.UsageType
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private GloveRequest MapToGloveRequests(GloveRequestDto gloveRequests)
        {
            var result = new GloveRequest();
            result.Description = gloveRequests.Description;
            result.TotalCount = 0;
            result.Positions = new List<GloveRequestPosition>();
            foreach (var request in gloveRequests.Positions)
            {
                result.Positions.Add(new GloveRequestPosition
                {
                    Quantity = request.Quantity,
                    Material = request.Material,
                    Size = request.Size
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private static GroceryRequest MapToGroceryRequests(GroceryRequestDto groceryRequest)
        {
            var result = new GroceryRequest();
            result.Positions = new List<GroceryRequestPosition>();
            result.TotalCount = 0;
            foreach (var request in groceryRequest.Positions)
            {
                result.Positions.Add(new GroceryRequestPosition
                {
                    Quantity = request.Quantity,
                    Description = request.Description
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private static DisinfectionMeasureRequest MapToDisinfectionMeasureRequest(DisinfectionMeasureRequestDto groceryRequest)
        {
            var result = new DisinfectionMeasureRequest();
            result.Positions = new List<DisinfectionMeasureRequestPosition>();
            result.TotalCount = 0;
            foreach (var request in groceryRequest.Positions)
            {
                result.Positions.Add(new DisinfectionMeasureRequestPosition
                {
                    Quantity = request.Quantity,
                    Description = request.Description
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private SuitRequest MapToSuitRequests(SuitRequestDto suitRequests)
        {
            var result = new SuitRequest();
            result.Description = suitRequests.Description;
            result.TotalCount = 0;
            result.Positions = new List<SuitRequestPosition>();
            foreach (var request in suitRequests.Positions)
            {
                result.Positions.Add(new SuitRequestPosition
                {
                    Quantity = request.Quantity,
                    Size = request.Size
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private static OtherCleaningMaterialRequest MapToOtherCleaningMaterialRequest(OtherCleaningMaterialRequestDto otherCleaningMaterialRequestDto)
        {
            var result = new OtherCleaningMaterialRequest();
            result.Positions = new List<OtherCleaningMaterialRequestPosition>();
            result.TotalCount = 0;
            foreach (var request in otherCleaningMaterialRequestDto.Positions)
            {
                result.Positions.Add(new OtherCleaningMaterialRequestPosition
                {
                    Quantity = request.Quantity,
                    Description = request.Description
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }

        private static PsychologicalSupportRequest MapToPsychologicalSupportRequest(PsychologicalSupportDto psychologicalSupportDto)
        {
            var result = new PsychologicalSupportRequest();
            result.Description = psychologicalSupportDto.Description;
            return result;
        }

        private static SewingSuppliesRequest MapToSewingSuppliesRequest(SewingSuppliesRequestDto sewingSuppliesRequestDto)
        {
            var result = new SewingSuppliesRequest();
            result.Description = sewingSuppliesRequestDto.Description;
            return result;
        }

        private static OtherRequest MapToOtherRequest(OtherRequestDto otherRequestDto)
        {
            var result = new OtherRequest();
            result.Description = otherRequestDto.Description;
            return result;
        }

        private PrintRequest MapToPrintRequests(PrintRequestDto printRequest)
        {
            var result = new PrintRequest();
            result.Description = printRequest.Description;
            result.TotalCount = 0;
            result.Positions = new List<PrintRequestPosition>();
            foreach (var request in printRequest.Positions)
            {
                result.Positions.Add(new PrintRequestPosition
                {
                    Quantity = request.Quantity,
                    PrintType = request.PrintType
                });
                result.TotalCount += request.Quantity;
            }

            return result;
        }
    }
}