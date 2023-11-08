using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacionWeb.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablasRelacionadasProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoNro",
                table: "Articulo");

            migrationBuilder.RenameColumn(
                name: "TipoimpuestoNro",
                table: "Articulo",
                newName: "TipoimpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_TipoimpuestoNro",
                table: "Articulo",
                newName: "IX_Articulo_TipoimpuestoId");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Producto",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentacionId",
                table: "Producto",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TipoproductoId",
                table: "Producto",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Unidadmedidanro",
                table: "Producto",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Articulo",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                comment: "Estado del Producto,Servicio",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldComment: "Estado del Producto,Servicio");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<short>(
                name: "UnidadMedidaId",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Marcanro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Marcanro);
                });

            migrationBuilder.CreateTable(
                name: "Presentacion",
                columns: table => new
                {
                    Idpresentacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentacion", x => x.Idpresentacion);
                });

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                columns: table => new
                {
                    Tiporoductonro = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.Tiporoductonro);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    UbicacionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.UbicacionId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    Unidadmedidanro = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.Unidadmedidanro);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    UbicacionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Articulonro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "UbicacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PresentacionId",
                table: "Producto",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoproductoId",
                table: "Producto",
                column: "TipoproductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Unidadmedidanro",
                table: "Producto",
                column: "Unidadmedidanro");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_UnidadMedidaId",
                table: "Articulo",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductoId",
                table: "Stock",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UbicacionId",
                table: "Stock",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo",
                column: "TipoimpuestoId",
                principalTable: "TipoImpuesto",
                principalColumn: "TipoimpuestoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaId",
                table: "Articulo",
                column: "UnidadMedidaId",
                principalTable: "UnidadMedida",
                principalColumn: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Marca_MarcaId",
                table: "Producto",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Marcanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Presentacion_PresentacionId",
                table: "Producto",
                column: "PresentacionId",
                principalTable: "Presentacion",
                principalColumn: "Idpresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoProducto_TipoproductoId",
                table: "Producto",
                column: "TipoproductoId",
                principalTable: "TipoProducto",
                principalColumn: "Tiporoductonro");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_UnidadMedida_Unidadmedidanro",
                table: "Producto",
                column: "Unidadmedidanro",
                principalTable: "UnidadMedida",
                principalColumn: "Unidadmedidanro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Marca_MarcaId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Presentacion_PresentacionId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoProducto_TipoproductoId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_UnidadMedida_Unidadmedidanro",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Presentacion");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "TipoProducto");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_PresentacionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_TipoproductoId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Unidadmedidanro",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PresentacionId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "TipoproductoId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Unidadmedidanro",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.RenameColumn(
                name: "TipoimpuestoId",
                table: "Articulo",
                newName: "TipoimpuestoNro");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_TipoimpuestoId",
                table: "Articulo",
                newName: "IX_Articulo_TipoimpuestoNro");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Articulo",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "Estado del Producto,Servicio",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldComment: "Estado del Producto,Servicio");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoNro",
                table: "Articulo",
                column: "TipoimpuestoNro",
                principalTable: "TipoImpuesto",
                principalColumn: "TipoimpuestoNro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
