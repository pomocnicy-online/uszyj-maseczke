using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.OtherCleaningMaterials;

namespace UszyjMaseczke.Infrastructure.EntityMappings.OtherCleaningMaterials
{
    public class OtherCleaningMaterialRequestPositionMappings : IEntityTypeConfiguration<OtherCleaningMaterialRequestPosition>
    {
        public void Configure(EntityTypeBuilder<OtherCleaningMaterialRequestPosition> builder)
        {
            builder.ToTable("OtherCleaningMaterialRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Description);
        }
    }
}