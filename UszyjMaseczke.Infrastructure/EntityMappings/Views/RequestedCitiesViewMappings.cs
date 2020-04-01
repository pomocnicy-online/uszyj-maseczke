using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Application.Presentations;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Views
{
    internal class RequestedCitiesViewMappings : IEntityTypeConfiguration<RequestedCitiesView>
    {
        public void Configure(EntityTypeBuilder<RequestedCitiesView> builder)
        {
            builder.ToView("requestedcitiesview");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.City);
        }
    }
}