using Microsoft.EntityFrameworkCore.Migrations;

namespace St.Marys_Donor.Data.Migrations
{
    public partial class UpdatedDonorModelToHaveNullableFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Health_Information_Donors_DonorId",
                table: "Health_Information");

            migrationBuilder.DropIndex(
                name: "IX_Health_Information_DonorId",
                table: "Health_Information");

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

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Health_Information");

            migrationBuilder.DropColumn(
                name: "OnMedication",
                table: "Health_Information");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Health_Information",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Hasallergies",
                table: "Health_Information",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnMedications",
                table: "Health_Information",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Donors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MedicalId",
                table: "Donors",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32e09b40-c3c0-40fd-94eb-1661858438f4", "f4bab371-c2ed-4603-a129-33976399c34a", "Donor", "DONOR" },
                    { "331020c7-7767-44d9-a79b-ce8085c98c9b", "34060c67-d79a-4aee-820c-8d84538f5593", "Patient", "PATIENT" },
                    { "ea989963-600e-490b-9039-09a98a4dfba6", "20df0665-321b-45bc-b8b9-06c9062676f5", "Hospital Administrator", "HOSPITAL ADMINISTRATOR" },
                    { "11743bad-1f27-4b62-af3c-5aebf38cac2e", "62f70ada-9e26-48da-912d-2314751ff7e1", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_MedicalId",
                table: "Donors",
                column: "MedicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Health_Information_MedicalId",
                table: "Donors",
                column: "MedicalId",
                principalTable: "Health_Information",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Health_Information_MedicalId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_MedicalId",
                table: "Donors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11743bad-1f27-4b62-af3c-5aebf38cac2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32e09b40-c3c0-40fd-94eb-1661858438f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331020c7-7767-44d9-a79b-ce8085c98c9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea989963-600e-490b-9039-09a98a4dfba6");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Health_Information");

            migrationBuilder.DropColumn(
                name: "Hasallergies",
                table: "Health_Information");

            migrationBuilder.DropColumn(
                name: "OnMedications",
                table: "Health_Information");

            migrationBuilder.DropColumn(
                name: "MedicalId",
                table: "Donors");

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Health_Information",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OnMedication",
                table: "Health_Information",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Donors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Health_Information_DonorId",
                table: "Health_Information",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Information_Donors_DonorId",
                table: "Health_Information",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
