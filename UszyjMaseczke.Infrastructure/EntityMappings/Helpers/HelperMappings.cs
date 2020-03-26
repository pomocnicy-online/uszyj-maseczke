using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Helpers;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Helpers
{
    public class HelperMappings : IEntityTypeConfiguration<Helper>
    {
        public void Configure(EntityTypeBuilder<Helper> builder)
        {
            builder.ToTable("Helpers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.City);
            builder.Property(x => x.Street);
            builder.Property(x => x.BuildingNumber);
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.Email);
            builder.Property(x => x.PhoneNumber);
        }
    }
}