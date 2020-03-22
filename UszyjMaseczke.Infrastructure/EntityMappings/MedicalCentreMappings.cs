﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UszyjMaseczke.Domain;
using UszyjMaseczke.Domain.MedicalCentre;

namespace UszyjMaseczke.Infrastructure.EntityMappings
{
    internal class MedicalCentreMappings : IEntityTypeConfiguration<MedicalCentre>
    {
        public void Configure(EntityTypeBuilder<MedicalCentre> builder)
        {
            builder.ToTable("MedicalCentres");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.LegalName);
            builder.Property(x => x.City);
            builder.Property(x => x.Street);
            builder.Property(x => x.BuildingNumber);
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.Email);
            builder.Property(x => x.PhoneNumber);
        }
    }
}