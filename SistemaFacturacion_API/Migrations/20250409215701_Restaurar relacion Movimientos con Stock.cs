using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class RestaurarrelacionMovimientosconStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "StockId",
            table: "movimientos",
            type: "integer",
            nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_StockId",
                table: "movimientos",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Stock_StockId",
                table: "movimientos",
                column: "StockId",
                principalTable: "stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
