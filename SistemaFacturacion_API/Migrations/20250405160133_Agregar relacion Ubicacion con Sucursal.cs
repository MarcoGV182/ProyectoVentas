using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarrelacionUbicacionconSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "ubicacion",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "aspnetusertokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "aspnetusertokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "aspnetuserlogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "aspnetuserlogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_SucursalId",
                table: "ubicacion",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ubicacion_sucursales_SucursalId",
                table: "ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_ubicacion_SucursalId",
                table: "ubicacion");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "ubicacion");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "aspnetusertokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "aspnetusertokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "aspnetuserlogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "aspnetuserlogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
