using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class PatientBlogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "171a04a1-9816-4cae-a552-dfe86ffaff7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f22a4f0-030e-4347-b91c-55b17da24fbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50828e35-65de-494f-a218-4bb79011008e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8273b4c7-3dcb-4e26-b97e-aa03d88cc7e4");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "Patients",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8273b4c7-3dcb-4e26-b97e-aa03d88cc7e4", "7809b57f-e8ff-4525-930d-4a28f4a7a1b1", "Donor", "DONOR" },
                    { "4f22a4f0-030e-4347-b91c-55b17da24fbf", "8122c35c-1ebf-45bc-b3b9-d5e2eb7c5797", "Patient", "PATIENT" },
                    { "50828e35-65de-494f-a218-4bb79011008e", "130c27a3-6468-4e7c-82c7-8d97693b58a5", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "171a04a1-9816-4cae-a552-dfe86ffaff7c", "3286857c-3123-4f51-90ce-4ce9246609ed", "Administrator", "ADMINISTRATOR" }
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
    }
}
