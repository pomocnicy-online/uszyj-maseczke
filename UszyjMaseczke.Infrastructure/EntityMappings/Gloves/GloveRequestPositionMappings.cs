using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Gloves;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Gloves
{
    public class GloveRequestPositionMappings : IEntityTypeConfiguration<GloveRequestPosition>
    {
        public void Configure(EntityTypeBuilder<GloveRequestPosition> builder)
        {
            builder.ToTable("GloveRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Material);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Size);
        }
    }
}