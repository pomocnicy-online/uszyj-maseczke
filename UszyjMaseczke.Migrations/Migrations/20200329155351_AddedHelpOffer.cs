using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AddedHelpOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Helpers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helpers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestId = table.Column<int>(nullable: true),
                    MedicalCentreId = table.Column<int>(nullable: true),
                    HelperId = table.Column<int>(nullable: true),
                    MaskSuppliesId = table.Column<int>(nullable: true),
                    GloveSuppliesId = table.Column<int>(nullable: true),
                    DisinfectionMeasureSuppliesId = table.Column<int>(nullable: true),
                    SuitSuppliesId = table.Column<int>(nullable: true),
                    GrocerySuppliesId = table.Column<int>(nullable: true),
                    OtherCleaningMaterialSuppliesId = table.Column<int>(nullable: true),
                    PsychologicalSupportSuppliesId = table.Column<int>(nullable: true),
                    SewingSuppliesSuppliesId = table.Column<int>(nullable: true),
                    OtherSuppliesId = table.Column<int>(nullable: true),
                    PrintSuppliesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpOffers_DisinfectionMeasureRequests_DisinfectionMeasureS~",
                        column: x => x.DisinfectionMeasureSuppliesId,
                        principalTable: "DisinfectionMeasureRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_GloveRequests_GloveSuppliesId",
                        column: x => x.GloveSuppliesId,
                        principalTable: "GloveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_GroceryRequests_GrocerySuppliesId",
                        column: x => x.GrocerySuppliesId,
                        principalTable: "GroceryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_Helpers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Helpers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_MaskRequests_MaskSuppliesId",
                        column: x => x.MaskSuppliesId,
                        principalTable: "MaskRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_MedicalCentres_MedicalCentreId",
                        column: x => x.MedicalCentreId,
                        principalTable: "MedicalCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_OtherCleaningMaterialRequests_OtherCleaningMater~",
                        column: x => x.OtherCleaningMaterialSuppliesId,
                        principalTable: "OtherCleaningMaterialRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_OtherRequests_OtherSuppliesId",
                        column: x => x.OtherSuppliesId,
                        principalTable: "OtherRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_PrintRequests_PrintSuppliesId",
                        column: x => x.PrintSuppliesId,
                        principalTable: "PrintRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_PsychologicalSupportRequests_PsychologicalSuppor~",
                        column: x => x.PsychologicalSupportSuppliesId,
                        principalTable: "PsychologicalSupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_SewingSuppliesRequests_SewingSuppliesSuppliesId",
                        column: x => x.SewingSuppliesSuppliesId,
                        principalTable: "SewingSuppliesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpOffers_SuitRequests_SuitSuppliesId",
                        column: x => x.SuitSuppliesId,
                        principalTable: "SuitRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_DisinfectionMeasureSuppliesId",
                table: "HelpOffers",
                column: "DisinfectionMeasureSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_GloveSuppliesId",
                table: "HelpOffers",
                column: "GloveSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_GrocerySuppliesId",
                table: "HelpOffers",
                column: "GrocerySuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_HelperId",
                table: "HelpOffers",
                column: "HelperId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_MaskSuppliesId",
                table: "HelpOffers",
                column: "MaskSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_MedicalCentreId",
                table: "HelpOffers",
                column: "MedicalCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_OtherCleaningMaterialSuppliesId",
                table: "HelpOffers",
                column: "OtherCleaningMaterialSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_OtherSuppliesId",
                table: "HelpOffers",
                column: "OtherSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_PrintSuppliesId",
                table: "HelpOffers",
                column: "PrintSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_PsychologicalSupportSuppliesId",
                table: "HelpOffers",
                column: "PsychologicalSupportSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_RequestId",
                table: "HelpOffers",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_SewingSuppliesSuppliesId",
                table: "HelpOffers",
                column: "SewingSuppliesSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_SuitSuppliesId",
                table: "HelpOffers",
                column: "SuitSuppliesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpOffers");

            migrationBuilder.DropTable(
                name: "Helpers");
        }
    }
}
