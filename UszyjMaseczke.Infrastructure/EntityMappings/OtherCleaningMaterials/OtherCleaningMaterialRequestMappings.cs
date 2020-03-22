using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.Infrastructure.EntityMappings.OtherCleaningMaterials
{
    public class OtherCleaningMaterialRequestMappings : IEntityTypeConfiguration<OtherCleaningMaterialRequest>
    {
        public void Configure(EntityTypeBuilder<OtherCleaningMaterialRequest> builder)
        {
            builder.ToTable("OtherCleaningMaterialRequests");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Request)
                .WithMany(x=>x.OtherCleaningMaterialRequestPositions)
                .HasConstraintName("FK_OtherCleaningMaterialRequests_RequestId");
        }
    }
}