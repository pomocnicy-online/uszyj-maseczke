using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DisinfectionMeasureRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table => { table.PrimaryKey("PK_DisinfectionMeasureRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "GloveRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_GloveRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "GroceryRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table => { table.PrimaryKey("PK_GroceryRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "MaskRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_MaskRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "MedicalCentres",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LegalName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_MedicalCentres", x => x.Id); });

            migrationBuilder.CreateTable(
                "OtherCleaningMaterialRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table => { table.PrimaryKey("PK_OtherCleaningMaterialRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "OtherRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_OtherRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "PrintRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PrintRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "PsychologicalSupportRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PsychologicalSupportRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "SewingSuppliesRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SewingSuppliesRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "SuitRequests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SuitRequests", x => x.Id); });

            migrationBuilder.CreateTable(
                "DisinfectionMeasureRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(),
                    Description = table.Column<string>(nullable: true),
                    DisinfectionMeasureRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisinfectionMeasureRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_DisinfectionMeasureRequestPositions_DisinfectionMeasureRequ~",
                        x => x.DisinfectionMeasureRequestId,
                        "DisinfectionMeasureRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "GloveRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(),
                    Quantity = table.Column<int>(),
                    Size = table.Column<string>(),
                    GloveRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GloveRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_GloveRequestPositions_GloveRequests_GloveRequestId",
                        x => x.GloveRequestId,
                        "GloveRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "GroceryRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(),
                    Description = table.Column<string>(nullable: true),
                    GroceryRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_GroceryRequestPositions_GroceryRequests_GroceryRequestId",
                        x => x.GroceryRequestId,
                        "GroceryRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "MaskRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsageType = table.Column<string>(),
                    Quantity = table.Column<int>(),
                    Style = table.Column<string>(),
                    MaskRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_MaskRequestPositions_MaskRequests_MaskRequestId",
                        x => x.MaskRequestId,
                        "MaskRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "OtherCleaningMaterialRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(),
                    Description = table.Column<string>(nullable: true),
                    OtherCleaningMaterialRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCleaningMaterialRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_OtherCleaningMaterialRequestPositions_OtherCleaningMaterial~",
                        x => x.OtherCleaningMaterialRequestId,
                        "OtherCleaningMaterialRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "PrintRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrintType = table.Column<string>(),
                    Quantity = table.Column<int>(),
                    PrintRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_PrintRequestPositions_PrintRequests_PrintRequestId",
                        x => x.PrintRequestId,
                        "PrintRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Requests",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalCentreId = table.Column<int>(nullable: true),
                    MaskRequestId = table.Column<int>(nullable: true),
                    GlovesRequestId = table.Column<int>(nullable: true),
                    DisinfectionMeasureRequestId = table.Column<int>(nullable: true),
                    SuitRequestId = table.Column<int>(nullable: true),
                    GroceryRequestId = table.Column<int>(nullable: true),
                    OtherCleaningMaterialRequestId = table.Column<int>(nullable: true),
                    PsychologicalSupportRequestId = table.Column<int>(nullable: true),
                    SewingSuppliesRequestId = table.Column<int>(nullable: true),
                    OtherRequestId = table.Column<int>(nullable: true),
                    PrintRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        "FK_Requests_DisinfectionMeasureRequests_DisinfectionMeasureReq~",
                        x => x.DisinfectionMeasureRequestId,
                        "DisinfectionMeasureRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_GloveRequests_GlovesRequestId",
                        x => x.GlovesRequestId,
                        "GloveRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_GroceryRequests_GroceryRequestId",
                        x => x.GroceryRequestId,
                        "GroceryRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_MaskRequests_MaskRequestId",
                        x => x.MaskRequestId,
                        "MaskRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_MedicalCentres_MedicalCentreId",
                        x => x.MedicalCentreId,
                        "MedicalCentres",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_OtherCleaningMaterialRequests_OtherCleaningMateria~",
                        x => x.OtherCleaningMaterialRequestId,
                        "OtherCleaningMaterialRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_OtherRequests_OtherRequestId",
                        x => x.OtherRequestId,
                        "OtherRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_PrintRequests_PrintRequestId",
                        x => x.PrintRequestId,
                        "PrintRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_PsychologicalSupportRequests_PsychologicalSupportR~",
                        x => x.PsychologicalSupportRequestId,
                        "PsychologicalSupportRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_SewingSuppliesRequests_SewingSuppliesRequestId",
                        x => x.SewingSuppliesRequestId,
                        "SewingSuppliesRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Requests_SuitRequests_SuitRequestId",
                        x => x.SuitRequestId,
                        "SuitRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "SuitRequestPositions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Size = table.Column<string>(),
                    Quantity = table.Column<int>(),
                    SuitRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitRequestPositions", x => x.Id);
                    table.ForeignKey(
                        "FK_SuitRequestPositions_SuitRequests_SuitRequestId",
                        x => x.SuitRequestId,
                        "SuitRequests",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_DisinfectionMeasureRequestPositions_DisinfectionMeasureRequ~",
                "DisinfectionMeasureRequestPositions",
                "DisinfectionMeasureRequestId");

            migrationBuilder.CreateIndex(
                "IX_GloveRequestPositions_GloveRequestId",
                "GloveRequestPositions",
                "GloveRequestId");

            migrationBuilder.CreateIndex(
                "IX_GroceryRequestPositions_GroceryRequestId",
                "GroceryRequestPositions",
                "GroceryRequestId");

            migrationBuilder.CreateIndex(
                "IX_MaskRequestPositions_MaskRequestId",
                "MaskRequestPositions",
                "MaskRequestId");

            migrationBuilder.CreateIndex(
                "IX_OtherCleaningMaterialRequestPositions_OtherCleaningMaterial~",
                "OtherCleaningMaterialRequestPositions",
                "OtherCleaningMaterialRequestId");

            migrationBuilder.CreateIndex(
                "IX_PrintRequestPositions_PrintRequestId",
                "PrintRequestPositions",
                "PrintRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_DisinfectionMeasureRequestId",
                "Requests",
                "DisinfectionMeasureRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_GlovesRequestId",
                "Requests",
                "GlovesRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_GroceryRequestId",
                "Requests",
                "GroceryRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_MaskRequestId",
                "Requests",
                "MaskRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_MedicalCentreId",
                "Requests",
                "MedicalCentreId");

            migrationBuilder.CreateIndex(
                "IX_Requests_OtherCleaningMaterialRequestId",
                "Requests",
                "OtherCleaningMaterialRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_OtherRequestId",
                "Requests",
                "OtherRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_PrintRequestId",
                "Requests",
                "PrintRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_PsychologicalSupportRequestId",
                "Requests",
                "PsychologicalSupportRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_SewingSuppliesRequestId",
                "Requests",
                "SewingSuppliesRequestId");

            migrationBuilder.CreateIndex(
                "IX_Requests_SuitRequestId",
                "Requests",
                "SuitRequestId");

            migrationBuilder.CreateIndex(
                "IX_SuitRequestPositions_SuitRequestId",
                "SuitRequestPositions",
                "SuitRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DisinfectionMeasureRequestPositions");

            migrationBuilder.DropTable(
                "GloveRequestPositions");

            migrationBuilder.DropTable(
                "GroceryRequestPositions");

            migrationBuilder.DropTable(
                "MaskRequestPositions");

            migrationBuilder.DropTable(
                "OtherCleaningMaterialRequestPositions");

            migrationBuilder.DropTable(
                "PrintRequestPositions");

            migrationBuilder.DropTable(
                "Requests");

            migrationBuilder.DropTable(
                "SuitRequestPositions");

            migrationBuilder.DropTable(
                "DisinfectionMeasureRequests");

            migrationBuilder.DropTable(
                "GloveRequests");

            migrationBuilder.DropTable(
                "GroceryRequests");

            migrationBuilder.DropTable(
                "MaskRequests");

            migrationBuilder.DropTable(
                "MedicalCentres");

            migrationBuilder.DropTable(
                "OtherCleaningMaterialRequests");

            migrationBuilder.DropTable(
                "OtherRequests");

            migrationBuilder.DropTable(
                "PrintRequests");

            migrationBuilder.DropTable(
                "PsychologicalSupportRequests");

            migrationBuilder.DropTable(
                "SewingSuppliesRequests");

            migrationBuilder.DropTable(
                "SuitRequests");
        }
    }
}