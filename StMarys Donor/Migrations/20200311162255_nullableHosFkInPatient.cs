using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class nullableHosFkInPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba0b69b-0f91-4f4b-abce-a6aad7b1483d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92616db-3525-48ca-b23c-6cca91117093");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c31b735f-80a0-45c5-b11a-4e3df48b3e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9abd3fa-d224-4c62-8297-b3fa829ca55f");

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_AdministratorId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f6963e8c-816d-464c-98a7-67c145139d24", "26668e34-a858-4452-8604-6de140c2b3e3", "Donor", "DONOR" },
                    { "4c19dd2a-6390-4419-836c-a2e426045317", "d3bc20c6-f27c-406b-b89e-4f106c312b8b", "Patient", "PATIENT" },
                    { "4807a37f-2f05-4aaa-ae6e-b045729f59a2", "a6b69ea6-6475-4a3e-9bed-30885093937c", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "d46bcf32-cadf-40c6-9cd6-a097df8e797d", "7e45c8aa-aa4b-4dc1-ad23-80c7949a7696", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients",
                column: "Hospital_AdministratorId",
                principalTable: "Hospital_Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4807a37f-2f05-4aaa-ae6e-b045729f59a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c19dd2a-6390-4419-836c-a2e426045317");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d46bcf32-cadf-40c6-9cd6-a097df8e797d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6963e8c-816d-464c-98a7-67c145139d24");

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_AdministratorId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c31b735f-80a0-45c5-b11a-4e3df48b3e70", "8232991b-f8b7-4fdf-b96f-c646f95a0e93", "Donor", "DONOR" },
                    { "a92616db-3525-48ca-b23c-6cca91117093", "e091c23a-5b3f-492b-b1e4-05794fb4435f", "Patient", "PATIENT" },
                    { "d9abd3fa-d224-4c62-8297-b3fa829ca55f", "07e57865-594e-4cd9-9529-f0cd27461327", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "1ba0b69b-0f91-4f4b-abce-a6aad7b1483d", "7db2fa55-71be-421a-98f7-b69a686f9a6f", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients",
                column: "Hospital_AdministratorId",
                principalTable: "Hospital_Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
