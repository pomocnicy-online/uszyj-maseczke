namespace UszyjMaseczke.Application.Emails.Models
{
    public class HelpOfferRegisteredHelperEmailModel
    {
        public string MedicalCentreLegalName { get; }
        public string MedicalCentreCity { get; }
        public string MedicalCentreStreet { get; }
        public string MedicalCentreBuildingNumber { get; }
        public string MedicalCentreApartmentNumber { get; }
        public string MedicalCentrePostalCode { get; }
        public string MedicalCentreEmail { get; }
        public string MedicalCentrePhoneNumber { get; }
        public string HelperName { get; }
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

        public HelpOfferRegisteredHelperEmailModel(string medicalCentreLegalName, string medicalCentreCity,
            string medicalCentreStreet, string medicalCentreBuildingNumber, string medicalCentreApartmentNumber,
            string medicalCentrePostalCode, string medicalCentreEmail, string medicalCentrePhoneNumber,
            string helperName, int masksCount, int glovesCount, int groceriesCount,
            int disinfectionMeasuresCount, int suitsCount, int otherCleaningMaterialsCount,
            int printsCount, bool sewingSupplies, bool others, bool psychologicalSupport, int requestId)
        {
            MedicalCentreLegalName = medicalCentreLegalName;
            MedicalCentreCity = medicalCentreCity;
            MedicalCentreStreet = medicalCentreStreet;
            MedicalCentreBuildingNumber = medicalCentreBuildingNumber;
            MedicalCentreApartmentNumber = medicalCentreApartmentNumber;
            MedicalCentrePostalCode = medicalCentrePostalCode;
            MedicalCentreEmail = medicalCentreEmail;
            MedicalCentrePhoneNumber = medicalCentrePhoneNumber;
            HelperName = helperName;
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