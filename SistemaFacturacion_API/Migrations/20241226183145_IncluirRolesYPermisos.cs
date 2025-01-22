using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class IncluirRolesYPermisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "articulo");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "usuario",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "ubicacion",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "ubicacion",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "colaborador",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioCompra",
                table: "articulo",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioBase",
                table: "articulo",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "preciopromocional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArticuloId = table.Column<int>(type: "integer", nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preciopromocional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preciopromocional_articulo_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "articulo",
                        principalColumn: "Articulonro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rolpermiso",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    PermisoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolpermiso", x => new { x.RolId, x.PermisoId });
                    table.ForeignKey(
                        name: "FK_rolpermiso_permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolpermiso_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_RolId",
                table: "usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_preciopromocional_ArticuloId",
                table: "preciopromocional",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_rolpermiso_PermisoId",
                table: "rolpermiso",
                column: "PermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_RolId",
                table: "usuario",
                column: "RolId",
                principalTable: "rol",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_RolId",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "preciopromocional");

            migrationBuilder.DropTable(
                name: "rolpermiso");

            migrationBuilder.DropTable(
                name: "permiso");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_RolId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ubicacion");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "ubicacion");

            migrationBuilder.DropColumn(
                name: "PrecioBase",
                table: "articulo");

            migrationBuilder.AlterColumn<double>(
                name: "Salario",
                table: "colaborador",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioCompra",
                table: "articulo",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "articulo",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
