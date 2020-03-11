using Microsoft.EntityFrameworkCore.Migrations;

namespace StMarys_Donor.Migrations
{
    public partial class HospitalsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hospital_Administrators",
                table: "Hospital_Administrators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62139b69-5080-43cc-a943-853888ca0fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76c06c8b-3f1e-44b1-96fb-c92e024f22b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d2b7e0a-e5e9-49da-85ce-c240f06be5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da282b1-9106-4fb4-a2e1-f4f27d2b0a96");

            migrationBuilder.DropColumn(
                name: "Hospital_AdministratorId",
                table: "Hospital_Administrators");

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_AdministratorId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Hospital_Administrators",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hospital_Administrators",
                table: "Hospital_Administrators",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a4c00f5-97a3-4c8a-8e39-8ecc6c7cdd0d", "f5e806fe-b2bf-4a80-a978-6f28ac8dec37", "Donor", "DONOR" },
                    { "3d396153-c38e-45ba-8f45-99bab6b54ed4", "524f3f2c-b78b-4b6f-89ba-8d428ed73654", "Patient", "PATIENT" },
                    { "6b6f214a-66ca-4dff-b602-5eb3b6005178", "5af8d804-d55a-4130-9ed0-874966c93672", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "a18bd94d-96b6-41b2-b25c-986ecd831ae1", "63db1f1e-da3a-4290-b4ef-f4c79130b716", "Administrator", "ADMINISTRATOR" }
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hospital_Administrators",
                table: "Hospital_Administrators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a4c00f5-97a3-4c8a-8e39-8ecc6c7cdd0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d396153-c38e-45ba-8f45-99bab6b54ed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b6f214a-66ca-4dff-b602-5eb3b6005178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18bd94d-96b6-41b2-b25c-986ecd831ae1");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Hospital_Administrators");

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_AdministratorId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hospital_AdministratorId",
                table: "Hospital_Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hospital_Administrators",
                table: "Hospital_Administrators",
                column: "Hospital_AdministratorId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76c06c8b-3f1e-44b1-96fb-c92e024f22b4", "70879c45-a366-46e9-b2bc-173ee96a7c06", "Donor", "DONOR" },
                    { "9da282b1-9106-4fb4-a2e1-f4f27d2b0a96", "d2c08357-d73a-49f4-a19b-af1fae88e3f0", "Patient", "PATIENT" },
                    { "8d2b7e0a-e5e9-49da-85ce-c240f06be5bf", "460f5248-6023-460c-aa55-cc6dd65150dd", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "62139b69-5080-43cc-a943-853888ca0fd9", "5f44b325-5a3f-400e-b40e-7625c23e1a1e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospital_Administrators_Hospital_AdministratorId",
                table: "Patients",
                column: "Hospital_AdministratorId",
                principalTable: "Hospital_Administrators",
                principalColumn: "Hospital_AdministratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
