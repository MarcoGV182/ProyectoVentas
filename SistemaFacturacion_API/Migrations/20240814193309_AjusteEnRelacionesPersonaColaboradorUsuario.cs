using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEnRelacionesPersonaColaboradorUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Usuario_UsuarioId",
                table: "Colaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_UsuarioId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Salario",
                table: "Colaborador",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Colaborador",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ColaboradorId",
                table: "Usuario",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_PersonaId",
                table: "Colaborador",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ColaboradorId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_PersonaId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Colaborador");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Salario",
                table: "Colaborador",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Colaborador",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_UsuarioId",
                table: "Colaborador",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Usuario_UsuarioId",
                table: "Colaborador",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
