using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.MedicalCentres;

namespace UszyjMaseczke.Infrastructure.EntityMappings.MedicalCentres
{
    internal class MedicalCentreMappings : IEntityTypeConfiguration<MedicalCentre>
    {
        public void Configure(EntityTypeBuilder<MedicalCentre> builder)
        {
            builder.ToTable("MedicalCentres");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.LegalName);
            builder.Property(x => x.City);
            builder.HasIndex(x => x.City);
            builder.Property(x => x.Street);
            builder.Property(x => x.BuildingNumber);
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.PostalCode);
            builder.Property(x => x.Email);
            builder.Property(x => x.PhoneNumber);
        }
    }
}