using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Domain.Dungarees;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentre;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.Requests;

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
            var maskRequests = createRequestDto.MaskRequests != null ? MapToMaskRequests(createRequestDto.MaskRequests) : new List<MaskRequest>();
            var gloveRequests = createRequestDto.GloveRequests != null ? MapToGloveRequests(createRequestDto.GloveRequests) : new List<GloveRequest>();
            var groceryRequests = createRequestDto.Groceries != null ? MapToGroceryRequests(createRequestDto.Groceries) : new List<GroceryRequest>();
            var request = new Request
            {
                MedicalCentre = medicalCentre,
                MaskRequests = maskRequests,
                GlovesRequests = gloveRequests,
                GroceryRequestPositions = groceryRequests,
                OtherCleaningMaterialRequestPositions = createRequestDto?.OtherCleaningMaterials
                    .Select(x => new OtherCleaningMaterialRequest
                    {
                        OtherCleaningMaterialType = x.CreateOtherCleaningMaterialType,
                        Quantity = x.Quantity
                    }).ToList(),
                DungareeRequestPositions = createRequestDto?.Dungaries
                    .Select(x => new DungareeRequest
                    {
                        DungareeType = x.DungareeType,
                        Quantity = x.Quantity
                    }).ToList(),
                PsychologicalSupportRequestPositions = createRequestDto?.PsychologicalSupports
                    .Select(x => new PsychologicalSupportRequest
                    {
                        Description = x.Description
                    }).ToList()
            };

            foreach (var maskRequest in createRequestDto.GloveRequests)
            {
                request.GlovesRequests.Add(new GloveRequest()
                {
                    Quantity = maskRequest.Quantity,
                    GloveType = maskRequest.GloveType,
                    Description = maskRequest.Description
                });
            }

            await _requestRepository.SaveAsync(request);
            return request.Id;
        }

        private MedicalCentre MapToMedicalCentre(CreateRequestMedicalCentreDto createRequestMedicalCentreDto)
        {
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("City cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.Email))
                throw new ArgumentException("Email cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("Street cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("BuildingNumber cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("LegalName cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ArgumentException("PhoneNumber cannot be null");

            return new MedicalCentre
            {
                City = createRequestMedicalCentreDto.City,
                Email = createRequestMedicalCentreDto.Email,
                Street = createRequestMedicalCentreDto.Street,
                ApartmentNumber = createRequestMedicalCentreDto.ApartmentNumber,
                BuildingNumber = createRequestMedicalCentreDto.BuildingNumber,
                LegalName = createRequestMedicalCentreDto.LegalName,
                PhoneNumber = createRequestMedicalCentreDto.PhoneNumber
            };
        }

        private ICollection<MaskRequest> MapToMaskRequests(IEnumerable<CreateRequestMaskRequestDto> maskRequests)
        {
            var result = new List<MaskRequest>();
            foreach (var maskRequest in maskRequests)
            {
                if (maskRequest.MaskType == MaskType.Other && string.IsNullOrWhiteSpace(maskRequest.Description))
                    throw new InvalidOperationException("When MaskType is equal Other description cannot be empty");

                result.Add(new MaskRequest()
                {
                    Quantity = maskRequest.Quantity,
                    MaskType = maskRequest.MaskType,
                    Description = maskRequest.Description,
                    MaskSize = maskRequest.MaskSize
                });
            }

            return result;
        }

        private ICollection<GloveRequest> MapToGloveRequests(IEnumerable<CreateRequestGloveRequestDto> gloveRequests)
        {
            var result = new List<GloveRequest>();
            foreach (var gloveRequest in gloveRequests)
            {
                if (gloveRequest.GloveType == GloveType.Other && string.IsNullOrWhiteSpace(gloveRequest.Description))
                    throw new InvalidOperationException("When GloveType is equal Other description cannot be empty");

                result.Add(new GloveRequest()
                {
                    Quantity = gloveRequest.Quantity,
                    GloveType = gloveRequest.GloveType,
                    Description = gloveRequest.Description,
                    GloveSize = gloveRequest.GloveSize
                });
            }

            return result;
        }

        private ICollection<GroceryRequest> MapToGroceryRequests(IEnumerable<CreateGroceryDto> groceryDtos)
        {
            var result = new List<GroceryRequest>();
            foreach (var groceryRequest in groceryDtos)
            {
                if (groceryRequest.GroceryType == GroceryType.FirstType && string.IsNullOrWhiteSpace(groceryRequest.Description))
                    throw new InvalidOperationException("When GroceryType is equal FirstType description cannot be empty");

                result.Add(new GroceryRequest()
                {
                    Quantity = groceryRequest.Quantity,
                    Description = groceryRequest.Description,
                    GroceryType = groceryRequest.GroceryType
                });
            }

            return result;
        }
    }
}