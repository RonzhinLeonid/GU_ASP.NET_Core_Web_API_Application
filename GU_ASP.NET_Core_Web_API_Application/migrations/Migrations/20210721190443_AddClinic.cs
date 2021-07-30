using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace migrations.Migrations
{
    public partial class AddClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cats",
                table: "Cats");

            migrationBuilder.RenameTable(
                name: "Cats",
                newName: "Cat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat",
                table: "Cat",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatClinic",
                columns: table => new
                {
                    CatsId = table.Column<int>(type: "integer", nullable: false),
                    ClinicsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatClinic", x => new { x.CatsId, x.ClinicsId });
                    table.ForeignKey(
                        name: "FK_CatClinic_Cat_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatClinic_Clinic_ClinicsId",
                        column: x => x.ClinicsId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatClinic_ClinicsId",
                table: "CatClinic",
                column: "ClinicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatClinic");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat",
                table: "Cat");

            migrationBuilder.RenameTable(
                name: "Cat",
                newName: "Cats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cats",
                table: "Cats",
                column: "Id");
        }
    }
}
