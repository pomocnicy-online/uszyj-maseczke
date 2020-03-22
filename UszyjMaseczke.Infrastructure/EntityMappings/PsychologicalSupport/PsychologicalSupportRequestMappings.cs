using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.PsychologicalSupport;

namespace UszyjMaseczke.Infrastructure.EntityMappings.PsychologicalSupport
{
    public class PsychologicalSupportRequestMappings : IEntityTypeConfiguration<PsychologicalSupportRequest>
    {
        public void Configure(EntityTypeBuilder<PsychologicalSupportRequest> builder)
        {
            builder.ToTable("PsychologicalSupportRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Request)
                .WithMany(x=>x.PsychologicalSupportRequestPositions)
                .HasConstraintName("FK_PsychologicalSupportRequests_RequestId");
        }
    }
}