using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AdditionalCommentForHelpOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalComment",
                table: "HelpOffers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalComment",
                table: "HelpOffers");
        }
    }
}
