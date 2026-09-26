using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class QuitarContrasenaProfesor : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdPlan",
                table: "Socios",
                column: "IdPlan");

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
