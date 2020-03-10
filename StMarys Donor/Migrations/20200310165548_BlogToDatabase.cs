using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class BlogToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62d41dab-2b0e-4a4f-ad1e-4f808069033f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "844bf275-a615-4ccd-a050-eaad19d7bce7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "934c2d35-56ba-43dd-8884-7dc065cc918e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3824a8c-5739-444f-8c94-973ca3824e2e");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(nullable: true),
                    BlogPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogUpdates_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PatientId",
                table: "BlogPosts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogUpdates_BlogPostId",
                table: "BlogUpdates",
                column: "BlogPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogUpdates");

            migrationBuilder.DropTable(
                name: "BlogPosts");

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
                    { "934c2d35-56ba-43dd-8884-7dc065cc918e", "31810f3d-78a0-407d-b693-c2ea324877ae", "Donor", "DONOR" },
                    { "62d41dab-2b0e-4a4f-ad1e-4f808069033f", "3661c1a4-8b54-4f6e-afe1-bd6c3480eedf", "Patient", "PATIENT" },
                    { "f3824a8c-5739-444f-8c94-973ca3824e2e", "eaaf30bf-37dd-4aff-9fa1-a4ca2f4a6cce", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "844bf275-a615-4ccd-a050-eaad19d7bce7", "73dad4f1-905a-44b0-96e1-b5a458da9a55", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
