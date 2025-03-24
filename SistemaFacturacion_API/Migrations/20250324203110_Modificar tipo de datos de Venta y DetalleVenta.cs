using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificartipodedatosdeVentayDetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioIdRegistro",
                table: "venta",
                type: "text",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioIdModificacion",
                table: "venta",
                type: "text",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioIdAnulacion",
                table: "venta",
                type: "text",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "venta",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "detalleventa",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.AlterColumn<short>(
                name: "UsuarioIdRegistro",
                table: "venta",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "UsuarioIdModificacion",
                table: "venta",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "UsuarioIdAnulacion",
                table: "venta",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "venta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "detalleventa",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
