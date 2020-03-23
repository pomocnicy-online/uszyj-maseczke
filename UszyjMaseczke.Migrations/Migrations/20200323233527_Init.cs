using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisinfectionMeasureRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisinfectionMeasureRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GloveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GloveRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroceryRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaskRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCentres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LegalName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCentres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherCleaningMaterialRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCleaningMaterialRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsychologicalSupportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologicalSupportRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingSuppliesRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSuppliesRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisinfectionMeasureRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisinfectionMeasureRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisinfectionMeasureRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisinfectionMeasureRequestPositions_DisinfectionMeasureRequ~",
                        column: x => x.DisinfectionMeasureRequestId,
                        principalTable: "DisinfectionMeasureRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GloveRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    GloveRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GloveRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GloveRequestPositions_GloveRequests_GloveRequestId",
                        column: x => x.GloveRequestId,
                        principalTable: "GloveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroceryRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GroceryRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroceryRequestPositions_GroceryRequests_GroceryRequestId",
                        column: x => x.GroceryRequestId,
                        principalTable: "GroceryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaskRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsageType = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: false),
                    MaskRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaskRequestPositions_MaskRequests_MaskRequestId",
                        column: x => x.MaskRequestId,
                        principalTable: "MaskRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherCleaningMaterialRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OtherCleaningMaterialRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCleaningMaterialRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherCleaningMaterialRequestPositions_OtherCleaningMaterial~",
                        column: x => x.OtherCleaningMaterialRequestId,
                        principalTable: "OtherCleaningMaterialRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrintRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrintType = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PrintRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintRequestPositions_PrintRequests_PrintRequestId",
                        column: x => x.PrintRequestId,
                        principalTable: "PrintRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                        name: "FK_Requests_DisinfectionMeasureRequests_DisinfectionMeasureReq~",
                        column: x => x.DisinfectionMeasureRequestId,
                        principalTable: "DisinfectionMeasureRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_GloveRequests_GlovesRequestId",
                        column: x => x.GlovesRequestId,
                        principalTable: "GloveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_GroceryRequests_GroceryRequestId",
                        column: x => x.GroceryRequestId,
                        principalTable: "GroceryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_MaskRequests_MaskRequestId",
                        column: x => x.MaskRequestId,
                        principalTable: "MaskRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_MedicalCentres_MedicalCentreId",
                        column: x => x.MedicalCentreId,
                        principalTable: "MedicalCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_OtherCleaningMaterialRequests_OtherCleaningMateria~",
                        column: x => x.OtherCleaningMaterialRequestId,
                        principalTable: "OtherCleaningMaterialRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_OtherRequests_OtherRequestId",
                        column: x => x.OtherRequestId,
                        principalTable: "OtherRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_PrintRequests_PrintRequestId",
                        column: x => x.PrintRequestId,
                        principalTable: "PrintRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_PsychologicalSupportRequests_PsychologicalSupportR~",
                        column: x => x.PsychologicalSupportRequestId,
                        principalTable: "PsychologicalSupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_SewingSuppliesRequests_SewingSuppliesRequestId",
                        column: x => x.SewingSuppliesRequestId,
                        principalTable: "SewingSuppliesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_SuitRequests_SuitRequestId",
                        column: x => x.SuitRequestId,
                        principalTable: "SuitRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuitRequestPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Size = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SuitRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitRequestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuitRequestPositions_SuitRequests_SuitRequestId",
                        column: x => x.SuitRequestId,
                        principalTable: "SuitRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisinfectionMeasureRequestPositions_DisinfectionMeasureRequ~",
                table: "DisinfectionMeasureRequestPositions",
                column: "DisinfectionMeasureRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_GloveRequestPositions_GloveRequestId",
                table: "GloveRequestPositions",
                column: "GloveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryRequestPositions_GroceryRequestId",
                table: "GroceryRequestPositions",
                column: "GroceryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MaskRequestPositions_MaskRequestId",
                table: "MaskRequestPositions",
                column: "MaskRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCleaningMaterialRequestPositions_OtherCleaningMaterial~",
                table: "OtherCleaningMaterialRequestPositions",
                column: "OtherCleaningMaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintRequestPositions_PrintRequestId",
                table: "PrintRequestPositions",
                column: "PrintRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DisinfectionMeasureRequestId",
                table: "Requests",
                column: "DisinfectionMeasureRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GlovesRequestId",
                table: "Requests",
                column: "GlovesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GroceryRequestId",
                table: "Requests",
                column: "GroceryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MaskRequestId",
                table: "Requests",
                column: "MaskRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MedicalCentreId",
                table: "Requests",
                column: "MedicalCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OtherCleaningMaterialRequestId",
                table: "Requests",
                column: "OtherCleaningMaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OtherRequestId",
                table: "Requests",
                column: "OtherRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PrintRequestId",
                table: "Requests",
                column: "PrintRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PsychologicalSupportRequestId",
                table: "Requests",
                column: "PsychologicalSupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SewingSuppliesRequestId",
                table: "Requests",
                column: "SewingSuppliesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SuitRequestId",
                table: "Requests",
                column: "SuitRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SuitRequestPositions_SuitRequestId",
                table: "SuitRequestPositions",
                column: "SuitRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisinfectionMeasureRequestPositions");

            migrationBuilder.DropTable(
                name: "GloveRequestPositions");

            migrationBuilder.DropTable(
                name: "GroceryRequestPositions");

            migrationBuilder.DropTable(
                name: "MaskRequestPositions");

            migrationBuilder.DropTable(
                name: "OtherCleaningMaterialRequestPositions");

            migrationBuilder.DropTable(
                name: "PrintRequestPositions");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SuitRequestPositions");

            migrationBuilder.DropTable(
                name: "DisinfectionMeasureRequests");

            migrationBuilder.DropTable(
                name: "GloveRequests");

            migrationBuilder.DropTable(
                name: "GroceryRequests");

            migrationBuilder.DropTable(
                name: "MaskRequests");

            migrationBuilder.DropTable(
                name: "MedicalCentres");

            migrationBuilder.DropTable(
                name: "OtherCleaningMaterialRequests");

            migrationBuilder.DropTable(
                name: "OtherRequests");

            migrationBuilder.DropTable(
                name: "PrintRequests");

            migrationBuilder.DropTable(
                name: "PsychologicalSupportRequests");

            migrationBuilder.DropTable(
                name: "SewingSuppliesRequests");

            migrationBuilder.DropTable(
                name: "SuitRequests");
        }
    }
}
