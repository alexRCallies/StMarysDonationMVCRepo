using Microsoft.EntityFrameworkCore.Migrations;

namespace St.Marys_Donor.Data.Migrations
{
    public partial class AddedNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05afda3d-1caf-410d-938a-7f4e5e2f563f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51f56e00-b12f-442e-8292-5eae8d8006c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8102bc4b-69a8-43ba-a320-6e19429bd425");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c39be334-12f0-41b6-a71b-c6e224b79b3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d267c628-de50-49c5-ac87-6563ab9f37a6", "2d6b71c6-d216-4131-9c47-bb0ad99c84a0", "Donor", "DONOR" },
                    { "df02100c-e6aa-41d8-a234-b12aa0482473", "063e8724-1994-41a0-9118-ce4e02b4e68b", "Patient", "PATIENT" },
                    { "3170b209-5767-4f9f-9625-598c30b44a92", "b0b184e8-1c62-4936-aa0f-f8c25c5b9117", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "47d8ed3b-84ba-492e-9dea-6fae734770f6", "0c68c68c-1a7c-496c-a44d-90e19a1cfeb7", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3170b209-5767-4f9f-9625-598c30b44a92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47d8ed3b-84ba-492e-9dea-6fae734770f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d267c628-de50-49c5-ac87-6563ab9f37a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df02100c-e6aa-41d8-a234-b12aa0482473");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c39be334-12f0-41b6-a71b-c6e224b79b3e", "a90c0b73-6c9a-4d46-a68d-5f174c3318ce", "Donor", null },
                    { "05afda3d-1caf-410d-938a-7f4e5e2f563f", "704d7331-a3b5-48d4-b8d4-75d2d269e28c", "Patient", null },
                    { "8102bc4b-69a8-43ba-a320-6e19429bd425", "97038867-4d7b-4fac-9459-6a0f029734b0", "Hospital Administrator", null },
                    { "51f56e00-b12f-442e-8292-5eae8d8006c6", "734fdb49-0973-411e-b12f-44f72a4caf33", "Admin", null }
                });
        }
    }
}
