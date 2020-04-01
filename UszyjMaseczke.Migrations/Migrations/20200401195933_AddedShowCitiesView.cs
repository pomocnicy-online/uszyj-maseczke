using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AddedShowCitiesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createView =
                @"CREATE VIEW requestedcitiesview as select ROW_NUMBER () OVER (ORDER BY ""City"") as ""Id"", x.""City"" from (select distinct UPPER(""City"") as ""City"" from ""MedicalCentres"") as x;";

            migrationBuilder.Sql(createView);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropView = " DROP VIEW requestedcitiesview";

            migrationBuilder.Sql(dropView);
        }
    }
}