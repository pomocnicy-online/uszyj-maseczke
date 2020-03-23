using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.Helpers;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Helpers
{
    public class HelperRequestMappings : IEntityTypeConfiguration<HelperRequest>
    {
        public void Configure(EntityTypeBuilder<HelperRequest> builder)
        {
            builder.ToTable("HelperRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Helper);
        }
    }
}