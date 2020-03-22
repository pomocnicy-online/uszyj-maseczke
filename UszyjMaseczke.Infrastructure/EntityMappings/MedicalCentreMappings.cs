using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;

namespace UszyjMaseczke.Infrastructure.EntityMappings
{
    internal class MedicalCentreMappings : IEntityTypeConfiguration<MedicalCentre>
    {
        public void Configure(EntityTypeBuilder<MedicalCentre> builder)
        {
            builder.ToTable("MedicalCentres");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.LegalName).HasColumnType("nvarchar(255)");
            builder.Property(x => x.City).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Street).HasColumnType("nvarchar(100)");
            builder.Property(x => x.BuildingNumber).HasColumnType("nvarchar(10)");
            builder.Property(x => x.ApartmentNumber).HasColumnType("nvarchar(10)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(100)");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(20)");
        }
    }
}