using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class Modificarcamposparagestiondestock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ubicacion");

            migrationBuilder.DropColumn(
                name: "Stockactual",
                table: "articulo");

            migrationBuilder.AddColumn<bool>(
                name: "Activa",
                table: "ubicacion",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "ubicacion");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "ubicacion",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stockactual",
                table: "articulo",
                type: "integer",
                nullable: true);
        }
    }
}
