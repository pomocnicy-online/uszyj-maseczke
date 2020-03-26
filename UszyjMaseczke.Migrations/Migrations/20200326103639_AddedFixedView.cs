using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AddedFixedView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
         LEFT JOIN ""OtherRequests"" o ON r.""OtherRequestId"" = o.""Id"";
";

            migrationBuilder.Sql(x);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropView = " DROP VIEW AggregatedRequestsView";

            migrationBuilder.Sql(dropView);
        }
    }
}