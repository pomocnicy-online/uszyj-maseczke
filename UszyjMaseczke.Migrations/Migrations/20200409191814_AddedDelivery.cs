using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AddedDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryRequestId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "HelpOffers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryRequestId",
                table: "Requests",
                column: "DeliveryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpOffers_DeliveryId",
                table: "HelpOffers",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpOffers_Deliveries_DeliveryId",
                table: "HelpOffers",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Deliveries_DeliveryRequestId",
                table: "Requests",
                column: "DeliveryRequestId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

                        var x = @"drop view aggregatedrequestsview;

create view aggregatedrequestsview
            (""RequestId"", ""City"", ""BuildingNumber"", ""ApartmentNumber"", ""PostalCode"", ""Email"", ""PhoneNumber"",
             ""LegalName"", ""Street"", ""DisinfectionMeasureRequestsTotalCount"", ""GloveRequestsTotalCount"",
             ""GroceryRequestsTotalCount"", ""MaskRequestsTotalCount"", ""OtherCleaningMaterialRequestsTotalCount"",
             ""PrintRequestsTotalCount"", ""SuitRequestsTotalCount"", ""PsychologicalSupportNeeded"", ""SewingSuppliesNeeded"",
             ""OtherNeeded"", ""DeliveryNeeded"")
as
SELECT r.""Id""                         AS ""RequestId"",
       mc.""City"",
       mc.""BuildingNumber"",
       mc.""ApartmentNumber"",
       mc.""PostalCode"",
       mc.""Email"",
       mc.""PhoneNumber"",
       mc.""LegalName"",
       mc.""Street"",
       coalesce(dmr.""TotalCount"", 0)  AS ""DisinfectionMeasureRequestsTotalCount"",
       coalesce(gr.""TotalCount"", 0)   AS ""GloveRequestsTotalCount"",
       coalesce(g.""TotalCount"", 0)   AS ""GroceryRequestsTotalCount"",
       coalesce(mr.""TotalCount"", 0)   AS ""MaskRequestsTotalCount"",
       coalesce(ocmr.""TotalCount"", 0) AS ""OtherCleaningMaterialRequestsTotalCount"",
       coalesce(pr.""TotalCount"", 0)   AS ""PrintRequestsTotalCount"",
       coalesce(sr.""TotalCount"", 0)   AS ""SuitRequestsTotalCount"",
       CASE
           WHEN psr.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""PsychologicalSupportNeeded"",
       CASE
           WHEN ssr.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""SewingSuppliesNeeded"",
       CASE
           WHEN o.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""OtherNeeded"",
       CASE
           WHEN dls.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""DeliveryNeeded""
FROM ""Requests"" r
         LEFT JOIN ""DisinfectionMeasureRequests"" dmr ON r.""DisinfectionMeasureRequestId"" = dmr.""Id""
         LEFT JOIN ""GloveRequests"" gr ON r.""GlovesRequestId"" = gr.""Id""
         LEFT JOIN ""GroceryRequests"" g ON r.""GroceryRequestId"" = g.""Id""
         LEFT JOIN ""MaskRequests"" mr ON r.""MaskRequestId"" = mr.""Id""
         JOIN ""MedicalCentres"" mc ON r.""MedicalCentreId"" = mc.""Id""
         LEFT JOIN ""OtherCleaningMaterialRequests"" ocmr ON r.""OtherCleaningMaterialRequestId"" = ocmr.""Id""
         LEFT JOIN ""PrintRequests"" pr ON r.""PrintRequestId"" = pr.""Id""
         LEFT JOIN ""SuitRequests"" sr ON r.""SuitRequestId"" = sr.""Id""
         LEFT JOIN ""PsychologicalSupportRequests"" psr ON r.""PsychologicalSupportRequestId"" = psr.""Id""
         LEFT JOIN ""SewingSuppliesRequests"" ssr ON r.""SewingSuppliesRequestId"" = ssr.""Id""
         LEFT JOIN ""OtherRequests"" o ON r.""OtherRequestId"" = o.""Id""
         LEFT JOIN ""Deliveries"" dls ON r.""DeliveryRequestId"" = dls.""Id""
         WHERE r.""Active"" = TRUE;
";

            migrationBuilder.Sql(x);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpOffers_Deliveries_DeliveryId",
                table: "HelpOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Deliveries_DeliveryRequestId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeliveryRequestId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_HelpOffers_DeliveryId",
                table: "HelpOffers");

            migrationBuilder.DropColumn(
                name: "DeliveryRequestId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "HelpOffers");

                        var x = @"drop view aggregatedrequestsview;

create view aggregatedrequestsview
            (""RequestId"", ""City"", ""BuildingNumber"", ""ApartmentNumber"", ""PostalCode"", ""Email"", ""PhoneNumber"",
             ""LegalName"", ""Street"", ""DisinfectionMeasureRequestsTotalCount"", ""GloveRequestsTotalCount"",
             ""GroceryRequestsTotalCount"", ""MaskRequestsTotalCount"", ""OtherCleaningMaterialRequestsTotalCount"",
             ""PrintRequestsTotalCount"", ""SuitRequestsTotalCount"", ""PsychologicalSupportNeeded"", ""SewingSuppliesNeeded"",
             ""OtherNeeded"")
as
SELECT r.""Id""                         AS ""RequestId"",
       mc.""City"",
       mc.""BuildingNumber"",
       mc.""ApartmentNumber"",
       mc.""PostalCode"",
       mc.""Email"",
       mc.""PhoneNumber"",
       mc.""LegalName"",
       mc.""Street"",
       coalesce(dmr.""TotalCount"", 0)  AS ""DisinfectionMeasureRequestsTotalCount"",
       coalesce(gr.""TotalCount"", 0)   AS ""GloveRequestsTotalCount"",
       coalesce(g.""TotalCount"", 0)   AS ""GroceryRequestsTotalCount"",
       coalesce(mr.""TotalCount"", 0)   AS ""MaskRequestsTotalCount"",
       coalesce(ocmr.""TotalCount"", 0) AS ""OtherCleaningMaterialRequestsTotalCount"",
       coalesce(pr.""TotalCount"", 0)   AS ""PrintRequestsTotalCount"",
       coalesce(sr.""TotalCount"", 0)   AS ""SuitRequestsTotalCount"",
       CASE
           WHEN psr.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""PsychologicalSupportNeeded"",
       CASE
           WHEN ssr.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""SewingSuppliesNeeded"",
       CASE
           WHEN o.""Description"" IS NOT NULL THEN true
           ELSE false
           END                        AS ""OtherNeeded""
FROM ""Requests"" r
         LEFT JOIN ""DisinfectionMeasureRequests"" dmr ON r.""DisinfectionMeasureRequestId"" = dmr.""Id""
         LEFT JOIN ""GloveRequests"" gr ON r.""GlovesRequestId"" = gr.""Id""
         LEFT JOIN ""GroceryRequests"" g ON r.""GroceryRequestId"" = g.""Id""
         LEFT JOIN ""MaskRequests"" mr ON r.""MaskRequestId"" = mr.""Id""
         JOIN ""MedicalCentres"" mc ON r.""MedicalCentreId"" = mc.""Id""
         LEFT JOIN ""OtherCleaningMaterialRequests"" ocmr ON r.""OtherCleaningMaterialRequestId"" = ocmr.""Id""
         LEFT JOIN ""PrintRequests"" pr ON r.""PrintRequestId"" = pr.""Id""
         LEFT JOIN ""SuitRequests"" sr ON r.""SuitRequestId"" = sr.""Id""
         LEFT JOIN ""PsychologicalSupportRequests"" psr ON r.""PsychologicalSupportRequestId"" = psr.""Id""
         LEFT JOIN ""SewingSuppliesRequests"" ssr ON r.""SewingSuppliesRequestId"" = ssr.""Id""
         LEFT JOIN ""OtherRequests"" o ON r.""OtherRequestId"" = o.""Id""
         WHERE r.""Active"" = TRUE;
";

                        migrationBuilder.Sql(x);

        }
    }
}
