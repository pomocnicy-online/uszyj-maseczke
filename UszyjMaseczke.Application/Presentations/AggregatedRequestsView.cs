namespace UszyjMaseczke.Application.Presentations
{
    public class AggregatedRequestsView
    {
        public int RequestId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LegalName { get; set; }
        public int DisinfectionMeasureRequestsTotalCount { get; set; }
        public int GloveRequestsTotalCount { get; set; }
        public int GroceryRequestsTotalCount { get; set; }
        public int MaskRequestsTotalCount { get; set; }
        public int OtherCleaningMaterialRequestsTotalCount { get; set; }
        public int PrintRequestsTotalCount { get; set; }
        public int SuitRequestsTotalCount { get; set; }
        public bool PsychologicalSupportNeeded { get; set; }
        public bool SewingSuppliesNeeded { get; set; }
        public bool OtherNeeded { get; set; }

    }
}