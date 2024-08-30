using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CreaciondeEmpresaCiudadTipoDocumentoIdentidadVentaTimbrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginActualizacion",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "LoginRegistro",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "Fechanacimiento",
                table: "Persona",
                newName: "FechaNacimiento");

            migrationBuilder.AlterColumn<short>(
                name: "UsuarioId",
                table: "Usuario",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecharegistro",
                table: "Persona",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Persona",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdCiudad",
                table: "Persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdTipoDocIdentidad",
                table: "Persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdUsuario",
                table: "Persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdUsuarioMod",
                table: "Persona",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Marca",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "UsuarioId",
                table: "HistorialRefreshToken",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    IdCiudad = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.IdCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<short>(type: "smallint", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Denominacion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    RUC = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Estado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Timbrado",
                columns: table => new
                {
                    TimbradoId = table.Column<short>(type: "smallint", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    FechaInicioVigencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaFinVigencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TipoTimbrado = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false, comment: "Puede ser Autoimprenta Manual Electronico"),
                    Estado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timbrado", x => x.TimbradoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentoIdentidad",
                columns: table => new
                {
                    IdTipoDocIdentidad = table.Column<short>(type: "smallint", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentoIdentidad", x => x.IdTipoDocIdentidad);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    NroVenta = table.Column<int>(type: "integer", nullable: false, comment: "Id de la tabla")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NroFactura = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Establecimiento = table.Column<short>(type: "smallint", nullable: false),
                    PuntoExpedicion = table.Column<short>(type: "smallint", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    TimbradoId = table.Column<short>(type: "smallint", nullable: false),
                    EsAutoimprenta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Estado = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UsuarioIdRegistro = table.Column<short>(type: "smallint", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioIdModificacion = table.Column<short>(type: "smallint", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioIdAnulacion = table.Column<short>(type: "smallint", nullable: true),
                    EmpresaId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.NroVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Timbrado_TimbradoId",
                        column: x => x.TimbradoId,
                        principalTable: "Timbrado",
                        principalColumn: "TimbradoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_UsuarioIdAnulacion",
                        column: x => x.UsuarioIdAnulacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_UsuarioIdModificacion",
                        column: x => x.UsuarioIdModificacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_UsuarioIdRegistro",
                        column: x => x.UsuarioIdRegistro,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdCiudad",
                table: "Persona",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoDocIdentidad",
                table: "Persona",
                column: "IdTipoDocIdentidad");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdUsuario",
                table: "Persona",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdUsuarioMod",
                table: "Persona",
                column: "IdUsuarioMod");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ColaboradorId",
                table: "Venta",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_EmpresaId",
                table: "Venta",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_TimbradoId",
                table: "Venta",
                column: "TimbradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioIdAnulacion",
                table: "Venta",
                column: "UsuarioIdAnulacion");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioIdModificacion",
                table: "Venta",
                column: "UsuarioIdModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioIdRegistro",
                table: "Venta",
                column: "UsuarioIdRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Ciudad_IdCiudad",
                table: "Persona",
                column: "IdCiudad",
                principalTable: "Ciudad",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_TipoDocumentoIdentidad_IdTipoDocIdentidad",
                table: "Persona",
                column: "IdTipoDocIdentidad",
                principalTable: "TipoDocumentoIdentidad",
                principalColumn: "IdTipoDocIdentidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Usuario_IdUsuario",
                table: "Persona",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Usuario_IdUsuarioMod",
                table: "Persona",
                column: "IdUsuarioMod",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Ciudad_IdCiudad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_TipoDocumentoIdentidad_IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_IdUsuario",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_IdUsuarioMod",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "TipoDocumentoIdentidad");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Timbrado");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdCiudad",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdUsuario",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdUsuarioMod",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "IdUsuarioMod",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Persona",
                newName: "Fechanacimiento");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecharegistro",
                table: "Persona",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fechanacimiento",
                table: "Persona",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginActualizacion",
                table: "Persona",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginRegistro",
                table: "Persona",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Marca",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "HistorialRefreshToken",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
