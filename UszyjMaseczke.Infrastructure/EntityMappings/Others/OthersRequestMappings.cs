using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.Other;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Others
{
    public class OtherRequestMapping : IEntityTypeConfiguration<OtherRequest>
    {
        public void Configure(EntityTypeBuilder<OtherRequest> builder)
        {
            builder.ToTable("OtherRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description);
        }
    }
}