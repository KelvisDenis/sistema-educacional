using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEducacional.Migrations
{
    /// <inheritdoc />
    public partial class fiveMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotasModel_AlunoModels_AlunoModelId",
                table: "NotasModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotasModel",
                table: "NotasModel");

            migrationBuilder.RenameTable(
                name: "NotasModel",
                newName: "NotasModels");

            migrationBuilder.RenameIndex(
                name: "IX_NotasModel_AlunoModelId",
                table: "NotasModels",
                newName: "IX_NotasModels_AlunoModelId");

            migrationBuilder.AddColumn<int>(
                name: "IdAluno",
                table: "NotasModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotasModels",
                table: "NotasModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasModels_AlunoModels_AlunoModelId",
                table: "NotasModels",
                column: "AlunoModelId",
                principalTable: "AlunoModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotasModels_AlunoModels_AlunoModelId",
                table: "NotasModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotasModels",
                table: "NotasModels");

            migrationBuilder.DropColumn(
                name: "IdAluno",
                table: "NotasModels");

            migrationBuilder.RenameTable(
                name: "NotasModels",
                newName: "NotasModel");

            migrationBuilder.RenameIndex(
                name: "IX_NotasModels_AlunoModelId",
                table: "NotasModel",
                newName: "IX_NotasModel_AlunoModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotasModel",
                table: "NotasModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasModel_AlunoModels_AlunoModelId",
                table: "NotasModel",
                column: "AlunoModelId",
                principalTable: "AlunoModels",
                principalColumn: "Id");
        }
    }
}
