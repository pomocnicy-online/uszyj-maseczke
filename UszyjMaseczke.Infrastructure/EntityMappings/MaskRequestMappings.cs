using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Infrastructure.EntityMappings
{
    public class MaskRequestMappings : IEntityTypeConfiguration<MaskRequest>
    {
        public void Configure(EntityTypeBuilder<MaskRequest> builder)
        {
            builder.ToTable("MaskRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.MaskType);
            builder.Property(x => x.Description);

        }
    }
}