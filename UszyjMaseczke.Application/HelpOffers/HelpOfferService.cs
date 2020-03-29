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
        private readonly IMedicalCentreRepository _medicalCentreRepository;
        private readonly IRequestRepository _requestRepository;

        public HelpOfferService(IHelpOfferRepository helpOfferRepository, IMedicalCentreRepository medicalCentreRepository, IRequestRepository requestRepository)
        {
            _helpOfferRepository = helpOfferRepository;
            _medicalCentreRepository = medicalCentreRepository;
            _requestRepository = requestRepository;
        }
        
        public async Task<int> OfferHelpAsync(OfferHelpDto createRequestDto, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetLazyAsync(createRequestDto.RequestId, cancellationToken);
            var medicalCentre = await _medicalCentreRepository.GetAsync(createRequestDto.MedicalCentreId, cancellationToken);
            var maskRequests = createRequestDto.MaskSupplies != null ? MapHelper.MapToMaskRequests(createRequestDto.MaskSupplies) : default;
            var gloveRequests = createRequestDto.GloveSupplies != null ? MapHelper.MapToGloveRequests(createRequestDto.GloveSupplies) : default;
            var groceryRequests = createRequestDto.GrocerySupplies != null ? MapHelper.MapToGroceryRequests(createRequestDto.GrocerySupplies) : default;
            var disinfection = createRequestDto.DisinfectionMeasureSupplies != null
                ? MapHelper.MapToDisinfectionMeasureRequest(createRequestDto.DisinfectionMeasureSupplies)
                : default;
            var suits = createRequestDto.SuitSupplies != null ? MapHelper.MapToSuitRequests(createRequestDto.SuitSupplies) : default;
            var otherCleaningMaterialRequest = createRequestDto.OtherCleaningMaterialSupplies != null
                ? MapHelper.MapToOtherCleaningMaterialRequest(createRequestDto.OtherCleaningMaterialSupplies)
                : default;
            var psychologicalSupportRequest = createRequestDto.PsychologicalSupportSupplies != null
                ? MapHelper.MapToPsychologicalSupportRequest(createRequestDto.PsychologicalSupportSupplies)
                : default;
            var sewingSuppliesRequest = createRequestDto.SewingSuppliesSupplies != null ? MapHelper.MapToSewingSuppliesRequest(createRequestDto.SewingSuppliesSupplies) : default;
            var otherRequest = createRequestDto.OtherSupplies != null ? MapHelper.MapToOtherRequest(createRequestDto.OtherSupplies) : default;
            var printRequests = createRequestDto.PrintSupplies != null ? MapHelper.MapToPrintRequests(createRequestDto.PrintSupplies) : default;
            var helper = MapHelper.MapToHelper(createRequestDto.Helper);

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
            return helpOffer.Id;
        }
    }
}