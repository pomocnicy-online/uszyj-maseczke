using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.DisinfectionMeasures;

namespace UszyjMaseczke.Infrastructure.EntityMappings.DisinfectionMeasures
{
    public class DisinfectionMeasureRequestPositionMappings : IEntityTypeConfiguration<DisinfectionMeasureRequestPosition>
    {
        public void Configure(EntityTypeBuilder<DisinfectionMeasureRequestPosition> builder)
        {
            builder.ToTable("DisinfectionMeasureRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Description);
        }
    }
}