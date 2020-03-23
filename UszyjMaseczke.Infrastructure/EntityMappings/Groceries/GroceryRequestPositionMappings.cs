using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Groceries
{
    public class GroceryRequestPositionMappings  : IEntityTypeConfiguration<GroceryRequestPosition>
    {
        public void Configure(EntityTypeBuilder<GroceryRequestPosition> builder)
        {
            builder.ToTable("GroceryRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description);
            builder.Property(x => x.Quantity);
        }
    }
}