using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteennombredecolumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_articulo_Articulonro",
                table: "detalleventa");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventa");

            migrationBuilder.RenameColumn(
                name: "TipoimpuestoNro",
                table: "detalleventa",
                newName: "TipoimpuestoId");

            migrationBuilder.RenameColumn(
                name: "Articulonro",
                table: "detalleventa",
                newName: "ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_TipoimpuestoNro",
                table: "detalleventa",
                newName: "IX_detalleventa_TipoimpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_Articulonro",
                table: "detalleventa",
                newName: "IX_detalleventa_ArticuloId");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "venta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalIVA",
                table: "venta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentajeiva",
                table: "tipoimpuesto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "Baseimponible",
                table: "tipoimpuesto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_articulo_ArticuloId",
                table: "detalleventa",
                column: "ArticuloId",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoId",
                table: "detalleventa",
                column: "TipoimpuestoId",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_articulo_ArticuloId",
                table: "detalleventa");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoId",
                table: "detalleventa");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "TotalIVA",
                table: "venta");

            migrationBuilder.RenameColumn(
                name: "TipoimpuestoId",
                table: "detalleventa",
                newName: "TipoimpuestoNro");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "detalleventa",
                newName: "Articulonro");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_TipoimpuestoId",
                table: "detalleventa",
                newName: "IX_detalleventa_TipoimpuestoNro");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_ArticuloId",
                table: "detalleventa",
                newName: "IX_detalleventa_Articulonro");

            migrationBuilder.AlterColumn<double>(
                name: "Porcentajeiva",
                table: "tipoimpuesto",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Baseimponible",
                table: "tipoimpuesto",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_articulo_Articulonro",
                table: "detalleventa",
                column: "Articulonro",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventa",
                column: "TipoimpuestoNro",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
