using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEducacional.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Nota",
                table: "NotasModel",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Recuperacao",
                table: "NotasModel",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AlunoModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenhaTemporaria",
                table: "AlunoModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recuperacao",
                table: "NotasModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AlunoModels");

            migrationBuilder.DropColumn(
                name: "SenhaTemporaria",
                table: "AlunoModels");

            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "NotasModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
