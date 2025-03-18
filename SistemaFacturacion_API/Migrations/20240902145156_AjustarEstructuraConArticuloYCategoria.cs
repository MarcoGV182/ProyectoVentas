using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjustarEstructuraConArticuloYCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_CategoriaId",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "CategoriaProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaProducto",
                table: "CategoriaProducto",
                column: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_CategoriaProducto_CategoriaId",
                table: "Articulo",
                column: "CategoriaId",
                principalTable: "CategoriaProducto",
                principalColumn: "Categorianro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_CategoriaProducto_CategoriaId",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaProducto",
                table: "CategoriaProducto");

            migrationBuilder.RenameTable(
                name: "CategoriaProducto",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_CategoriaId",
                table: "Articulo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Categorianro");
        }
    }
}
