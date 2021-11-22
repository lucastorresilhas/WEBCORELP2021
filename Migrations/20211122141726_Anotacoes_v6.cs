using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCORELP2021.Migrations
{
    public partial class Anotacoes_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_PlanoDeSaude_planodesaudeID",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "PlanoDeSaude");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_planodesaudeID",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "planodesaudeID",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "estoqueID",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "qtd_Estoque",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_estoqueID",
                table: "Consulta",
                column: "estoqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Estoque_estoqueID",
                table: "Consulta",
                column: "estoqueID",
                principalTable: "Estoque",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Estoque_estoqueID",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_estoqueID",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "estoqueID",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "qtd_Estoque",
                table: "Consulta");

            migrationBuilder.AddColumn<int>(
                name: "planodesaudeID",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlanoDeSaude",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacienteid = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    nome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeSaude", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanoDeSaude_Pacientes_Pacienteid",
                        column: x => x.Pacienteid,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_planodesaudeID",
                table: "Pacientes",
                column: "planodesaudeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDeSaude_Pacienteid",
                table: "PlanoDeSaude",
                column: "Pacienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_PlanoDeSaude_planodesaudeID",
                table: "Pacientes",
                column: "planodesaudeID",
                principalTable: "PlanoDeSaude",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
