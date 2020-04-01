namespace UszyjMaseczke.Application.Emails.Models
{
    public class HelpOfferRegisteredReceiverEmailModel
    {
        public string MedicalCentreLegalName { get; }
        public string HelperName { get; }
        public string HelperPhoneNumber { get; }
        public string HelperEmail { get; }
        public int MasksCount { get; }
        public int GlovesCount { get; }
        public int GroceriesCount { get; }
        public int DisinfectionMeasuresCount { get; }
        public int SuitsCount { get; }
        public int OtherCleaningMaterialsCount { get; }
        public int PrintsCount { get; }
        public bool SewingSupplies { get; }
        public bool Others { get; }
        public bool PsychologicalSupport { get; }
        public int RequestId { get; }

        public HelpOfferRegisteredReceiverEmailModel(string medicalCentreLegalName, string helperName,
            string helperPhoneNumber, string helperEmail, int masksCount, int glovesCount, int groceriesCount,
            int disinfectionMeasuresCount, int suitsCount, int otherCleaningMaterialsCount,
            int printsCount, bool sewingSupplies, bool others, bool psychologicalSupport, int requestId)
        {
            MedicalCentreLegalName = medicalCentreLegalName;
            HelperName = helperName;
            HelperPhoneNumber = helperPhoneNumber;
            HelperEmail = helperEmail;
            MasksCount = masksCount;
            GlovesCount = glovesCount;
            GroceriesCount = groceriesCount;
            DisinfectionMeasuresCount = disinfectionMeasuresCount;
            SuitsCount = suitsCount;
            OtherCleaningMaterialsCount = otherCleaningMaterialsCount;
            PrintsCount = printsCount;
            SewingSupplies = sewingSupplies;
            Others = others;
            PsychologicalSupport = psychologicalSupport;
            RequestId = requestId;
        }
    }
}