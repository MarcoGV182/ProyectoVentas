using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarnombredeiddeventaenDetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_venta_NroVenta",
                table: "detalleventa");

            migrationBuilder.RenameColumn(
                name: "NroVenta",
                table: "detalleventa",
                newName: "VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_NroVenta",
                table: "detalleventa",
                newName: "IX_detalleventa_VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_venta_VentaId",
                table: "detalleventa",
                column: "VentaId",
                principalTable: "venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_venta_VentaId",
                table: "detalleventa");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "detalleventa",
                newName: "NroVenta");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_VentaId",
                table: "detalleventa",
                newName: "IX_detalleventa_NroVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_venta_NroVenta",
                table: "detalleventa",
                column: "NroVenta",
                principalTable: "venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
