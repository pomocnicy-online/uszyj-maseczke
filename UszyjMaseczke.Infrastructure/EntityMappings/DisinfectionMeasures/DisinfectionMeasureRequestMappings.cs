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
            builder.HasMany(x => x.Positions);
            builder.Property(x => x.TotalCount);
        }
    }
}