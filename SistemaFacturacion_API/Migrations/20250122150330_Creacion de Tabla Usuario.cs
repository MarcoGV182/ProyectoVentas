using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CreaciondeTablaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador");

            migrationBuilder.DropIndex(
                name: "IX_colaborador_PersonaId",
                table: "colaborador");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "colaborador");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fechaingreso",
                table: "colaborador",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fechaegreso",
                table: "colaborador",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "aspnetusers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "aspnetusers",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetusers_ColaboradorId",
                table: "aspnetusers",
                column: "ColaboradorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_colaborador_ColaboradorId",
                table: "aspnetusers",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_colaborador_ColaboradorId",
                table: "aspnetusers");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador");

            migrationBuilder.DropIndex(
                name: "IX_aspnetusers_ColaboradorId",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "aspnetusers");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fechaingreso",
                table: "colaborador",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fechaegreso",
                table: "colaborador",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "colaborador",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_PersonaId",
                table: "colaborador",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
