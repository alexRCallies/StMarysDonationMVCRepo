using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class UpdatingToMakeSure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38c7d47a-c1fd-4220-ad80-67f19df3f4b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ccaef56-cdac-407c-82a0-6f11d1dd163b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94697774-9ee8-4fda-8b65-1c70f66d3816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb54e20-b33f-4f81-b3a3-2a6c404f0c46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45cf6237-65e2-4e32-a0b4-c7eafbbab6a1", "75b40dfe-38a6-4843-a945-eac8b932ac9d", "Donor", "DONOR" },
                    { "3a87405f-e0f3-4138-9d97-a909ce3b2b79", "0ae63977-0300-484c-a003-cd4a98e10589", "Patient", "PATIENT" },
                    { "0531b69f-2e13-40ae-a1a7-822ba61a66fc", "8e7d92fc-00ea-4eed-86de-43dcdc129c86", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "38a09e04-8f80-4169-bfa6-e04beb062009", "938a03d6-a1b5-4aec-97e6-8f04e368185f", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0531b69f-2e13-40ae-a1a7-822ba61a66fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a09e04-8f80-4169-bfa6-e04beb062009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a87405f-e0f3-4138-9d97-a909ce3b2b79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45cf6237-65e2-4e32-a0b4-c7eafbbab6a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38c7d47a-c1fd-4220-ad80-67f19df3f4b2", "1731d55f-fc76-4fa8-9ae5-afe79303fb89", "Donor", "DONOR" },
                    { "94697774-9ee8-4fda-8b65-1c70f66d3816", "1a86b059-59c7-490b-a004-7599660ad3f7", "Patient", "PATIENT" },
                    { "feb54e20-b33f-4f81-b3a3-2a6c404f0c46", "ce31b24e-3221-4ddc-948d-f9a4aababd8b", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "3ccaef56-cdac-407c-82a0-6f11d1dd163b", "6d8c19fd-1da7-4935-9f01-b89b1c0f4453", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
