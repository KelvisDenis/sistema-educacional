using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEducacional.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTurma",
                table: "DocenteModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurmaModelId",
                table: "DocenteModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTurma",
                table: "AlunoModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurmaModelId",
                table: "AlunoModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocenteModels_TurmaModelId",
                table: "DocenteModels",
                column: "TurmaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModels_TurmaModelId",
                table: "AlunoModels",
                column: "TurmaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoModels_TurmaModels_TurmaModelId",
                table: "AlunoModels",
                column: "TurmaModelId",
                principalTable: "TurmaModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocenteModels_TurmaModels_TurmaModelId",
                table: "DocenteModels",
                column: "TurmaModelId",
                principalTable: "TurmaModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoModels_TurmaModels_TurmaModelId",
                table: "AlunoModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DocenteModels_TurmaModels_TurmaModelId",
                table: "DocenteModels");

            migrationBuilder.DropIndex(
                name: "IX_DocenteModels_TurmaModelId",
                table: "DocenteModels");

            migrationBuilder.DropIndex(
                name: "IX_AlunoModels_TurmaModelId",
                table: "AlunoModels");

            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "DocenteModels");

            migrationBuilder.DropColumn(
                name: "TurmaModelId",
                table: "DocenteModels");

            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "AlunoModels");

            migrationBuilder.DropColumn(
                name: "TurmaModelId",
                table: "AlunoModels");
        }
    }
}
