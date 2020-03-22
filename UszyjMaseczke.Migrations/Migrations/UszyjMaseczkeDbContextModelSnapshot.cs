﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UszyjMaseczke.Infrastructure;

namespace UszyjMaseczke.Migrations.Migrations
{
    [DbContext(typeof(UszyjMaseczkeDbContext))]
    partial class UszyjMaseczkeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("UszyjMaseczke.Domain.Gloves.GloveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("GloveType")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("RequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("GloveRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Helper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("text");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Helpers");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.HelperRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("HelperId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HelperId");

                    b.ToTable("HelperRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Masks.MaskRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("MaskType")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("RequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("MaskRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.MedicalCentre.MedicalCentre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("text");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("LegalName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MedicalCentres");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MedicalCentreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MedicalCentreId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Gloves.GloveRequest", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Request", null)
                        .WithMany("GlovesRequests")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.HelperRequest", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Helper", "Helper")
                        .WithMany()
                        .HasForeignKey("HelperId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Masks.MaskRequest", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Request", null)
                        .WithMany("MaskRequests")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Request", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.MedicalCentre.MedicalCentre", "MedicalCentre")
                        .WithMany()
                        .HasForeignKey("MedicalCentreId");
                });
#pragma warning restore 612, 618
        }
    }
}
