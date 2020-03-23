using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Dungarees;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Dungarees
{
    public class DungareesRequestMappings : IEntityTypeConfiguration<DungareeRequest>
    {
        public void Configure(EntityTypeBuilder<DungareeRequest> builder)
        {
            builder.ToTable("DungareeRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.DungareeType);
            builder.Property(x => x.Description);
        }
    }
}