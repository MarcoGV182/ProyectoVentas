using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregartablaMovimientodeStockycamposadicionales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "venta",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    UbicacionId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TipoMovimiento = table.Column<int>(type: "integer", nullable: false),
                    DocumentoReferencia = table.Column<string>(type: "text", nullable: true),
                    ReferenciaId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioId = table.Column<string>(type: "text", nullable: true),
                    Comentarios = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientos_articulo_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "articulo",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);                    
                    table.ForeignKey(
                        name: "FK_movimientos_ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "ubicacion",
                        principalColumn: "UbicacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venta_UbicacionId",
                table: "venta",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_ProductoId",
                table: "movimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_StockId",
                table: "movimientos",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_UbicacionId",
                table: "movimientos",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_ubicacion_UbicacionId",
                table: "venta",
                column: "UbicacionId",
                principalTable: "ubicacion",
                principalColumn: "UbicacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_ubicacion_UbicacionId",
                table: "venta");

            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropIndex(
                name: "IX_venta_UbicacionId",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "venta");
        }
    }
}
