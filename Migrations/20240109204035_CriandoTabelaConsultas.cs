using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sisteminha.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaConsultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marcacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retorno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");
        }
    }
}
