using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Suits
{
    public class SuitRequestPositionMappings : IEntityTypeConfiguration<SuitRequestPosition>
    {
        public void Configure(EntityTypeBuilder<SuitRequestPosition> builder)
        {
            builder.ToTable("SuitRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Size);
        }
    }
}