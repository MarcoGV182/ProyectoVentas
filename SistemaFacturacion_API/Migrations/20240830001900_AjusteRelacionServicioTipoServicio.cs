using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionServicioTipoServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoServicioTipoServicoNro",
                table: "Articulo");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoServicoNro",
                table: "Articulo",
                column: "TipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicoNro",
                table: "Articulo",
                column: "TipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_TipoServicoNro",
                table: "Articulo");

            migrationBuilder.AddColumn<short>(
                name: "TipoServicioTipoServicoNro",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoServicioTipoServicoNro",
                table: "Articulo",
                column: "TipoServicioTipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicioTipoServicoNro",
                table: "Articulo",
                column: "TipoServicioTipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro");
        }
    }
}
