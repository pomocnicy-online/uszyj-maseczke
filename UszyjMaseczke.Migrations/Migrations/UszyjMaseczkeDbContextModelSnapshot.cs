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

            modelBuilder.Entity("UszyjMaseczke.Domain.DisinfectionMeasures.DisinfectionMeasureRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("DisinfectionMeasureRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.DisinfectionMeasures.DisinfectionMeasureRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("DisinfectionMeasureRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DisinfectionMeasureRequestId");

                    b.ToTable("DisinfectionMeasureRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Gloves.GloveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GloveRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Gloves.GloveRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("GloveRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("Material")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GloveRequestId");

                    b.ToTable("GloveRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Groceries.GroceryRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("GroceryRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Groceries.GroceryRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("GroceryRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroceryRequestId");

                    b.ToTable("GroceryRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Masks.MaskRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MaskRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Masks.MaskRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MaskRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Style")
                        .HasColumnType("integer");

                    b.Property<int>("UsageType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MaskRequestId");

                    b.ToTable("MaskRequestPositions");
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

            modelBuilder.Entity("UszyjMaseczke.Domain.Other.OtherRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OtherRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.OtherCleaningMaterials.OtherCleaningMaterialRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("OtherCleaningMaterialRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.OtherCleaningMaterials.OtherCleaningMaterialRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("OtherCleaningMaterialRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OtherCleaningMaterialRequestId");

                    b.ToTable("OtherCleaningMaterialRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Print.PrintRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PrintRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Print.PrintRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PrintRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("PrintType")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PrintRequestId");

                    b.ToTable("PrintRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.PsychologicalSupport.PsychologicalSupportRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PsychologicalSupportRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Requests.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DisinfectionMeasureRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("GlovesRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroceryRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("MaskRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("MedicalCentreId")
                        .HasColumnType("integer");

                    b.Property<int?>("OtherCleaningMaterialRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("OtherRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("PrintRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("PsychologicalSupportRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("SewingSuppliesRequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("SuitRequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DisinfectionMeasureRequestId");

                    b.HasIndex("GlovesRequestId");

                    b.HasIndex("GroceryRequestId");

                    b.HasIndex("MaskRequestId");

                    b.HasIndex("MedicalCentreId");

                    b.HasIndex("OtherCleaningMaterialRequestId");

                    b.HasIndex("OtherRequestId");

                    b.HasIndex("PrintRequestId");

                    b.HasIndex("PsychologicalSupportRequestId");

                    b.HasIndex("SewingSuppliesRequestId");

                    b.HasIndex("SuitRequestId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.SewingSupplies.SewingSuppliesRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SewingSuppliesRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Suits.SuitRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SuitRequests");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Suits.SuitRequestPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int?>("SuitRequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SuitRequestId");

                    b.ToTable("SuitRequestPositions");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.DisinfectionMeasures.DisinfectionMeasureRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.DisinfectionMeasures.DisinfectionMeasureRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("DisinfectionMeasureRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Gloves.GloveRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Gloves.GloveRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("GloveRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Groceries.GroceryRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Groceries.GroceryRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("GroceryRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Masks.MaskRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Masks.MaskRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("MaskRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.OtherCleaningMaterials.OtherCleaningMaterialRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.OtherCleaningMaterials.OtherCleaningMaterialRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("OtherCleaningMaterialRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Print.PrintRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Print.PrintRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("PrintRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Requests.Request", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.DisinfectionMeasures.DisinfectionMeasureRequest", "DisinfectionMeasureRequest")
                        .WithMany()
                        .HasForeignKey("DisinfectionMeasureRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Gloves.GloveRequest", "GlovesRequest")
                        .WithMany()
                        .HasForeignKey("GlovesRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Groceries.GroceryRequest", "GroceryRequest")
                        .WithMany()
                        .HasForeignKey("GroceryRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Masks.MaskRequest", "MaskRequest")
                        .WithMany()
                        .HasForeignKey("MaskRequestId");

                    b.HasOne("UszyjMaseczke.Domain.MedicalCentre.MedicalCentre", "MedicalCentre")
                        .WithMany()
                        .HasForeignKey("MedicalCentreId");

                    b.HasOne("UszyjMaseczke.Domain.OtherCleaningMaterials.OtherCleaningMaterialRequest", "OtherCleaningMaterialRequest")
                        .WithMany()
                        .HasForeignKey("OtherCleaningMaterialRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Other.OtherRequest", "OtherRequest")
                        .WithMany()
                        .HasForeignKey("OtherRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Print.PrintRequest", "PrintRequest")
                        .WithMany()
                        .HasForeignKey("PrintRequestId");

                    b.HasOne("UszyjMaseczke.Domain.PsychologicalSupport.PsychologicalSupportRequest", "PsychologicalSupportRequest")
                        .WithMany()
                        .HasForeignKey("PsychologicalSupportRequestId");

                    b.HasOne("UszyjMaseczke.Domain.SewingSupplies.SewingSuppliesRequest", "SewingSuppliesRequest")
                        .WithMany()
                        .HasForeignKey("SewingSuppliesRequestId");

                    b.HasOne("UszyjMaseczke.Domain.Suits.SuitRequest", "SuitRequest")
                        .WithMany()
                        .HasForeignKey("SuitRequestId");
                });

            modelBuilder.Entity("UszyjMaseczke.Domain.Suits.SuitRequestPosition", b =>
                {
                    b.HasOne("UszyjMaseczke.Domain.Suits.SuitRequest", null)
                        .WithMany("Positions")
                        .HasForeignKey("SuitRequestId");
                });
#pragma warning restore 612, 618
        }
    }
}
