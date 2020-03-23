using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.SewingSupplies;

namespace UszyjMaseczke.Infrastructure.EntityMappings.SewingSupplies
{
    public class SewingSuppliesRequestMappings : IEntityTypeConfiguration<SewingSuppliesRequest>
    {
        public void Configure(EntityTypeBuilder<SewingSuppliesRequest> builder)
        {
            builder.ToTable("SewingSuppliesRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description);
        }
    }
}