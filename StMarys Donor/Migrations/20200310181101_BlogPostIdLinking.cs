using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class BlogPostIdLinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b12791a-06d9-4c4b-bf13-be5995c2cc82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4d7680-0c45-4859-b96e-efd6b39b7fe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "923479d2-1ebc-483f-8ef5-01aa17c7a9f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc83b395-cb3d-4d86-be00-efd69224b0d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7967ab4b-2964-476d-b3a8-1adb36be45d7", "4d1afe07-ac81-4fa9-9c48-27890cb6f9b6", "Donor", "DONOR" },
                    { "0498fbaf-06fd-4af4-b98c-2ccb3349c906", "c204fe76-7bfc-4d5c-977a-f1849988a2f7", "Patient", "PATIENT" },
                    { "49dff7d9-aa17-402a-85d2-32263a6aefce", "8bc68344-1974-4f9d-8b6b-c52011a86508", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "0d335c19-78fa-48f0-948f-06711053a7d2", "489e9c7d-8d01-4d89-acb5-7085c09d66c4", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0498fbaf-06fd-4af4-b98c-2ccb3349c906");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d335c19-78fa-48f0-948f-06711053a7d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49dff7d9-aa17-402a-85d2-32263a6aefce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7967ab4b-2964-476d-b3a8-1adb36be45d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc83b395-cb3d-4d86-be00-efd69224b0d4", "de8e1558-1775-40ea-9653-ab2a496b1996", "Donor", "DONOR" },
                    { "2b12791a-06d9-4c4b-bf13-be5995c2cc82", "96b0e75d-2d1b-4e51-b8c7-5beaba46d429", "Patient", "PATIENT" },
                    { "923479d2-1ebc-483f-8ef5-01aa17c7a9f3", "92ff39ea-27b0-4885-8fc7-ef9e682694e2", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "8f4d7680-0c45-4859-b96e-efd6b39b7fe0", "d42800a4-b032-4049-9c8e-8c8dca7561af", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
