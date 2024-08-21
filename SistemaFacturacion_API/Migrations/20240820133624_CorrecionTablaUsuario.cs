using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionTablaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Tiporoductonro",
                table: "TipoProducto",
                newName: "TipoProductonro");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "Usuario",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "TipoProductonro",
                table: "TipoProducto",
                newName: "Tiporoductonro");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
