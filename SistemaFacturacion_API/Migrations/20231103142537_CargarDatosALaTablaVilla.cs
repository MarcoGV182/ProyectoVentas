using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class CargarDatosALaTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {  

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenURL", "MetrosCuadratos", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle villa real", null, new DateTime(2023, 11, 3, 11, 25, 37, 655, DateTimeKind.Local).AddTicks(2919), "", 50, "Villa Real", 5, 0.0 },
                    { 2, "", "Detalle villa nueva 2", null, new DateTime(2023, 11, 3, 11, 25, 37, 655, DateTimeKind.Local).AddTicks(3010), "", 60, "Villa Nueva 2 ", 10, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion2",
                table: "Villas",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
