using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class BlogIdForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BlogPosts_BlogPostId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BlogPostId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b095a47-3b1d-4a1d-9d77-75494d5a1886");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67e80da1-7c90-483a-8421-30fb4641c2e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3d7ff21-5b63-44d3-bf92-1bf113291978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69b0079-b200-4408-930b-eadcdfe37955");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99025255-a784-43d7-9dc3-4bf3a58df439", "2d5d74c5-f79c-446d-bf4a-28c604d4ab69", "Donor", "DONOR" },
                    { "2c2e144b-e0d3-47bb-b1de-f39261e9f7ab", "6f27d910-87c8-462d-b82b-a63984063eb9", "Patient", "PATIENT" },
                    { "8bfbed17-e69c-42d5-ac36-f6cdda7d6c5e", "1f7aaa2d-4304-4166-a577-66c0d2b8b33c", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "46921776-cb56-47cd-b866-8af58a413576", "da65ec07-076e-41b6-96ad-feeb977bc2aa", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_IdentityUserId",
                table: "BlogPosts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AspNetUsers_IdentityUserId",
                table: "BlogPosts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AspNetUsers_IdentityUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_IdentityUserId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c2e144b-e0d3-47bb-b1de-f39261e9f7ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46921776-cb56-47cd-b866-8af58a413576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bfbed17-e69c-42d5-ac36-f6cdda7d6c5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99025255-a784-43d7-9dc3-4bf3a58df439");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67e80da1-7c90-483a-8421-30fb4641c2e4", "84857163-d975-4c58-b475-737278085ad5", "Donor", "DONOR" },
                    { "d69b0079-b200-4408-930b-eadcdfe37955", "d55dcc99-971d-4b67-a170-1b5cd734fc31", "Patient", "PATIENT" },
                    { "c3d7ff21-5b63-44d3-bf92-1bf113291978", "4b7b06aa-f674-41a5-9253-6cc7e4cdcbff", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "5b095a47-3b1d-4a1d-9d77-75494d5a1886", "7be830da-47c5-4dd5-aeed-2eb8910f232a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BlogPostId",
                table: "Patients",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BlogPosts_BlogPostId",
                table: "Patients",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
