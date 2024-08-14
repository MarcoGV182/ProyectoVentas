using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class NuevosCamposPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginActualizacion",
                table: "Persona",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginRegistro",
                table: "Persona",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginActualizacion",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "LoginRegistro",
                table: "Persona");
        }
    }
}
