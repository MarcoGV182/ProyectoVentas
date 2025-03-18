using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class NuevoModeloCiudad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marcanro",
                table: "marca",
                newName: "MarcaId");

            migrationBuilder.RenameColumn(
                name: "IdCiudad",
                table: "ciudad",
                newName: "CiudadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "marca",
                newName: "Marcanro");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "ciudad",
                newName: "IdCiudad");
        }
    }
}
