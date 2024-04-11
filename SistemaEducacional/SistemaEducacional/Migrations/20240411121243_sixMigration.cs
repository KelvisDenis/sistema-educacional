using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEducacional.Migrations
{
    /// <inheritdoc />
    public partial class sixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recuperacao",
                table: "NotasModels");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "NotasModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "NotasModels");

            migrationBuilder.AddColumn<double>(
                name: "Recuperacao",
                table: "NotasModels",
                type: "double precision",
                nullable: true);
        }
    }
}
