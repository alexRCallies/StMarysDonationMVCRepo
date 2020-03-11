using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class HospitalLinkages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "674f5f8b-5256-45c8-8510-735994e9e7d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f84c513-1aeb-4100-8032-ec9a764d3572");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78a2a05-1f9f-4968-bd5a-d7739c913339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef009bef-429b-4df9-970a-6dde9c3ad0b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76c06c8b-3f1e-44b1-96fb-c92e024f22b4", "70879c45-a366-46e9-b2bc-173ee96a7c06", "Donor", "DONOR" },
                    { "9da282b1-9106-4fb4-a2e1-f4f27d2b0a96", "d2c08357-d73a-49f4-a19b-af1fae88e3f0", "Patient", "PATIENT" },
                    { "8d2b7e0a-e5e9-49da-85ce-c240f06be5bf", "460f5248-6023-460c-aa55-cc6dd65150dd", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "62139b69-5080-43cc-a943-853888ca0fd9", "5f44b325-5a3f-400e-b40e-7625c23e1a1e", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62139b69-5080-43cc-a943-853888ca0fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76c06c8b-3f1e-44b1-96fb-c92e024f22b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d2b7e0a-e5e9-49da-85ce-c240f06be5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da282b1-9106-4fb4-a2e1-f4f27d2b0a96");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d78a2a05-1f9f-4968-bd5a-d7739c913339", "5f77f3ef-4e5c-4d4b-8edb-c5b678dc8ed0", "Donor", "DONOR" },
                    { "ef009bef-429b-4df9-970a-6dde9c3ad0b9", "d08d5334-5fe5-4ba8-8fcf-cad9c3b64793", "Patient", "PATIENT" },
                    { "8f84c513-1aeb-4100-8032-ec9a764d3572", "ed4cc1db-ccc6-44c1-9be0-c05c0f12bc35", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "674f5f8b-5256-45c8-8510-735994e9e7d8", "b7fab969-095b-4e45-b433-351a99cff872", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
