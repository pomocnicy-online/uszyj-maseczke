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
            builder.HasOne(x => x.Request)
                .WithMany(x=>x.DungareeRequestPositions)
                .HasConstraintName("FK_DungareeRequests_RequestId");
        }
    }
}