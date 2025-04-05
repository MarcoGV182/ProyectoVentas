using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarlatablaSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "aspnetusers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sucursales",
                columns: table => new
                {
                    SucursalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sucursales", x => x.SucursalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aspnetusers_SucursalId",
                table: "aspnetusers",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers",
                column: "SucursalId",
                principalTable: "sucursales",
                principalColumn: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_sucursales_SucursalId",
                table: "aspnetusers");

            migrationBuilder.DropTable(
                name: "sucursales");

            migrationBuilder.DropIndex(
                name: "IX_aspnetusers_SucursalId",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "aspnetusers");
        }
    }
}
