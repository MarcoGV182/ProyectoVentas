using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CorregirIdsentablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_historialesrefreshtokens",
                table: "historialesrefreshtokens");

            migrationBuilder.RenameTable(
                name: "historialesrefreshtokens",
                newName: "HistorialRefreshToken");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId",
                table: "tiposervicio",
                newName: "TipoServicioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialRefreshToken",
                table: "HistorialRefreshToken",
                column: "HistorialTokenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialRefreshToken",
                table: "HistorialRefreshToken");

            migrationBuilder.RenameTable(
                name: "HistorialRefreshToken",
                newName: "historialesrefreshtokens");

            migrationBuilder.RenameColumn(
                name: "TipoServicioId",
                table: "tiposervicio",
                newName: "TipoServicoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historialesrefreshtokens",
                table: "historialesrefreshtokens",
                column: "HistorialTokenId");
        }
    }
}
