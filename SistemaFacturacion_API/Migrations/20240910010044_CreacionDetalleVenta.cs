using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detalleventas",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NroVenta = table.Column<int>(type: "integer", nullable: false),
                    NroItem = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    TipoimpuestoNro = table.Column<int>(type: "integer", nullable: false),
                    Articulonro = table.Column<int>(type: "integer", nullable: false),
                    ImporteIVA = table.Column<decimal>(type: "numeric", nullable: false),
                    ImporteGravado = table.Column<decimal>(type: "numeric", nullable: false),
                    ImporteExento = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleventas", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_detalleventas_articulo_Articulonro",
                        column: x => x.Articulonro,
                        principalTable: "articulo",
                        principalColumn: "Articulonro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleventas_tipoimpuesto_TipoimpuestoNro",
                        column: x => x.TipoimpuestoNro,
                        principalTable: "tipoimpuesto",
                        principalColumn: "TipoimpuestoNro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleventas_venta_NroVenta",
                        column: x => x.NroVenta,
                        principalTable: "venta",
                        principalColumn: "NroVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalleventas_Articulonro",
                table: "detalleventas",
                column: "Articulonro");

            migrationBuilder.CreateIndex(
                name: "IX_detalleventas_NroVenta",
                table: "detalleventas",
                column: "NroVenta");

            migrationBuilder.CreateIndex(
                name: "IX_detalleventas_TipoimpuestoNro",
                table: "detalleventas",
                column: "TipoimpuestoNro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleventas");
        }
    }
}
