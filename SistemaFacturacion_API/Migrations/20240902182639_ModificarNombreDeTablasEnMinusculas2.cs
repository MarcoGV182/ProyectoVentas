using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarNombreDeTablasEnMinusculas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_TipoServicio_TipoServicoNro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Persona_PersonaId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_historialrefreshToken_Usuario_UsuarioId",
                table: "historialrefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_IdUsuario",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_IdUsuarioMod",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_ciudad_IdCiudad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_Colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_Persona_ClienteId",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_Usuario_UsuarioIdAnulacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_Usuario_UsuarioIdModificacion",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_Usuario_UsuarioIdRegistro",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoServicio",
                table: "TipoServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_historialrefreshToken",
                table: "historialrefreshToken");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "persona");

            migrationBuilder.RenameTable(
                name: "Colaborador",
                newName: "colaborador");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "TipoServicio",
                newName: "tiposservicios");

            migrationBuilder.RenameTable(
                name: "historialrefreshToken",
                newName: "historialesrefreshtokens");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_IdUsuarioMod",
                table: "persona",
                newName: "IX_persona_IdUsuarioMod");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_IdUsuario",
                table: "persona",
                newName: "IX_persona_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_IdTipoDocIdentidad",
                table: "persona",
                newName: "IX_persona_IdTipoDocIdentidad");

            migrationBuilder.RenameIndex(
                name: "IX_Persona_IdCiudad",
                table: "persona",
                newName: "IX_persona_IdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_PersonaId",
                table: "colaborador",
                newName: "IX_colaborador_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_ColaboradorId",
                table: "usuarios",
                newName: "IX_usuarios_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_historialrefreshToken_UsuarioId",
                table: "historialesrefreshtokens",
                newName: "IX_historialesrefreshtokens_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persona",
                table: "persona",
                column: "PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador",
                column: "ColaboradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tiposservicios",
                table: "tiposservicios",
                column: "TipoServicoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historialesrefreshtokens",
                table: "historialesrefreshtokens",
                column: "HistorialTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tiposservicios_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "tiposservicios",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_colaborador_persona_PersonaId",
                table: "colaborador",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historialesrefreshtokens_usuarios_UsuarioId",
                table: "historialesrefreshtokens",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_IdCiudad",
                table: "persona",
                column: "IdCiudad",
                principalTable: "ciudad",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona",
                column: "IdTipoDocIdentidad",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "IdTipoDocIdentidad");

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
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_persona_ClienteId",
                table: "venta",
                column: "ClienteId",
                principalTable: "persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tiposservicios_TipoServicoNro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_colaborador_persona_PersonaId",
                table: "colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_historialesrefreshtokens_usuarios_UsuarioId",
                table: "historialesrefreshtokens");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_IdCiudad",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona");

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
                name: "FK_venta_colaborador_ColaboradorId",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_persona_ClienteId",
                table: "venta");

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
                name: "PK_persona",
                table: "persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colaborador",
                table: "colaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tiposservicios",
                table: "tiposservicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_historialesrefreshtokens",
                table: "historialesrefreshtokens");

            migrationBuilder.RenameTable(
                name: "persona",
                newName: "Persona");

            migrationBuilder.RenameTable(
                name: "colaborador",
                newName: "Colaborador");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "tiposservicios",
                newName: "TipoServicio");

            migrationBuilder.RenameTable(
                name: "historialesrefreshtokens",
                newName: "historialrefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_persona_IdUsuarioMod",
                table: "Persona",
                newName: "IX_Persona_IdUsuarioMod");

            migrationBuilder.RenameIndex(
                name: "IX_persona_IdUsuario",
                table: "Persona",
                newName: "IX_Persona_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_persona_IdTipoDocIdentidad",
                table: "Persona",
                newName: "IX_Persona_IdTipoDocIdentidad");

            migrationBuilder.RenameIndex(
                name: "IX_persona_IdCiudad",
                table: "Persona",
                newName: "IX_Persona_IdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_colaborador_PersonaId",
                table: "Colaborador",
                newName: "IX_Colaborador_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_ColaboradorId",
                table: "Usuario",
                newName: "IX_Usuario_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_historialesrefreshtokens_UsuarioId",
                table: "historialrefreshToken",
                newName: "IX_historialrefreshToken_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaborador",
                table: "Colaborador",
                column: "ColaboradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoServicio",
                table: "TipoServicio",
                column: "TipoServicoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historialrefreshToken",
                table: "historialrefreshToken",
                column: "HistorialTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_TipoServicio_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Persona_PersonaId",
                table: "Colaborador",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historialrefreshToken_Usuario_UsuarioId",
                table: "historialrefreshToken",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ciudad_IdCiudad",
                table: "Persona",
                column: "IdCiudad",
                principalTable: "ciudad",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "Persona",
                column: "IdTipoDocIdentidad",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "IdTipoDocIdentidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Colaborador_ColaboradorId",
                table: "Usuario",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Colaborador_ColaboradorId",
                table: "venta",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Persona_ClienteId",
                table: "venta",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Usuario_UsuarioIdAnulacion",
                table: "venta",
                column: "UsuarioIdAnulacion",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Usuario_UsuarioIdModificacion",
                table: "venta",
                column: "UsuarioIdModificacion",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Usuario_UsuarioIdRegistro",
                table: "venta",
                column: "UsuarioIdRegistro",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
