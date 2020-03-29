using System;
using System.Threading;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.Mappers;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Application.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMessageService _messageService;

        public RequestService(IRequestRepository requestRepository, IMessageService messageService)
        {
            _requestRepository = requestRepository;
            _messageService = messageService;
        }

        public async Task<int> CreateRequestAsync(CreateRequestDto createRequestDto, CancellationToken cancellationToken)
        {
            var medicalCentre = MapHelper.MapToMedicalCentre(createRequestDto.MedicalCentre);
            var maskRequests = createRequestDto.Masks != null ? MapHelper.MapToMaskRequests(createRequestDto.Masks) : default;
            var gloveRequests = createRequestDto.Gloves != null ? MapHelper.MapToGloveRequests(createRequestDto.Gloves) : default;
            var groceryRequests = createRequestDto.Groceries != null ? MapHelper.MapToGroceryRequests(createRequestDto.Groceries) : default;
            var disinfection = createRequestDto.DisinfectionMeasures != null
                ? MapHelper.MapToDisinfectionMeasureRequest(createRequestDto.DisinfectionMeasures)
                : default;
            var suits = createRequestDto.Suits != null ? MapHelper.MapToSuitRequests(createRequestDto.Suits) : default;
            var otherCleaningMaterialRequest = createRequestDto.OtherCleaningMaterials != null
                ? MapHelper.MapToOtherCleaningMaterialRequest(createRequestDto.OtherCleaningMaterials)
                : default;
            var psychologicalSupportRequest = createRequestDto.PsychologicalSupport != null
                ? MapHelper.MapToPsychologicalSupportRequest(createRequestDto.PsychologicalSupport)
                : default;
            var sewingSuppliesRequest = createRequestDto.SewingSupplies != null ? MapHelper.MapToSewingSuppliesRequest(createRequestDto.SewingSupplies) : default;
            var otherRequest = createRequestDto.Others != null ? MapHelper.MapToOtherRequest(createRequestDto.Others) : default;
            var printRequests = createRequestDto.Prints != null ? MapHelper.MapToPrintRequests(createRequestDto.Prints) : default;

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
                PrintRequest = printRequests,
                RemovalToken = Guid.NewGuid().ToString("N"),
                Active = true
            };

            await _requestRepository.SaveAsync(request, cancellationToken);

            var message = await MessageFactory.request(request);
            
            _messageService.send(message);
            
            return request.Id;
        }
    }
}