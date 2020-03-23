using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Masks
{
    public class MaskRequestMappings : IEntityTypeConfiguration<MaskRequest>
    {
        public void Configure(EntityTypeBuilder<MaskRequest> builder)
        {
            builder.ToTable("MaskRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Positions);
            builder.Property(x => x.Description);

        }
    }
}