using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "SuitRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "PrintRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "OtherCleaningMaterialRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "MaskRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "GroceryRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "GloveRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "DisinfectionMeasureRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "MedicalCentres",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "SuitRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "PrintRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "OtherCleaningMaterialRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "MaskRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "GroceryRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "GloveRequests");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "DisinfectionMeasureRequests");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "MedicalCentres");
        }
    }
}
