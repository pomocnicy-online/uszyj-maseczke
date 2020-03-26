using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "SuitRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "PrintRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "OtherCleaningMaterialRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "MaskRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "GroceryRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "GloveRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "TotalCount",
                "DisinfectionMeasureRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "PostalCode",
                "MedicalCentres",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "TotalCount",
                "SuitRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "PrintRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "OtherCleaningMaterialRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "MaskRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "GroceryRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "GloveRequests");

            migrationBuilder.DropColumn(
                "TotalCount",
                "DisinfectionMeasureRequests");

            migrationBuilder.DropColumn(
                "PostalCode",
                "MedicalCentres");
        }
    }
}