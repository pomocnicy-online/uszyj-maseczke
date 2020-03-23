using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Print;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Prints
{
    public class PrintRequestPositionMappings : IEntityTypeConfiguration<PrintRequestPosition>
    {
        public void Configure(EntityTypeBuilder<PrintRequestPosition> builder)
        {
            builder.ToTable("PrintRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.PrintType);
        }
    }
}