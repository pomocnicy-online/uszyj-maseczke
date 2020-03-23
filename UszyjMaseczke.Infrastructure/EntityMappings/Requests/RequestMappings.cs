using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Requests
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
            builder.HasMany(x => x.MaskRequests);
            builder.HasMany(x => x.GlovesRequests);
            builder.HasMany(x => x.OtherCleaningMaterialRequestPositions);
            builder.HasMany(x => x.PsychologicalSupportRequestPositions);
            builder.HasMany(x => x.DungareeRequestPositions);
            builder.HasMany(x => x.DisinfectionMeasureRequestPositions);


        }
    }
}