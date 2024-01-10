using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sisteminha.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Consultas");
        }
    }
}
