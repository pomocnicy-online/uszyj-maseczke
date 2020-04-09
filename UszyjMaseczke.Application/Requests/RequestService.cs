using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.DTOs.Requests;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.Emails.Models;
using UszyjMaseczke.Application.Mappers;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure.Emails;

namespace UszyjMaseczke.Application.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;

        public RequestService(IEmailSender emailSender, IRequestRepository requestRepository, IMapper mapper)
        {
            _emailSender = emailSender;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateRequestAsync(CreateRequestDto createRequestDto,
            CancellationToken cancellationToken)
        {
            var medicalCentre = MapHelper.MapToMedicalCentre(createRequestDto.MedicalCentre);
            var maskRequests = createRequestDto.Masks != null
                ? MapHelper.MapToMaskRequests(createRequestDto.Masks)
                : default;
            var gloveRequests = createRequestDto.Gloves != null
                ? MapHelper.MapToGloveRequests(createRequestDto.Gloves)
                : default;
            var groceryRequests = createRequestDto.Groceries != null
                ? MapHelper.MapToGroceryRequests(createRequestDto.Groceries)
                : default;
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
            var sewingSuppliesRequest = createRequestDto.SewingSupplies != null
                ? MapHelper.MapToSewingSuppliesRequest(createRequestDto.SewingSupplies)
                : default;
            var otherRequest = createRequestDto.Others != null
                ? MapHelper.MapToOtherRequest(createRequestDto.Others)
                : default;
            var printRequests = createRequestDto.Prints != null
                ? MapHelper.MapToPrintRequests(createRequestDto.Prints)
                : default;
            var additionalComment = createRequestDto.AdditionalComment;
            var delivery = createRequestDto.Delivery != null
                ? MapHelper.MapToDelivery(createRequestDto.Delivery)
                : default;

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
                Active = true,
                AdditionalComment = additionalComment,
                DeliveryRequest = delivery
            };

            await _requestRepository.SaveAsync(request, cancellationToken);

            var requestEmailModel = new RequestEmailModel
            (
                createRequestDto.MedicalCentre,
                createRequestDto.DisinfectionMeasures != null,
                createRequestDto.Gloves != null,
                createRequestDto.Groceries != null,
                createRequestDto.Masks != null,
                createRequestDto.OtherCleaningMaterials != null,
                createRequestDto.Others != null,
                createRequestDto.Prints != null,
                createRequestDto.PsychologicalSupport != null,
                createRequestDto.Suits != null,
                createRequestDto.SewingSupplies != null,
                request.Id,
                request.RemovalToken
            );

            await _emailSender.SendAsync(new EmailMessage<RequestEmailModel>(
                new[] {request.MedicalCentre.Email},
                EmailTemplate.RequestRegisteredTemplate,
                Resources.Emails.RequestRegisteredEmailSubject, requestEmailModel), cancellationToken);

            return request.Id;
        }

        public async Task<AwaitingRequestDto> GetAwaitingRequestsAsync(int requestId,
            CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetAsync(requestId, cancellationToken);
            return _mapper.Map<AwaitingRequestDto>(request);
        }

        public async Task<IEnumerable<AwaitingRequestDto>> GetAwaitingRequestsByCityAsync(string city, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetByCityAsync(city, cancellationToken);
            return _mapper.Map<IEnumerable<Request>, IEnumerable<AwaitingRequestDto>>(request);
        }
    }
}