using Microsoft.EntityFrameworkCore.Migrations;

namespace migrations.Migrations
{
    public partial class AddClinic_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropForeignKey(
                name: "FK_CatClinic_Cat_CatsId",
                table: "CatClinic");

            migrationBuilder.DropForeignKey(
                name: "FK_CatClinic_Clinic_ClinicsId",
                table: "CatClinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat",
                table: "Cat");

            migrationBuilder.RenameTable(
                name: "Clinic",
                newName: "Clinics");

            migrationBuilder.RenameTable(
                name: "Cat",
                newName: "Cats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cats",
                table: "Cats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatClinic_Cats_CatsId",
                table: "CatClinic",
                column: "CatsId",
                principalTable: "Cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatClinic_Clinics_ClinicsId",
                table: "CatClinic",
                column: "ClinicsId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatClinic_Cats_CatsId",
                table: "CatClinic");

            migrationBuilder.DropForeignKey(
                name: "FK_CatClinic_Clinics_ClinicsId",
                table: "CatClinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cats",
                table: "Cats");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinic");

            migrationBuilder.RenameTable(
                name: "Cats",
                newName: "Cat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat",
                table: "Cat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatClinic_Cat_CatsId",
                table: "CatClinic",
                column: "CatsId",
                principalTable: "Cat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatClinic_Clinic_ClinicsId",
                table: "CatClinic",
                column: "ClinicsId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
