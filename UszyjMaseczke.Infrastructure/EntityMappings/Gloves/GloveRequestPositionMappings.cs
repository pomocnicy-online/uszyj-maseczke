using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.Gloves;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Gloves
{
    public class GloveRequestPositionMappings : IEntityTypeConfiguration<GloveRequestPosition>
    {
        public void Configure(EntityTypeBuilder<GloveRequestPosition> builder)
        {
            builder.ToTable("GloveRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Material).HasConversion(
                v => v.ToString(),
                v => (Material)Enum.Parse(typeof(Material), v));
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Size).HasConversion(
                v => v.ToString(),
                v => (Size)Enum.Parse(typeof(Material), v));
        }
    }
}