using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarrelacionconEmpresaaSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers");

            migrationBuilder.AddColumn<short>(
                name: "EmpresaId",
                table: "sucursales",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "aspnetusers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_sucursales_EmpresaId",
                table: "sucursales",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_sucursales_empresa_EmpresaId",
                table: "sucursales",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers");

            migrationBuilder.DropForeignKey(
                name: "FK_sucursales_empresa_EmpresaId",
                table: "sucursales");

            migrationBuilder.DropIndex(
                name: "IX_sucursales_EmpresaId",
                table: "sucursales");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "sucursales");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "aspnetusers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
