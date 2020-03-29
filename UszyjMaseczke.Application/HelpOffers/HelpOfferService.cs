using System.Threading;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Mappers;
using UszyjMaseczke.Domain.HelpOffers;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Application.HelpOffers
{
    public class HelpOfferService : IHelpOfferService
    {
        private readonly IHelpOfferRepository _helpOfferRepository;
        private readonly IRequestRepository _requestRepository;

        public HelpOfferService(IHelpOfferRepository helpOfferRepository, IRequestRepository requestRepository)
        {
            _helpOfferRepository = helpOfferRepository;
            _requestRepository = requestRepository;
        }

        public async Task OfferHelpAsync(OfferHelpDto createRequestDto, CancellationToken cancellationToken)
        {
            var helper = MapHelper.MapToHelper(createRequestDto.Helper);
            foreach (var requestDto in createRequestDto.Requests)
            {
                var request = await _requestRepository.GetLazyAsync(requestDto.RequestId, cancellationToken);
                var medicalCentre = request.MedicalCentre;
                var maskRequests = requestDto.Masks != null ? MapHelper.MapToMaskRequests(requestDto.Masks) : default;
                var gloveRequests = requestDto.Gloves != null ? MapHelper.MapToGloveRequests(requestDto.Gloves) : default;
                var groceryRequests = requestDto.Groceries != null ? MapHelper.MapToGroceryRequests(requestDto.Groceries) : default;
                var disinfection = requestDto.DisinfectionMeasures != null
                    ? MapHelper.MapToDisinfectionMeasureRequest(requestDto.DisinfectionMeasures)
                    : default;
                var suits = requestDto.Suits != null ? MapHelper.MapToSuitRequests(requestDto.Suits) : default;
                var otherCleaningMaterialRequest = requestDto.OtherCleaningMaterials != null
                    ? MapHelper.MapToOtherCleaningMaterialRequest(requestDto.OtherCleaningMaterials)
                    : default;
                var psychologicalSupportRequest = requestDto.PsychologicalSupport != null
                    ? MapHelper.MapToPsychologicalSupportRequest(requestDto.PsychologicalSupport)
                    : default;
                var sewingSuppliesRequest = requestDto.SewingSupplies != null ? MapHelper.MapToSewingSuppliesRequest(requestDto.SewingSupplies) : default;
                var otherRequest = requestDto.Others != null ? MapHelper.MapToOtherRequest(requestDto.Others) : default;
                var printRequests = requestDto.Prints != null ? MapHelper.MapToPrintRequests(requestDto.Prints) : default;

                var helpOffer = new HelpOffer
                {
                    Request = request,
                    Helper = helper,
                    MedicalCentre = medicalCentre,
                    MaskSupplies = maskRequests,
                    GloveSupplies = gloveRequests,
                    GrocerySupplies = groceryRequests,
                    DisinfectionMeasureSupplies = disinfection,
                    SuitSupplies = suits,
                    OtherCleaningMaterialSupplies = otherCleaningMaterialRequest,
                    PsychologicalSupportSupplies = psychologicalSupportRequest,
                    SewingSuppliesSupplies = sewingSuppliesRequest,
                    OtherSupplies = otherRequest,
                    PrintSupplies = printRequests
                };
                await _helpOfferRepository.SaveAsync(helpOffer, cancellationToken);
            }
        }
    }
}