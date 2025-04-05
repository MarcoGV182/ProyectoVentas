using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarrelacionesconSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_venta_EmpresaId",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "venta");

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "venta",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "rango_timbrados",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "persona",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "articulo",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_SucursalId",
                table: "venta",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_rango_timbrados_SucursalId",
                table: "rango_timbrados",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_SucursalId",
                table: "persona",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_articulo_SucursalId",
                table: "articulo",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_sucursales_SucursalId",
                table: "articulo",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_sucursales_SucursalId",
                table: "persona",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_rango_timbrados_sucursales_SucursalId",
                table: "rango_timbrados",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_sucursales_SucursalId",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_sucursales_SucursalId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_rango_timbrados_sucursales_SucursalId",
                table: "rango_timbrados");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_venta_SucursalId",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_rango_timbrados_SucursalId",
                table: "rango_timbrados");

            migrationBuilder.DropIndex(
                name: "IX_persona_SucursalId",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_articulo_SucursalId",
                table: "articulo");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "rango_timbrados");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "articulo");

            migrationBuilder.AddColumn<short>(
                name: "EmpresaId",
                table: "venta",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_EmpresaId",
                table: "venta",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "EmpresaId");
        }
    }
}
