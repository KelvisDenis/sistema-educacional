using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEducacional.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DocenteModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenhaTemporaria",
                table: "DocenteModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNota",
                table: "AlunoModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotasModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nota = table.Column<int>(type: "integer", nullable: true),
                    IdDisciplina = table.Column<int>(type: "integer", nullable: true),
                    AlunoModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasModel_AlunoModels_AlunoModelId",
                        column: x => x.AlunoModelId,
                        principalTable: "AlunoModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotasModel_AlunoModelId",
                table: "NotasModel",
                column: "AlunoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotasModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DocenteModels");

            migrationBuilder.DropColumn(
                name: "SenhaTemporaria",
                table: "DocenteModels");

            migrationBuilder.DropColumn(
                name: "IdNota",
                table: "AlunoModels");
        }
    }
}
