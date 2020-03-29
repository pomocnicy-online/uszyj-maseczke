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
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailSender _emailSender;
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository, IEmailSender emailSender, IEmailFactory emailFactory)
        {
            _requestRepository = requestRepository;
            _emailSender = emailSender;
            _emailFactory = emailFactory;
        }

        public async Task<int> CreateRequestAsync(CreateRequestDto createRequestDto, CancellationToken cancellationToken)
        {
            var medicalCentre = MapHelper.MapToMedicalCentre(createRequestDto.MedicalCentre);
            var maskRequests = createRequestDto.MaskRequest != null ? MapHelper.MapToMaskRequests(createRequestDto.MaskRequest) : default;
            var gloveRequests = createRequestDto.GloveRequest != null ? MapHelper.MapToGloveRequests(createRequestDto.GloveRequest) : default;
            var groceryRequests = createRequestDto.GroceryRequest != null ? MapHelper.MapToGroceryRequests(createRequestDto.GroceryRequest) : default;
            var disinfection = createRequestDto.DisinfectionMeasureRequest != null
                ? MapHelper.MapToDisinfectionMeasureRequest(createRequestDto.DisinfectionMeasureRequest)
                : default;
            var suits = createRequestDto.SuitRequest != null ? MapHelper.MapToSuitRequests(createRequestDto.SuitRequest) : default;
            var otherCleaningMaterialRequest = createRequestDto.OtherCleaningMaterialRequest != null
                ? MapHelper.MapToOtherCleaningMaterialRequest(createRequestDto.OtherCleaningMaterialRequest)
                : default;
            var psychologicalSupportRequest = createRequestDto.PsychologicalSupportRequest != null
                ? MapHelper.MapToPsychologicalSupportRequest(createRequestDto.PsychologicalSupportRequest)
                : default;
            var sewingSuppliesRequest = createRequestDto.SewingSuppliesRequest != null ? MapHelper.MapToSewingSuppliesRequest(createRequestDto.SewingSuppliesRequest) : default;
            var otherRequest = createRequestDto.OtherRequest != null ? MapHelper.MapToOtherRequest(createRequestDto.OtherRequest) : default;
            var printRequests = createRequestDto.PrintRequest != null ? MapHelper.MapToPrintRequests(createRequestDto.PrintRequest) : default;

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

            await _requestRepository.SaveAsync(request, cancellationToken);
            await _emailSender.SendAsync(new EmailMessage(
                new[] {request.MedicalCentre.Email},
                _emailFactory.MakeRequestRegisteredEmail(),
                "Zgłoszenie zostało przyjęte"), cancellationToken);

            return request.Id;
        }
    }
}