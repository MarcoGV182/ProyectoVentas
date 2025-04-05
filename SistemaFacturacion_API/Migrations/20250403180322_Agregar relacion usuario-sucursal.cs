using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class Agregarrelacionusuariosucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "aspnetusers",
                type: "integer",
                nullable: true,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "aspnetusers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");
        }
    }
}
