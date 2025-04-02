using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjustarelacionconDetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_articulo_ArticuloId",
                table: "detalleventa");

            migrationBuilder.DropIndex(
                name: "IX_detalleventa_ArticuloId",
                table: "detalleventa");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "detalleventa",
                newName: "TipoItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "detalleventa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "detalleventa");

            migrationBuilder.RenameColumn(
                name: "TipoItem",
                table: "detalleventa",
                newName: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleventa_ArticuloId",
                table: "detalleventa",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_articulo_ArticuloId",
                table: "detalleventa",
                column: "ArticuloId",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
