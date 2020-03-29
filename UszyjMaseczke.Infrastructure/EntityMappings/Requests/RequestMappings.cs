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
            builder.HasOne(x => x.MaskRequest);
            builder.HasOne(x => x.GlovesRequest);
            builder.HasOne(x => x.DisinfectionMeasureRequest);
            builder.HasOne(x => x.SuitRequest);
            builder.HasOne(x => x.GroceryRequest);
            builder.HasOne(x => x.OtherCleaningMaterialRequest);
            builder.HasOne(x => x.PsychologicalSupportRequest);
            builder.HasOne(x => x.SewingSuppliesRequest);
            builder.HasOne(x => x.OtherRequest);
            builder.HasOne(x => x.PrintRequest);
            builder.Property(x => x.RemovalToken);
            builder.Property(x => x.Active);

        }
    }
}