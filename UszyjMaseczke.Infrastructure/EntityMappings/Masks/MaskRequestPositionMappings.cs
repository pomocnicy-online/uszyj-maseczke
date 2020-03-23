using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Masks
{
    public class MaskRequestPositionMappings : IEntityTypeConfiguration<MaskRequestPosition>
    {
        public void Configure(EntityTypeBuilder<MaskRequestPosition> builder)
        {
            builder.ToTable("MaskRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Style);
            builder.Property(x => x.UsageType);
        }
    }
}