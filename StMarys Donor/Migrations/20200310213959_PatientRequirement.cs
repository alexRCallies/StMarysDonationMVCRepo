using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class PatientRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Patients",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9cffeb4f-8f42-4227-b4b1-6d449968a866", "210068e3-0f50-4360-9d84-810862117d77", "Donor", "DONOR" },
                    { "95f4b720-2ce1-4dbb-9061-abe9b780a88a", "ec2903ab-a212-4479-976a-5cf834d7ed9e", "Patient", "PATIENT" },
                    { "1856b915-6e9f-4650-88a8-6088519f6291", "dee44d3a-74bb-4c48-8b14-4fc7de70c78c", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "18eec918-f1c3-4838-90b3-82fc8a4d342b", "7eab6021-1374-434a-9e67-6f9f0eaf447a", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1856b915-6e9f-4650-88a8-6088519f6291");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18eec918-f1c3-4838-90b3-82fc8a4d342b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f4b720-2ce1-4dbb-9061-abe9b780a88a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cffeb4f-8f42-4227-b4b1-6d449968a866");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Patients");

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
        }
    }
}
