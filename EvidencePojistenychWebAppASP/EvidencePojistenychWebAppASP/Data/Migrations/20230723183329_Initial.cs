using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencePojistenychWebAppASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pojistenec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelCislo = table.Column<int>(type: "int", nullable: false),
                    UliceCisloPop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Psc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojistenec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pojisteni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazevPojisteni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastkaPojisteni = table.Column<int>(type: "int", nullable: false),
                    PredmetPojisteni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatnostOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlatnostDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PojistenecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojisteni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pojisteni_Pojistenec_PojistenecId",
                        column: x => x.PojistenecId,
                        principalTable: "Pojistenec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pojisteni_PojistenecId",
                table: "Pojisteni",
                column: "PojistenecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojisteni");

            migrationBuilder.DropTable(
                name: "Pojistenec");
        }
    }
}
