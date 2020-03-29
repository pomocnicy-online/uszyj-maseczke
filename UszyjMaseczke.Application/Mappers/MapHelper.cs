using System.Collections.Generic;
using UszyjMaseczke.Application.DTOs.DesinfectionMesures;
using UszyjMaseczke.Application.DTOs.Gloves;
using UszyjMaseczke.Application.DTOs.Groceries;
using UszyjMaseczke.Application.DTOs.Helpers;
using UszyjMaseczke.Application.DTOs.Masks;
using UszyjMaseczke.Application.DTOs.MedicalCentres;
using UszyjMaseczke.Application.DTOs.OtherCleaningMaterials;
using UszyjMaseczke.Application.DTOs.Others;
using UszyjMaseczke.Application.DTOs.Prints;
using UszyjMaseczke.Application.DTOs.PsychologicalSupport;
using UszyjMaseczke.Application.DTOs.SewingSuppliesRequest;
using UszyjMaseczke.Application.DTOs.Suits;
using UszyjMaseczke.Domain.DisinfectionMeasures;
using UszyjMaseczke.Domain.Exceptions;
using UszyjMaseczke.Domain.Gloves;
using UszyjMaseczke.Domain.Groceries;
using UszyjMaseczke.Domain.Helpers;
using UszyjMaseczke.Domain.Masks;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Other;
using UszyjMaseczke.Domain.OtherCleaningMaterials;
using UszyjMaseczke.Domain.Print;
using UszyjMaseczke.Domain.PsychologicalSupport;
using UszyjMaseczke.Domain.SewingSupplies;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Application.Mappers
{
    public static class MapHelper
    {
        public static MedicalCentre MapToMedicalCentre(CreateRequestMedicalCentreDto createRequestMedicalCentreDto)
        {
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.City))
                throw new ValidationException("City cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.Email))
                throw new ValidationException("Email cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.Street))
                throw new ValidationException("Street cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.BuildingNumber))
                throw new ValidationException("BuildingNumber cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.LegalName))
                throw new ValidationException("LegalName cannot be null");
            if (string.IsNullOrWhiteSpace(createRequestMedicalCentreDto.PhoneNumber))
                throw new ValidationException("PhoneNumber cannot be null");

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


        public static MaskRequest MapToMaskRequests(MaskRequestDto maskRequest)
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

        public static GloveRequest MapToGloveRequests(GloveRequestDto gloveRequests)
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

        public static GroceryRequest MapToGroceryRequests(GroceryRequestDto groceryRequest)
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

        public static DisinfectionMeasureRequest MapToDisinfectionMeasureRequest(DisinfectionMeasureRequestDto groceryRequest)
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

        public static SuitRequest MapToSuitRequests(SuitRequestDto suitRequests)
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

        public static OtherCleaningMaterialRequest MapToOtherCleaningMaterialRequest(OtherCleaningMaterialRequestDto otherCleaningMaterialRequestDto)
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

        public static PsychologicalSupportRequest MapToPsychologicalSupportRequest(PsychologicalSupportDto psychologicalSupportDto)
        {
            var result = new PsychologicalSupportRequest();
            result.Description = psychologicalSupportDto.Description;
            return result;
        }

        public static SewingSuppliesRequest MapToSewingSuppliesRequest(SewingSuppliesRequestDto sewingSuppliesRequestDto)
        {
            var result = new SewingSuppliesRequest();
            result.Description = sewingSuppliesRequestDto.Description;
            return result;
        }

        public static OtherRequest MapToOtherRequest(OtherRequestDto otherRequestDto)
        {
            var result = new OtherRequest();
            result.Description = otherRequestDto.Description;
            return result;
        }

        public static PrintRequest MapToPrintRequests(PrintRequestDto printRequest)
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

        public static Helper MapToHelper(CreateHelperDto helperDto)
        {
            if (helperDto == null)
                throw new ValidationException("Helper cannot be null");
            if (string.IsNullOrWhiteSpace(helperDto.FirstName))
                throw new ValidationException("First name cannot be null");
            if (string.IsNullOrWhiteSpace(helperDto.Email))
                throw new ValidationException("Email cannot be null");
            if (string.IsNullOrWhiteSpace(helperDto.PhoneNumber))
                throw new ValidationException("Phone number cannot be null");
            var result = new Helper();
            result.Email = helperDto.Email;
            result.FirstName = helperDto.FirstName;
            result.PhoneNumber = helperDto.PhoneNumber;
            return result;
        }
    }
}