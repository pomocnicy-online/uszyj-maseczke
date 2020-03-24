using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Suits
{
    public class SuitRequestMappings : IEntityTypeConfiguration<SuitRequest>
    {
        public void Configure(EntityTypeBuilder<SuitRequest> builder)
        {
            builder.ToTable("SuitRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Positions);
            builder.Property(x => x.Description);
            builder.Property(x => x.TotalCount);
        }
    }
}