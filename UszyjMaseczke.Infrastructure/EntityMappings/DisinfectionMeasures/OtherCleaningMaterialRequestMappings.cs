using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.DisinfectionMeasures;

namespace UszyjMaseczke.Infrastructure.EntityMappings.DisinfectionMeasures
{
    public class DisinfectionMeasureRequestMappings : IEntityTypeConfiguration<DisinfectionMeasureRequest>
    {
        public void Configure(EntityTypeBuilder<DisinfectionMeasureRequest> builder)
        {
            builder.ToTable("DisinfectionMeasureRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Request)
                .WithMany(x=>x.DisinfectionMeasureRequestPositions)
                .HasConstraintName("FK_DisinfectionMeasureRequests_RequestId");
        }
    }
}