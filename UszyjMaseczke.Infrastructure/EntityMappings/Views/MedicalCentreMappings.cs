using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Application.Presentations;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Views
{
    internal class AggregatedRequestsViewMappings : IEntityTypeConfiguration<AggregatedRequestsView>
    {
        public void Configure(EntityTypeBuilder<AggregatedRequestsView> builder)
        {
            builder.ToView("aggregatedrequestsview");

            builder.HasKey(x => x.RequestId);
            builder.Property(x => x.LegalName);
            builder.Property(x => x.City);
            builder.Property(x => x.Street);
            builder.Property(x => x.BuildingNumber);
            builder.Property(x => x.PostalCode);
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.DisinfectionMeasureRequestsTotalCount);
            builder.Property(x => x.GloveRequestsTotalCount);
            builder.Property(x => x.GroceryRequestsTotalCount);
            builder.Property(x => x.MaskRequestsTotalCount);
            builder.Property(x => x.OtherCleaningMaterialRequestsTotalCount);
            builder.Property(x => x.PrintRequestsTotalCount);
            builder.Property(x => x.SuitRequestsTotalCount);
            builder.Property(x => x.PsychologicalSupportNeeded);
            builder.Property(x => x.SewingSuppliesNeeded);
            builder.Property(x => x.OtherNeeded);
        }
    }
}