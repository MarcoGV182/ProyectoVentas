using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeTablaServicioTipoServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Presentacion_PresentacionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_PresentacionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "PresentacionId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UnidadMedidaId",
                table: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Fechavencimiento",
                table: "Producto",
                newName: "FechaVencimiento");

            migrationBuilder.AddColumn<short>(
                name: "Idpresentacion",
                table: "Producto",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Idpresentacion",
                table: "Presentacion",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    TipoServicoNro = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.TipoServicoNro);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Articulonro = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla"),
                    TipoServicoNro = table.Column<short>(type: "smallint", nullable: false),
                    TipoServicioTipoServicoNro = table.Column<short>(type: "smallint", nullable: true)
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
                name: "IX_Servicio_TipoServicioTipoServicoNro",
                table: "Servicio",
                column: "TipoServicioTipoServicoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Presentacion_Idpresentacion",
                table: "Producto",
                column: "Idpresentacion",
                principalTable: "Presentacion",
                principalColumn: "Idpresentacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Presentacion_Idpresentacion",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "TipoServicio");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Idpresentacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Idpresentacion",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "FechaVencimiento",
                table: "Producto",
                newName: "Fechavencimiento");

            migrationBuilder.AddColumn<int>(
                name: "PresentacionId",
                table: "Producto",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Idpresentacion",
                table: "Presentacion",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "UnidadMedidaId",
                table: "Articulo",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PresentacionId",
                table: "Producto",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_UnidadMedidaId",
                table: "Articulo",
                column: "UnidadMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaId",
                table: "Articulo",
                column: "UnidadMedidaId",
                principalTable: "UnidadMedida",
                principalColumn: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Presentacion_PresentacionId",
                table: "Producto",
                column: "PresentacionId",
                principalTable: "Presentacion",
                principalColumn: "Idpresentacion");
        }
    }
}
