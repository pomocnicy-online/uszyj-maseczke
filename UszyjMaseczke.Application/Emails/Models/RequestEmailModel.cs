using UszyjMaseczke.Application.DTOs.MedicalCentres;

namespace UszyjMaseczke.Application.Emails.Models
{
    public class RequestEmailModel
    {
        public string MedicalCentreLegalName { get; }
        public string MedicalCentreCity { get; }
        public string MedicalCentreStreet { get; }
        public string MedicalCentreBuildingNumber { get; }
        public string MedicalCentreApartmentNumber { get; }
        public string MedicalCentrePostalCode { get; }
        public string MedicalCentreEmail { get; }
        public string MedicalCentrePhoneNumber { get; }
        public bool Masks { get; }
        public bool Gloves { get; }
        public bool Groceries { get; }
        public bool DisinfectionMeasures { get; }
        public bool Suits { get; }
        public bool OtherCleaningMaterials { get; }
        public bool PsychologicalSupport { get; }
        public bool SewingSupplies { get; }
        public bool Others { get; }
        public bool Prints { get; }
        public int RequestId { get; }

        public RequestEmailModel(CreateRequestMedicalCentreDto medicalCentre, bool masks, bool gloves, bool groceries,
            bool disinfectionMeasures, bool suits, bool otherCleaningMaterials, bool psychologicalSupport,
            bool sewingSupplies, bool others, bool prints, int requestId)
        {
            MedicalCentreLegalName = medicalCentre.LegalName;
            MedicalCentreCity = medicalCentre.City;
            MedicalCentreStreet = medicalCentre.Street;
            MedicalCentreBuildingNumber = medicalCentre.BuildingNumber;
            MedicalCentreApartmentNumber = medicalCentre.ApartmentNumber;
            MedicalCentrePostalCode = medicalCentre.PostalCode;
            MedicalCentreEmail = medicalCentre.Email;
            MedicalCentrePhoneNumber = medicalCentre.PhoneNumber;
            Masks = masks;
            Gloves = gloves;
            Groceries = groceries;
            DisinfectionMeasures = disinfectionMeasures;
            Suits = suits;
            OtherCleaningMaterials = otherCleaningMaterials;
            PsychologicalSupport = psychologicalSupport;
            SewingSupplies = sewingSupplies;
            Others = others;
            Prints = prints;
            RequestId = requestId;
        }
    }
}