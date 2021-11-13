using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCORELP2021.Migrations
{
    public partial class Anotacoes_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoDeSaude_Pacientes_pacienteID",
                table: "PlanoDeSaude");

            migrationBuilder.RenameColumn(
                name: "pacienteID",
                table: "PlanoDeSaude",
                newName: "Pacienteid");

            migrationBuilder.RenameIndex(
                name: "IX_PlanoDeSaude_pacienteID",
                table: "PlanoDeSaude",
                newName: "IX_PlanoDeSaude_Pacienteid");

            migrationBuilder.AlterColumn<int>(
                name: "Pacienteid",
                table: "PlanoDeSaude",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "planodesaudeID",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_planodesaudeID",
                table: "Pacientes",
                column: "planodesaudeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_PlanoDeSaude_planodesaudeID",
                table: "Pacientes",
                column: "planodesaudeID",
                principalTable: "PlanoDeSaude",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoDeSaude_Pacientes_Pacienteid",
                table: "PlanoDeSaude",
                column: "Pacienteid",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_PlanoDeSaude_planodesaudeID",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanoDeSaude_Pacientes_Pacienteid",
                table: "PlanoDeSaude");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_planodesaudeID",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "planodesaudeID",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "Pacienteid",
                table: "PlanoDeSaude",
                newName: "pacienteID");

            migrationBuilder.RenameIndex(
                name: "IX_PlanoDeSaude_Pacienteid",
                table: "PlanoDeSaude",
                newName: "IX_PlanoDeSaude_pacienteID");

            migrationBuilder.AlterColumn<int>(
                name: "pacienteID",
                table: "PlanoDeSaude",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoDeSaude_Pacientes_pacienteID",
                table: "PlanoDeSaude",
                column: "pacienteID",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
