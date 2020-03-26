using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.Masks;

namespace UszyjMaseczke.Infrastructure.EntityMappings.Masks
{
    public class MaskRequestPositionMappings : IEntityTypeConfiguration<MaskRequestPosition>
    {
        public void Configure(EntityTypeBuilder<MaskRequestPosition> builder)
        {
            builder.ToTable("MaskRequestPositions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Style).HasConversion(
                v => v.ToString(),
                v => (Style) Enum.Parse(typeof(Style), v));
            builder.Property(x => x.UsageType).HasConversion(
                v => v.ToString(),
                v => (UsageType) Enum.Parse(typeof(UsageType), v));
        }
    }
}