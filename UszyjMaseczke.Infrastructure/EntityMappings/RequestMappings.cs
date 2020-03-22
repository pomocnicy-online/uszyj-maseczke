using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;

namespace UszyjMaseczke.Infrastructure.EntityMappings
{
    internal class RequestMappings : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Requests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.MedicalCentre);
            builder.HasMany(x => x.GroceryRequestPositions);
        }
    }
}