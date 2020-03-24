using Microsoft.EntityFrameworkCore.Migrations;

namespace UszyjMaseczke.Migrations.Migrations
{
    public partial class AddedView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var x = @"CREATE VIEW AggregatedRequestsView as
select R.""Id""                                                           as ""RequestId"",
       MC.""City""                                                        as ""City"",
       MC.""BuildingNumber""                                              as ""BuildingNumber"",
       MC.""ApartmentNumber""                                             as ""ApartmentNumber"",
       MC.""PostalCode""                                                  as ""PostalCode"",
       MC.""Email""                                                       as ""Email"",
       MC.""PhoneNumber""                                                 as ""PhoneNumber"",
       MC.""LegalName""                                                   as ""LegalName"",
       MC.""Street""                                                      as ""Street"",
       DMR.""TotalCount""                                                 as ""DisinfectionMeasureRequestsTotalCount"",
       GR.""TotalCount""                                                  as ""GloveRequestsTotalCount"",
       G.""TotalCount""                                                   as ""GroceryRequestsTotalCount"",
       MR.""TotalCount""                                                  as ""MaskRequestsTotalCount"",
       OCMR.""TotalCount""                                                as ""OtherCleaningMaterialRequestsTotalCount"",
       PR.""TotalCount""                                                  as ""PrintRequestsTotalCount"",
       SR.""TotalCount""                                                  as ""SuitRequestsTotalCount"",
       CASE WHEN PSR.""Description"" IS NOT NULL THEN TRUE ELSE FALSE END as ""PsychologicalSupportNeeded"",
       CASE WHEN SSR.""Description"" IS NOT NULL THEN TRUE ELSE FALSE END as ""SewingSuppliesNeeded"",
       CASE WHEN O.""Description"" IS NOT NULL THEN TRUE ELSE FALSE END   as ""OtherNeeded""


from ""Requests"" as R
         join ""DisinfectionMeasureRequests"" DMR on R.""DisinfectionMeasureRequestId"" = DMR.""Id""
         join ""GloveRequests"" GR on R.""GlovesRequestId"" = GR.""Id""
         join ""GroceryRequests"" G on R.""GroceryRequestId"" = G.""Id""
         join ""MaskRequests"" MR on R.""MaskRequestId"" = MR.""Id""
         join ""MedicalCentres"" MC on R.""MedicalCentreId"" = MC.""Id""
         join ""OtherCleaningMaterialRequests"" OCMR on R.""OtherCleaningMaterialRequestId"" = OCMR.""Id""
         join ""PrintRequests"" PR on R.""PrintRequestId"" = PR.""Id""
         join ""SuitRequests"" SR on R.""SuitRequestId"" = SR.""Id""
         join ""PsychologicalSupportRequests"" PSR on R.""PsychologicalSupportRequestId"" = PSR.""Id""
         join ""SewingSuppliesRequests"" SSR on R.""SewingSuppliesRequestId"" = SSR.""Id""
         join ""OtherRequests"" O on R.""OtherRequestId"" = O.""Id""";

            migrationBuilder.Sql(x);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropView = " DROP VIEW AggregatedRequestsView";

            migrationBuilder.Sql(dropView);
        }
    }
}