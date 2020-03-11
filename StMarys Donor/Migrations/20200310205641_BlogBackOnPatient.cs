using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class BlogBackOnPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PatientId",
                table: "BlogPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d36879b-809a-4bce-bb92-6d027fc07a3b", "30111e6a-a587-4179-8f28-06f23c06282a", "Donor", "DONOR" },
                    { "d8936d58-ada8-473b-b6b9-fbbeab6c87b1", "8b7e3c93-f3ef-43c8-8201-1cd03111573a", "Patient", "PATIENT" },
                    { "2950edc5-b276-4a69-989a-8e90894d297b", "28f30b4b-2cc4-4706-bd26-affa3e06d7d2", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "919beca2-cb8e-4044-a2b9-dfe702d2a8d4", "3665d321-2e39-4b3c-b97d-03e1898058f0", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PatientId",
                table: "BlogPosts",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Patients_PatientId",
                table: "BlogPosts",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Patients_PatientId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_PatientId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d36879b-809a-4bce-bb92-6d027fc07a3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2950edc5-b276-4a69-989a-8e90894d297b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919beca2-cb8e-4044-a2b9-dfe702d2a8d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8936d58-ada8-473b-b6b9-fbbeab6c87b1");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "BlogPosts",
                type: "nvarchar(450)",
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
    }
}
