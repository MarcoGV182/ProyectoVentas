using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFacturacionWeb.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaArticuloProductoTipoImpuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Villas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Villas",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TipoImpuesto",
                columns: table => new
                {
                    TipoimpuestoNro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Porcentajeiva = table.Column<double>(type: "double precision", nullable: false),
                    Baseimponible = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoImpuesto", x => x.TipoimpuestoNro);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Articulonro = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    Observacion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false, comment: "Estado del Producto,Servicio"),
                    Tipoarticulo = table.Column<int>(type: "integer", nullable: false),
                    Fecharegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Fechaultactualizacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TipoimpuestoNro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Articulonro);
                    table.ForeignKey(
                        name: "FK_Articulo_TipoImpuesto_TipoimpuestoNro",
                        column: x => x.TipoimpuestoNro,
                        principalTable: "TipoImpuesto",
                        principalColumn: "TipoimpuestoNro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Articulonro = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla"),
                    Codigobarra = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Stockminimo = table.Column<int>(type: "integer", nullable: true),
                    Stockactual = table.Column<int>(type: "integer", nullable: false),
                    PrecioCompra = table.Column<double>(type: "double precision", nullable: false),
                    Fechavencimiento = table.Column<DateOnly>(type: "date", nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoimpuestoNro",
                table: "Articulo",
                column: "TipoimpuestoNro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "TipoImpuesto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Villas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Villas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenURL", "MetrosCuadratos", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle villa real", null, new DateTime(2023, 11, 3, 11, 25, 37, 655, DateTimeKind.Local).AddTicks(2919), "", 50, "Villa Real", 5, 0.0 },
                    { 2, "", "Detalle villa nueva 2", null, new DateTime(2023, 11, 3, 11, 25, 37, 655, DateTimeKind.Local).AddTicks(3010), "", 60, "Villa Nueva 2 ", 10, 0.0 }
                });
        }
    }
}
