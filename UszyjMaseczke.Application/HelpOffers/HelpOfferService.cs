using System.Threading;
using System.Threading.Tasks;
using UszyjMaseczke.Application.DTOs;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.Emails.Models;
using UszyjMaseczke.Application.Mappers;
using UszyjMaseczke.Domain.HelpOffers;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure.Emails;

namespace UszyjMaseczke.Application.HelpOffers
{
    public class HelpOfferService : IHelpOfferService
    {
        private readonly IHelpOfferRepository _helpOfferRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IEmailSender _emailSender;

        public HelpOfferService(IHelpOfferRepository helpOfferRepository, IRequestRepository requestRepository,
            IEmailSender emailSender)
        {
            _helpOfferRepository = helpOfferRepository;
            _requestRepository = requestRepository;
            _emailSender = emailSender;
        }

        public async Task OfferHelpAsync(OfferHelpDto createRequestDto, CancellationToken cancellationToken)
        {
            var helper = MapHelper.MapToHelper(createRequestDto.Helper);
            foreach (var requestDto in createRequestDto.Requests)
            {
                var request = await _requestRepository.GetLazyAsync(requestDto.RequestId, cancellationToken);
                var medicalCentre = request.MedicalCentre;
                var maskRequests = requestDto.Masks != null ? MapHelper.MapToMaskRequests(requestDto.Masks) : default;
                var gloveRequests = requestDto.Gloves != null
                    ? MapHelper.MapToGloveRequests(requestDto.Gloves)
                    : default;
                var groceryRequests = requestDto.Groceries != null
                    ? MapHelper.MapToGroceryRequests(requestDto.Groceries)
                    : default;
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
                var sewingSuppliesRequest = requestDto.SewingSupplies != null
                    ? MapHelper.MapToSewingSuppliesRequest(requestDto.SewingSupplies)
                    : default;
                var otherRequest = requestDto.Others != null ? MapHelper.MapToOtherRequest(requestDto.Others) : default;
                var printRequests = requestDto.Prints != null
                    ? MapHelper.MapToPrintRequests(requestDto.Prints)
                    : default;

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

                var helpOfferRegisteredReceiverEmailModel =
                    new HelpOfferRegisteredReceiverEmailModel(helpOffer.MedicalCentre.LegalName,
                        helpOffer.Helper.FirstName, helpOffer.Helper.PhoneNumber, helpOffer.Helper.Email,
                        helpOffer.MaskSupplies.TotalCount, helpOffer.GloveSupplies.TotalCount,
                        helpOffer.GrocerySupplies.TotalCount, helpOffer.DisinfectionMeasureSupplies.TotalCount,
                        helpOffer.SuitSupplies.TotalCount, helpOffer.OtherCleaningMaterialSupplies.TotalCount,
                        helpOffer.PrintSupplies.TotalCount, helpOffer.SewingSuppliesSupplies != null,
                        helpOffer.OtherSupplies != null, helpOffer.PsychologicalSupportSupplies != null,
                        helpOffer.Request.Id);

                await _emailSender.SendAsync(new EmailMessage<HelpOfferRegisteredReceiverEmailModel>(
                        new[] {helpOffer.MedicalCentre.Email},
                        EmailTemplate.HelpOfferRegisteredReceiverTemplate,
                        Resources.Emails.HelpOfferRegisteredReceiverEmailSubject, helpOfferRegisteredReceiverEmailModel),
                    cancellationToken);

                var helpOfferRegisteredHelperEmailModel =
                    new HelpOfferRegisteredHelperEmailModel(helpOffer.MedicalCentre.LegalName,
                        helpOffer.MedicalCentre.City, helpOffer.MedicalCentre.Street,
                        helpOffer.MedicalCentre.BuildingNumber, helpOffer.MedicalCentre.ApartmentNumber,
                        helpOffer.MedicalCentre.PostalCode, helpOffer.MedicalCentre.Email,
                        helpOffer.MedicalCentre.PhoneNumber,
                        helpOffer.Helper.FirstName,
                        helpOffer.MaskSupplies.TotalCount, helpOffer.GloveSupplies.TotalCount,
                        helpOffer.GrocerySupplies.TotalCount, helpOffer.DisinfectionMeasureSupplies.TotalCount,
                        helpOffer.SuitSupplies.TotalCount, helpOffer.OtherCleaningMaterialSupplies.TotalCount,
                        helpOffer.PrintSupplies.TotalCount, helpOffer.SewingSuppliesSupplies != null,
                        helpOffer.OtherSupplies != null, helpOffer.PsychologicalSupportSupplies != null,
                        helpOffer.Request.Id);
                
                await _emailSender.SendAsync(new EmailMessage<HelpOfferRegisteredHelperEmailModel>(
                        new[] {helpOffer.Helper.Email},
                        EmailTemplate.HelpOfferRegisteredHelperTemplate,
                        Resources.Emails.HelpOfferRegisteredHelperEmailSubject, helpOfferRegisteredHelperEmailModel),
                    cancellationToken);
            }
        }
    }
}