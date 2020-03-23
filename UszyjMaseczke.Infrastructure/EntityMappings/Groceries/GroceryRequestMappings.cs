using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Groceries;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Groceries
{
    public class GroceryRequestMappings : IEntityTypeConfiguration<GroceryRequest>
    {
        public void Configure(EntityTypeBuilder<GroceryRequest> builder)
        {
            builder.ToTable("GroceryRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.GroceryType);
            builder.Property(x => x.Description);
        }
    }
}