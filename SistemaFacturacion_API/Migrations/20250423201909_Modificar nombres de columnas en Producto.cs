using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarnombresdecolumnasenProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_presentacion_Idpresentacion",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_unidadmedida_Unidadmedidanro",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "Unidadmedidanro",
                table: "articulo",
                newName: "UnidadMedidaId");

            migrationBuilder.RenameColumn(
                name: "Idpresentacion",
                table: "articulo",
                newName: "PresentacionId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_Unidadmedidanro",
                table: "articulo",
                newName: "IX_articulo_UnidadMedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_Idpresentacion",
                table: "articulo",
                newName: "IX_articulo_PresentacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_presentacion_PresentacionId",
                table: "articulo",
                column: "PresentacionId",
                principalTable: "presentacion",
                principalColumn: "PresentacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_unidadmedida_UnidadMedidaId",
                table: "articulo",
                column: "UnidadMedidaId",
                principalTable: "unidadmedida",
                principalColumn: "UnidadMedidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_presentacion_PresentacionId",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_unidadmedida_UnidadMedidaId",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "UnidadMedidaId",
                table: "articulo",
                newName: "Unidadmedidanro");

            migrationBuilder.RenameColumn(
                name: "PresentacionId",
                table: "articulo",
                newName: "Idpresentacion");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_UnidadMedidaId",
                table: "articulo",
                newName: "IX_articulo_Unidadmedidanro");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_PresentacionId",
                table: "articulo",
                newName: "IX_articulo_Idpresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_presentacion_Idpresentacion",
                table: "articulo",
                column: "Idpresentacion",
                principalTable: "presentacion",
                principalColumn: "PresentacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_unidadmedida_Unidadmedidanro",
                table: "articulo",
                column: "Unidadmedidanro",
                principalTable: "unidadmedida",
                principalColumn: "UnidadMedidaId");
        }
    }
}
