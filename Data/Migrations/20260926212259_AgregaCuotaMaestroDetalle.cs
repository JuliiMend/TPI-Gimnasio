using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregaCuotaMaestroDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socios_Planes_PlanId",
                table: "Socios");

            migrationBuilder.DropIndex(
                name: "IX_Socios_PlanId",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Profesores");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    mesAnio = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_Cuotas_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCuota",
                columns: table => new
                {
                    DetalleCuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuotaId = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCuota", x => x.DetalleCuotaId);
                    table.ForeignKey(
                        name: "FK_DetallesCuota_Cuotas_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuotas",
                        principalColumn: "CuotaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdPlan",
                table: "Socios",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_SocioId",
                table: "Cuotas",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCuota_CuotaId",
                table: "DetallesCuota",
                column: "CuotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socios_Planes_IdPlan",
                table: "Socios",
                column: "IdPlan",
                principalTable: "Planes",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socios_Planes_IdPlan",
                table: "Socios");

            migrationBuilder.DropTable(
                name: "DetallesCuota");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Socios_IdPlan",
                table: "Socios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Planes");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Socios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Socios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Socios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_PlanId",
                table: "Socios",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socios_Planes_PlanId",
                table: "Socios",
                column: "PlanId",
                principalTable: "Planes",
                principalColumn: "PlanId");
        }
    }
}
