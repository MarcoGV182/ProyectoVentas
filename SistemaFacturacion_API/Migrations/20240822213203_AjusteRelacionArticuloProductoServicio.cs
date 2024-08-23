using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionArticuloProductoServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Producto_ProductoId",
                table: "Stock");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.AddColumn<string>(
                name: "Codigobarra",
                table: "Articulo",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaVencimiento",
                table: "Articulo",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Idpresentacion",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Articulo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecioCompra",
                table: "Articulo",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stockactual",
                table: "Articulo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stockminimo",
                table: "Articulo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoArticulo",
                table: "Articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "TipoServicioTipoServicoNro",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TipoServicoNro",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TipoproductoId",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Unidadmedidanro",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_Idpresentacion",
                table: "Articulo",
                column: "Idpresentacion");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_MarcaId",
                table: "Articulo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoproductoId",
                table: "Articulo",
                column: "TipoproductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoServicioTipoServicoNro",
                table: "Articulo",
                column: "TipoServicioTipoServicoNro");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_Unidadmedidanro",
                table: "Articulo",
                column: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Marcanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Presentacion_Idpresentacion",
                table: "Articulo",
                column: "Idpresentacion",
                principalTable: "Presentacion",
                principalColumn: "Idpresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoProducto_TipoproductoId",
                table: "Articulo",
                column: "TipoproductoId",
                principalTable: "TipoProducto",
                principalColumn: "TipoProductonro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicioTipoServicoNro",
                table: "Articulo",
                column: "TipoServicioTipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_Unidadmedidanro",
                table: "Articulo",
                column: "Unidadmedidanro",
                principalTable: "UnidadMedida",
                principalColumn: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Articulo_ProductoId",
                table: "Stock",
                column: "ProductoId",
                principalTable: "Articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Presentacion_Idpresentacion",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoProducto_TipoproductoId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_Unidadmedidanro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Articulo_ProductoId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_Idpresentacion",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_MarcaId",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_TipoproductoId",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_Unidadmedidanro",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Codigobarra",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Idpresentacion",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Stockactual",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Stockminimo",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoArticulo",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoproductoId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Unidadmedidanro",
                table: "Articulo");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Articulonro = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla"),
                    Idpresentacion = table.Column<short>(type: "smallint", nullable: true),
                    MarcaId = table.Column<int>(type: "integer", nullable: true),
                    TipoproductoId = table.Column<short>(type: "smallint", nullable: true),
                    Unidadmedidanro = table.Column<short>(type: "smallint", nullable: true),
                    Codigobarra = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    PrecioCompra = table.Column<double>(type: "double precision", nullable: false),
                    Stockactual = table.Column<int>(type: "integer", nullable: false),
                    Stockminimo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Articulonro);
                    table.ForeignKey(
                        name: "FK_Producto_Articulo_Articulonro",
                        column: x => x.Articulonro,
                        principalTable: "Articulo",
                        principalColumn: "Articulonro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Marcanro");
                    table.ForeignKey(
                        name: "FK_Producto_Presentacion_Idpresentacion",
                        column: x => x.Idpresentacion,
                        principalTable: "Presentacion",
                        principalColumn: "Idpresentacion");
                    table.ForeignKey(
                        name: "FK_Producto_TipoProducto_TipoproductoId",
                        column: x => x.TipoproductoId,
                        principalTable: "TipoProducto",
                        principalColumn: "TipoProductonro");
                    table.ForeignKey(
                        name: "FK_Producto_UnidadMedida_Unidadmedidanro",
                        column: x => x.Unidadmedidanro,
                        principalTable: "UnidadMedida",
                        principalColumn: "Unidadmedidanro");
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Articulonro = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla"),
                    TipoServicioTipoServicoNro = table.Column<short>(type: "smallint", nullable: true),
                    TipoServicoNro = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Articulonro);
                    table.ForeignKey(
                        name: "FK_Servicio_Articulo_Articulonro",
                        column: x => x.Articulonro,
                        principalTable: "Articulo",
                        principalColumn: "Articulonro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicio_TipoServicio_TipoServicioTipoServicoNro",
                        column: x => x.TipoServicioTipoServicoNro,
                        principalTable: "TipoServicio",
                        principalColumn: "TipoServicoNro");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Idpresentacion",
                table: "Producto",
                column: "Idpresentacion");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoproductoId",
                table: "Producto",
                column: "TipoproductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Unidadmedidanro",
                table: "Producto",
                column: "Unidadmedidanro");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_TipoServicioTipoServicoNro",
                table: "Servicio",
                column: "TipoServicioTipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Producto_ProductoId",
                table: "Stock",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
