using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Gloves;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Gloves
{
    public class GloveRequestMappings : IEntityTypeConfiguration<GloveRequest>
    {
        public void Configure(EntityTypeBuilder<GloveRequest> builder)
        {
            builder.ToTable("GloveRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.GloveType);
            builder.Property(x => x.Description);
        }
    }
}