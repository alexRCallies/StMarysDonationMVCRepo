using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class PatientVerificationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53929dc3-8988-4aef-9320-d34fd2d4c702");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd541e63-20fe-41d5-bec8-dcace4c1ffdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e93848c1-d081-4546-88d1-f459de1c25de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcc25520-728e-45c4-b4df-7b04ca6671cb");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c499e3b-302c-4429-ba7b-34aa8cb47aa6", "2c540cf7-74cc-4189-bd83-af7920f9577c", "Donor", "DONOR" },
                    { "f8ad5293-499c-4392-9bb7-7dca31f67d13", "fcb6d28a-494b-4b96-a2fc-c9906ee50623", "Patient", "PATIENT" },
                    { "fc232514-4eb4-4f90-a9c2-d9385ebec2cd", "d08364ca-ec5e-4e27-af86-bc62742598c1", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "99dd0ebc-23e7-41ed-ae0c-76dac6c32af0", "9d5970a9-5a9c-4439-9418-e88653281689", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c499e3b-302c-4429-ba7b-34aa8cb47aa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99dd0ebc-23e7-41ed-ae0c-76dac6c32af0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ad5293-499c-4392-9bb7-7dca31f67d13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc232514-4eb4-4f90-a9c2-d9385ebec2cd");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e93848c1-d081-4546-88d1-f459de1c25de", "c488dbfd-569e-4025-b4f6-e343c02161d5", "Donor", "DONOR" },
                    { "fcc25520-728e-45c4-b4df-7b04ca6671cb", "28f9dd26-8659-42fd-aff2-fe42db3fb80a", "Patient", "PATIENT" },
                    { "53929dc3-8988-4aef-9320-d34fd2d4c702", "c2a2b812-88a8-4b15-9809-3bdf4755553a", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "dd541e63-20fe-41d5-bec8-dcace4c1ffdb", "1ff2f5e6-ac68-4d89-b1b9-201aa3bc1753", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
