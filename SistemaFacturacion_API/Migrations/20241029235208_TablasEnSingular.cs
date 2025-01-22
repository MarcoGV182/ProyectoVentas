using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class TablasEnSingular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tiposservicios_TipoServicoNro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventas_articulo_Articulonro",
                table: "detalleventas");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventas_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventas");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventas_venta_NroVenta",
                table: "detalleventas");

            migrationBuilder.DropForeignKey(
                name: "FK_historialesrefreshtokens_usuarios_UsuarioId",
                table: "historialesrefreshtokens");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuarios_IdUsuario",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuarios_IdUsuarioMod",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_colaborador_ColaboradorId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuarios_UsuarioIdAnulacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuarios_UsuarioIdModificacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuarios_UsuarioIdRegistro",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tiposservicios",
                table: "tiposservicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleventas",
                table: "detalleventas");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "tiposservicios",
                newName: "tiposervicio");

            migrationBuilder.RenameTable(
                name: "detalleventas",
                newName: "detalleventa");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_ColaboradorId",
                table: "usuario",
                newName: "IX_usuario_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventas_TipoimpuestoNro",
                table: "detalleventa",
                newName: "IX_detalleventa_TipoimpuestoNro");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventas_NroVenta",
                table: "detalleventa",
                newName: "IX_detalleventa_NroVenta");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventas_Articulonro",
                table: "detalleventa",
                newName: "IX_detalleventa_Articulonro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tiposervicio",
                table: "tiposervicio",
                column: "TipoServicoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleventa",
                table: "detalleventa",
                column: "IdDetalle");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "tiposervicio",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_articulo_Articulonro",
                table: "detalleventa",
                column: "Articulonro",
                principalTable: "articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventa",
                column: "TipoimpuestoNro",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_venta_NroVenta",
                table: "detalleventa",
                column: "NroVenta",
                principalTable: "venta",
                principalColumn: "NroVenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historialesrefreshtokens_usuario_UsuarioId",
                table: "historialesrefreshtokens",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuario_IdUsuario",
                table: "persona",
                column: "IdUsuario",
                principalTable: "usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuario_IdUsuarioMod",
                table: "persona",
                column: "IdUsuarioMod",
                principalTable: "usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_colaborador_ColaboradorId",
                table: "usuario",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuario_UsuarioIdAnulacion",
                table: "venta",
                column: "UsuarioIdAnulacion",
                principalTable: "usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuario_UsuarioIdModificacion",
                table: "venta",
                column: "UsuarioIdModificacion",
                principalTable: "usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuario_UsuarioIdRegistro",
                table: "venta",
                column: "UsuarioIdRegistro",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tiposervicio_TipoServicoNro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_articulo_Articulonro",
                table: "detalleventa");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventa");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleventa_venta_NroVenta",
                table: "detalleventa");

            migrationBuilder.DropForeignKey(
                name: "FK_historialesrefreshtokens_usuario_UsuarioId",
                table: "historialesrefreshtokens");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuario_IdUsuario",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_usuario_IdUsuarioMod",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_colaborador_ColaboradorId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuario_UsuarioIdAnulacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuario_UsuarioIdModificacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_usuario_UsuarioIdRegistro",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tiposervicio",
                table: "tiposervicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleventa",
                table: "detalleventa");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "tiposervicio",
                newName: "tiposservicios");

            migrationBuilder.RenameTable(
                name: "detalleventa",
                newName: "detalleventas");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_ColaboradorId",
                table: "usuarios",
                newName: "IX_usuarios_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_TipoimpuestoNro",
                table: "detalleventas",
                newName: "IX_detalleventas_TipoimpuestoNro");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_NroVenta",
                table: "detalleventas",
                newName: "IX_detalleventas_NroVenta");

            migrationBuilder.RenameIndex(
                name: "IX_detalleventa_Articulonro",
                table: "detalleventas",
                newName: "IX_detalleventas_Articulonro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tiposservicios",
                table: "tiposservicios",
                column: "TipoServicoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleventas",
                table: "detalleventas",
                column: "IdDetalle");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tiposservicios_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "tiposservicios",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventas_articulo_Articulonro",
                table: "detalleventas",
                column: "Articulonro",
                principalTable: "articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventas_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventas",
                column: "TipoimpuestoNro",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventas_venta_NroVenta",
                table: "detalleventas",
                column: "NroVenta",
                principalTable: "venta",
                principalColumn: "NroVenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historialesrefreshtokens_usuarios_UsuarioId",
                table: "historialesrefreshtokens",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuarios_IdUsuario",
                table: "persona",
                column: "IdUsuario",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_usuarios_IdUsuarioMod",
                table: "persona",
                column: "IdUsuarioMod",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_colaborador_ColaboradorId",
                table: "usuarios",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuarios_UsuarioIdAnulacion",
                table: "venta",
                column: "UsuarioIdAnulacion",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuarios_UsuarioIdModificacion",
                table: "venta",
                column: "UsuarioIdModificacion",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_usuarios_UsuarioIdRegistro",
                table: "venta",
                column: "UsuarioIdRegistro",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
