using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarenVentaqueempresaIdseaobligatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta");

            migrationBuilder.AlterColumn<short>(
                name: "EmpresaId",
                table: "venta",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta");

            migrationBuilder.AlterColumn<short>(
                name: "EmpresaId",
                table: "venta",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
