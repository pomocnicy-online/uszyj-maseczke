using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Print;
using UszyjMaseczke.Domain.Suits;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Prints
{
    public class PrintRequestMappings : IEntityTypeConfiguration<PrintRequest>
    {
        public void Configure(EntityTypeBuilder<PrintRequest> builder)
        {
            builder.ToTable("PrintRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Positions);
            builder.Property(x => x.Description);
            builder.Property(x => x.TotalCount);
        }
    }
}