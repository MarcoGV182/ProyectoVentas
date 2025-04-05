using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaRango_Timbrados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rango_timbrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nro_Establecimiento = table.Column<int>(type: "integer", nullable: false),
                    Nro_PuntoExp = table.Column<int>(type: "integer", nullable: false),
                    RangoDesde = table.Column<int>(type: "integer", nullable: false),
                    RangoHasta = table.Column<int>(type: "integer", nullable: false),
                    NroActual = table.Column<int>(type: "integer", nullable: false),
                    TimbradoId = table.Column<short>(type: "smallint", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rango_timbrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rango_timbrados_timbrado_TimbradoId",
                        column: x => x.TimbradoId,
                        principalTable: "timbrado",
                        principalColumn: "TimbradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rango_timbrados_TimbradoId",
                table: "rango_timbrados",
                column: "TimbradoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rango_timbrados");
        }
    }
}
