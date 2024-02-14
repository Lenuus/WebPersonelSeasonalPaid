using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPersonelSeasonalPaid.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryPrims");

            migrationBuilder.AddColumn<decimal>(
                name: "Prim",
                table: "PersonelSeasons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "PersonelSeasons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prim",
                table: "PersonelSeasons");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "PersonelSeasons");

            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "Personels");

            migrationBuilder.CreateTable(
                name: "SalaryPrims",
                columns: table => new
                {
                    SalaryPrimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryPrims", x => x.SalaryPrimId);
                    table.ForeignKey(
                        name: "FK_SalaryPrims_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId");
                    table.ForeignKey(
                        name: "FK_SalaryPrims_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPrims_PersonelId",
                table: "SalaryPrims",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPrims_SeasonId",
                table: "SalaryPrims",
                column: "SeasonId");
        }
    }
}
