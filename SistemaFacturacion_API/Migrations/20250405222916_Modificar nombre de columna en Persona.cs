using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarnombredecolumnaenPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_IdCiudad",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_persona_IdCiudad",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_persona_IdTipoDocIdentidad",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "IdTipoDocIdentidad",
                table: "persona");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioMod",
                table: "persona",
                newName: "TipoDocIdentidadId");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "persona",
                newName: "CiudadId");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "venta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "ubicacion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioIdMod",
                table: "persona",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "persona",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_CiudadId",
                table: "persona",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_TipoDocIdentidadId",
                table: "persona",
                column: "TipoDocIdentidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_CiudadId",
                table: "persona",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipodocumentoidentidad_TipoDocIdentidadId",
                table: "persona",
                column: "TipoDocIdentidadId",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_CiudadId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_tipodocumentoidentidad_TipoDocIdentidadId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_persona_CiudadId",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_persona_TipoDocIdentidadId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "UsuarioIdMod",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "persona");

            migrationBuilder.RenameColumn(
                name: "TipoDocIdentidadId",
                table: "persona",
                newName: "IdUsuarioMod");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "persona",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "venta",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "ubicacion",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<short>(
                name: "IdCiudad",
                table: "persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdTipoDocIdentidad",
                table: "persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdCiudad",
                table: "persona",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoDocIdentidad",
                table: "persona",
                column: "IdTipoDocIdentidad");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_IdCiudad",
                table: "persona",
                column: "IdCiudad",
                principalTable: "ciudad",
                principalColumn: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona",
                column: "IdTipoDocIdentidad",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_sucursales_SucursalId",
                table: "venta",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");
        }
    }
}
