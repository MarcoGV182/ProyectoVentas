using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaPersonaColaboradorUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo");

            migrationBuilder.AlterColumn<int>(
                name: "TipoimpuestoId",
                table: "Articulo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Tipoarticulo",
                table: "Articulo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecharegistro",
                table: "Articulo",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    Nrodocumento = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Fechanacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    Fecharegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Ultfechaactualizacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Fechaalta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Fechabaja = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "integer", nullable: false),
                    Fechaingreso = table.Column<DateOnly>(type: "date", nullable: false),
                    Fechaegreso = table.Column<DateOnly>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Salario = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Colaborador_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_UsuarioId",
                table: "Colaborador",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo",
                column: "TipoimpuestoId",
                principalTable: "TipoImpuesto",
                principalColumn: "TipoimpuestoNro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "TipoimpuestoId",
                table: "Articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tipoarticulo",
                table: "Articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecharegistro",
                table: "Articulo",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo",
                column: "TipoimpuestoId",
                principalTable: "TipoImpuesto",
                principalColumn: "TipoimpuestoNro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
