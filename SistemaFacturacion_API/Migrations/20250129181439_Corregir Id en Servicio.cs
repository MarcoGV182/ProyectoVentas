using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CorregirIdenServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicoNro",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "TipoServicoNro",
                table: "articulo",
                newName: "TipoServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_TipoServicoNro",
                table: "articulo",
                newName: "IX_articulo_TipoServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicioId",
                table: "articulo",
                column: "TipoServicioId",
                principalTable: "tiposervicio",
                principalColumn: "TipoServicioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicioId",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "TipoServicioId",
                table: "articulo",
                newName: "TipoServicoNro");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_TipoServicioId",
                table: "articulo",
                newName: "IX_articulo_TipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "tiposervicio",
                principalColumn: "TipoServicioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
