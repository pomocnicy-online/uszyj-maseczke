using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain.HelpOffers;

namespace UszyjMaseczke.Infrastructure.EntityMappings.HelpOffers
{
    internal class HelpOffersMappings : IEntityTypeConfiguration<HelpOffer>
    {
        public void Configure(EntityTypeBuilder<HelpOffer> builder)
        {
            builder.ToTable("HelpOffers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Request);
            builder.HasOne(x => x.Helper);
            builder.HasOne(x => x.MedicalCentre);
            builder.HasOne(x => x.MaskSupplies);
            builder.HasOne(x => x.GloveSupplies);
            builder.HasOne(x => x.DisinfectionMeasureSupplies);
            builder.HasOne(x => x.SuitSupplies);
            builder.HasOne(x => x.GrocerySupplies);
            builder.HasOne(x => x.OtherCleaningMaterialSupplies);
            builder.HasOne(x => x.PsychologicalSupportSupplies);
            builder.HasOne(x => x.SewingSuppliesSupplies);
            builder.HasOne(x => x.OtherSupplies);
            builder.HasOne(x => x.PrintSupplies);
        }
    }
}