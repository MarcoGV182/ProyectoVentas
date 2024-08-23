using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTablaArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoArticulo",
                table: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Tipoarticulo",
                table: "Articulo",
                newName: "TipoArticulo");

            migrationBuilder.AlterColumn<int>(
                name: "TipoArticulo",
                table: "Articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoArticulo",
                table: "Articulo",
                newName: "Tipoarticulo");

            migrationBuilder.AlterColumn<int>(
                name: "Tipoarticulo",
                table: "Articulo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TipoArticulo",
                table: "Articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
