namespace UszyjMaseczke.Application.DTOs
{
    public class CreateRequestMedicalCentreDto
    {
        public string LegalName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}