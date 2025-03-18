using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class ModificarNombreDeTablasEnMinusculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_CategoriaProducto_CategoriaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Presentacion_Idpresentacion",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicoNro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_Unidadmedidanro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialRefreshToken_Usuario_UsuarioId",
                table: "HistorialRefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Ciudad_IdCiudad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_TipoDocumentoIdentidad_IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Articulo_ProductoId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Ubicacion_UbicacionId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Colaborador_ColaboradorId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Empresa_EmpresaId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Persona_ClienteId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Timbrado_TimbradoId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdAnulacion",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdModificacion",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdRegistro",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venta",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoImpuesto",
                table: "TipoImpuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoDocumentoIdentidad",
                table: "TipoDocumentoIdentidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timbrado",
                table: "Timbrado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presentacion",
                table: "Presentacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marca",
                table: "Marca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialRefreshToken",
                table: "HistorialRefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaProducto",
                table: "CategoriaProducto");

            migrationBuilder.RenameTable(
                name: "Venta",
                newName: "venta");

            migrationBuilder.RenameTable(
                name: "UnidadMedida",
                newName: "unidadmedida");

            migrationBuilder.RenameTable(
                name: "Ubicacion",
                newName: "ubicacion");

            migrationBuilder.RenameTable(
                name: "TipoImpuesto",
                newName: "tipoimpuesto");

            migrationBuilder.RenameTable(
                name: "TipoDocumentoIdentidad",
                newName: "tipodocumentoidentidad");

            migrationBuilder.RenameTable(
                name: "Timbrado",
                newName: "timbrado");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "stock");

            migrationBuilder.RenameTable(
                name: "Presentacion",
                newName: "presentacion");

            migrationBuilder.RenameTable(
                name: "Marca",
                newName: "marca");

            migrationBuilder.RenameTable(
                name: "HistorialRefreshToken",
                newName: "historialrefreshToken");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "empresa");

            migrationBuilder.RenameTable(
                name: "Ciudad",
                newName: "ciudad");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "articulo");

            migrationBuilder.RenameTable(
                name: "CategoriaProducto",
                newName: "categoriaproduto");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_UsuarioIdRegistro",
                table: "venta",
                newName: "IX_venta_UsuarioIdRegistro");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_UsuarioIdModificacion",
                table: "venta",
                newName: "IX_venta_UsuarioIdModificacion");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_UsuarioIdAnulacion",
                table: "venta",
                newName: "IX_venta_UsuarioIdAnulacion");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_TimbradoId",
                table: "venta",
                newName: "IX_venta_TimbradoId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_EmpresaId",
                table: "venta",
                newName: "IX_venta_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_ColaboradorId",
                table: "venta",
                newName: "IX_venta_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_ClienteId",
                table: "venta",
                newName: "IX_venta_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_UbicacionId",
                table: "stock",
                newName: "IX_stock_UbicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_ProductoId",
                table: "stock",
                newName: "IX_stock_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialRefreshToken_UsuarioId",
                table: "historialrefreshToken",
                newName: "IX_historialrefreshToken_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_Unidadmedidanro",
                table: "articulo",
                newName: "IX_articulo_Unidadmedidanro");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_TipoServicoNro",
                table: "articulo",
                newName: "IX_articulo_TipoServicoNro");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_TipoimpuestoId",
                table: "articulo",
                newName: "IX_articulo_TipoimpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_MarcaId",
                table: "articulo",
                newName: "IX_articulo_MarcaId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_Idpresentacion",
                table: "articulo",
                newName: "IX_articulo_Idpresentacion");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_CategoriaId",
                table: "articulo",
                newName: "IX_articulo_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venta",
                table: "venta",
                column: "NroVenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unidadmedida",
                table: "unidadmedida",
                column: "Unidadmedidanro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ubicacion",
                table: "ubicacion",
                column: "UbicacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto",
                column: "TipoimpuestoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad",
                column: "IdTipoDocIdentidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_timbrado",
                table: "timbrado",
                column: "TimbradoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock",
                table: "stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_presentacion",
                table: "presentacion",
                column: "Idpresentacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marca",
                table: "marca",
                column: "Marcanro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historialrefreshToken",
                table: "historialrefreshToken",
                column: "HistorialTokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_empresa",
                table: "empresa",
                column: "EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ciudad",
                table: "ciudad",
                column: "IdCiudad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articulo",
                table: "articulo",
                column: "Articulonro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoriaproduto",
                table: "categoriaproduto",
                column: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_TipoServicio_TipoServicoNro",
                table: "articulo",
                column: "TipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_categoriaproduto_CategoriaId",
                table: "articulo",
                column: "CategoriaId",
                principalTable: "categoriaproduto",
                principalColumn: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_marca_MarcaId",
                table: "articulo",
                column: "MarcaId",
                principalTable: "marca",
                principalColumn: "Marcanro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_presentacion_Idpresentacion",
                table: "articulo",
                column: "Idpresentacion",
                principalTable: "presentacion",
                principalColumn: "Idpresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
                table: "articulo",
                column: "TipoimpuestoId",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_unidadmedida_Unidadmedidanro",
                table: "articulo",
                column: "Unidadmedidanro",
                principalTable: "unidadmedida",
                principalColumn: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_historialrefreshToken_Usuario_UsuarioId",
                table: "historialrefreshToken",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_stock_articulo_ProductoId",
                table: "stock",
                column: "ProductoId",
                principalTable: "articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ubicacion_UbicacionId",
                table: "stock",
                column: "UbicacionId",
                principalTable: "ubicacion",
                principalColumn: "UbicacionId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venta_timbrado_TimbradoId",
                table: "venta",
                column: "TimbradoId",
                principalTable: "timbrado",
                principalColumn: "TimbradoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_TipoServicio_TipoServicoNro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_categoriaproduto_CategoriaId",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_marca_MarcaId",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_presentacion_Idpresentacion",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_articulo_unidadmedida_Unidadmedidanro",
                table: "articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_historialrefreshToken_Usuario_UsuarioId",
                table: "historialrefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_ciudad_IdCiudad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_articulo_ProductoId",
                table: "stock");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_ubicacion_UbicacionId",
                table: "stock");

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

            migrationBuilder.DropForeignKey(
                name: "FK_venta_empresa_EmpresaId",
                table: "venta");

            migrationBuilder.DropForeignKey(
                name: "FK_venta_timbrado_TimbradoId",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venta",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unidadmedida",
                table: "unidadmedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ubicacion",
                table: "ubicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_timbrado",
                table: "timbrado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock",
                table: "stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_presentacion",
                table: "presentacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_marca",
                table: "marca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_historialrefreshToken",
                table: "historialrefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_empresa",
                table: "empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ciudad",
                table: "ciudad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articulo",
                table: "articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoriaproduto",
                table: "categoriaproduto");

            migrationBuilder.RenameTable(
                name: "venta",
                newName: "Venta");

            migrationBuilder.RenameTable(
                name: "unidadmedida",
                newName: "UnidadMedida");

            migrationBuilder.RenameTable(
                name: "ubicacion",
                newName: "Ubicacion");

            migrationBuilder.RenameTable(
                name: "tipoimpuesto",
                newName: "TipoImpuesto");

            migrationBuilder.RenameTable(
                name: "tipodocumentoidentidad",
                newName: "TipoDocumentoIdentidad");

            migrationBuilder.RenameTable(
                name: "timbrado",
                newName: "Timbrado");

            migrationBuilder.RenameTable(
                name: "stock",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "presentacion",
                newName: "Presentacion");

            migrationBuilder.RenameTable(
                name: "marca",
                newName: "Marca");

            migrationBuilder.RenameTable(
                name: "historialrefreshToken",
                newName: "HistorialRefreshToken");

            migrationBuilder.RenameTable(
                name: "empresa",
                newName: "Empresa");

            migrationBuilder.RenameTable(
                name: "ciudad",
                newName: "Ciudad");

            migrationBuilder.RenameTable(
                name: "articulo",
                newName: "Articulo");

            migrationBuilder.RenameTable(
                name: "categoriaproduto",
                newName: "CategoriaProducto");

            migrationBuilder.RenameIndex(
                name: "IX_venta_UsuarioIdRegistro",
                table: "Venta",
                newName: "IX_Venta_UsuarioIdRegistro");

            migrationBuilder.RenameIndex(
                name: "IX_venta_UsuarioIdModificacion",
                table: "Venta",
                newName: "IX_Venta_UsuarioIdModificacion");

            migrationBuilder.RenameIndex(
                name: "IX_venta_UsuarioIdAnulacion",
                table: "Venta",
                newName: "IX_Venta_UsuarioIdAnulacion");

            migrationBuilder.RenameIndex(
                name: "IX_venta_TimbradoId",
                table: "Venta",
                newName: "IX_Venta_TimbradoId");

            migrationBuilder.RenameIndex(
                name: "IX_venta_EmpresaId",
                table: "Venta",
                newName: "IX_Venta_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_venta_ColaboradorId",
                table: "Venta",
                newName: "IX_Venta_ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_venta_ClienteId",
                table: "Venta",
                newName: "IX_Venta_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_stock_UbicacionId",
                table: "Stock",
                newName: "IX_Stock_UbicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ProductoId",
                table: "Stock",
                newName: "IX_Stock_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_historialrefreshToken_UsuarioId",
                table: "HistorialRefreshToken",
                newName: "IX_HistorialRefreshToken_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_Unidadmedidanro",
                table: "Articulo",
                newName: "IX_Articulo_Unidadmedidanro");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_TipoServicoNro",
                table: "Articulo",
                newName: "IX_Articulo_TipoServicoNro");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_TipoimpuestoId",
                table: "Articulo",
                newName: "IX_Articulo_TipoimpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_MarcaId",
                table: "Articulo",
                newName: "IX_Articulo_MarcaId");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_Idpresentacion",
                table: "Articulo",
                newName: "IX_Articulo_Idpresentacion");

            migrationBuilder.RenameIndex(
                name: "IX_articulo_CategoriaId",
                table: "Articulo",
                newName: "IX_Articulo_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venta",
                table: "Venta",
                column: "NroVenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida",
                column: "Unidadmedidanro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion",
                column: "UbicacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoImpuesto",
                table: "TipoImpuesto",
                column: "TipoimpuestoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoDocumentoIdentidad",
                table: "TipoDocumentoIdentidad",
                column: "IdTipoDocIdentidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timbrado",
                table: "Timbrado",
                column: "TimbradoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presentacion",
                table: "Presentacion",
                column: "Idpresentacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marca",
                table: "Marca",
                column: "Marcanro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialRefreshToken",
                table: "HistorialRefreshToken",
                column: "HistorialTokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad",
                column: "IdCiudad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "Articulonro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaProducto",
                table: "CategoriaProducto",
                column: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_CategoriaProducto_CategoriaId",
                table: "Articulo",
                column: "CategoriaId",
                principalTable: "CategoriaProducto",
                principalColumn: "Categorianro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Marcanro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Presentacion_Idpresentacion",
                table: "Articulo",
                column: "Idpresentacion",
                principalTable: "Presentacion",
                principalColumn: "Idpresentacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoImpuesto_TipoimpuestoId",
                table: "Articulo",
                column: "TipoimpuestoId",
                principalTable: "TipoImpuesto",
                principalColumn: "TipoimpuestoNro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoServicio_TipoServicoNro",
                table: "Articulo",
                column: "TipoServicoNro",
                principalTable: "TipoServicio",
                principalColumn: "TipoServicoNro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_Unidadmedidanro",
                table: "Articulo",
                column: "Unidadmedidanro",
                principalTable: "UnidadMedida",
                principalColumn: "Unidadmedidanro");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialRefreshToken_Usuario_UsuarioId",
                table: "HistorialRefreshToken",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Stock_Articulo_ProductoId",
                table: "Stock",
                column: "ProductoId",
                principalTable: "Articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Ubicacion_UbicacionId",
                table: "Stock",
                column: "UbicacionId",
                principalTable: "Ubicacion",
                principalColumn: "UbicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Colaborador_ColaboradorId",
                table: "Venta",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Empresa_EmpresaId",
                table: "Venta",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Persona_ClienteId",
                table: "Venta",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Timbrado_TimbradoId",
                table: "Venta",
                column: "TimbradoId",
                principalTable: "Timbrado",
                principalColumn: "TimbradoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdAnulacion",
                table: "Venta",
                column: "UsuarioIdAnulacion",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdModificacion",
                table: "Venta",
                column: "UsuarioIdModificacion",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Usuario_UsuarioIdRegistro",
                table: "Venta",
                column: "UsuarioIdRegistro",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
