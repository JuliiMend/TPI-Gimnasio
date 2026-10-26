using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAdministradorActividadClase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.IdActividad);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.IdClase);
                    table.ForeignKey(
                        name: "FK_Clases_Actividades_IdActividad",
                        column: x => x.IdActividad,
                        principalTable: "Actividades",
                        principalColumn: "IdActividad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clases_Profesores_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesores",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clases_Turnos_IdTurno",
                        column: x => x.IdTurno,
                        principalTable: "Turnos",
                        principalColumn: "IdTurno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanActividades",
                columns: table => new
                {
                    ActividadesIdActividad = table.Column<int>(type: "int", nullable: false),
                    PlanesPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanActividades", x => new { x.ActividadesIdActividad, x.PlanesPlanId });
                    table.ForeignKey(
                        name: "FK_PlanActividades_Actividades_ActividadesIdActividad",
                        column: x => x.ActividadesIdActividad,
                        principalTable: "Actividades",
                        principalColumn: "IdActividad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanActividades_Planes_PlanesPlanId",
                        column: x => x.PlanesPlanId,
                        principalTable: "Planes",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_UsuarioId",
                table: "Administradores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdActividad",
                table: "Clases",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdProfesor",
                table: "Clases",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdTurno",
                table: "Clases",
                column: "IdTurno");

            migrationBuilder.CreateIndex(
                name: "IX_PlanActividades_PlanesPlanId",
                table: "PlanActividades",
                column: "PlanesPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "PlanActividades");

            migrationBuilder.DropTable(
                name: "Actividades");
        }
    }
}
