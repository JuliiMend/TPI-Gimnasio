using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMantenimientoHistoricoSueldo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoSueldos",
                columns: table => new
                {
                    IdHistoricoSueldo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSueldos", x => x.IdHistoricoSueldo);
                    table.ForeignKey(
                        name: "FK_HistoricoSueldos_Profesores_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesores",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    IdMantenimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinEsperada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.IdMantenimiento);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Maquinas_IdMaquina",
                        column: x => x.IdMaquina,
                        principalTable: "Maquinas",
                        principalColumn: "IdMaquina",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSueldos_IdProfesor_FechaDesde",
                table: "HistoricoSueldos",
                columns: new[] { "IdProfesor", "FechaDesde" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_IdMaquina",
                table: "Mantenimientos",
                column: "IdMaquina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoSueldos");

            migrationBuilder.DropTable(
                name: "Mantenimientos");
        }
    }
}
