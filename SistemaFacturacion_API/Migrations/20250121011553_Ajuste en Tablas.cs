using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteenTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
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
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_preciopromocional_articulo_ArticuloId",
                table: "preciopromocional");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_articulo_ProductoId",
                table: "stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venta",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articulo",
                table: "articulo");

            migrationBuilder.DropColumn(
                name: "NroVenta",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "TipoimpuestoNro",
                table: "tipoimpuesto");

            migrationBuilder.DropColumn(
                name: "IdTipoDocIdentidad",
                table: "tipodocumentoidentidad");

            migrationBuilder.DropColumn(
                name: "Articulonro",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "Unidadmedidanro",
                table: "unidadmedida",
                newName: "UnidadMedidaId");

            migrationBuilder.RenameColumn(
                name: "TipoServicoNro",
                table: "tiposervicio",
                newName: "TipoServicoId");

            migrationBuilder.RenameColumn(
                name: "Idpresentacion",
                table: "presentacion",
                newName: "PresentacionId");

            migrationBuilder.RenameColumn(
                name: "Categorianro",
                table: "categoriaproduto",
                newName: "CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "venta",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "TipoimpuestoId",
                table: "tipoimpuesto",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "TipoDocIdentidadId",
                table: "tipodocumentoidentidad",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "TipoTimbrado",
                table: "timbrado",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldComment: "Puede ser Autoimprenta Manual Electronico");

            migrationBuilder.AlterColumn<short>(
                name: "TimbradoId",
                table: "timbrado",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<short>(
                name: "EmpresaId",
                table: "empresa",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<short>(
                name: "TipoimpuestoNro",
                table: "detalleventa",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdDetalle",
                table: "detalleventa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<short>(
                name: "TipoimpuestoId",
                table: "articulo",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "articulo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldComment: "Estado del Producto,Servicio");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_venta",
                table: "venta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto",
                column: "TipoimpuestoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad",
                column: "TipoDocIdentidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articulo",
                table: "articulo",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
                table: "articulo",
                column: "TipoimpuestoId",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_articulo_Articulonro",
                table: "detalleventa",
                column: "Articulonro",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_tipoimpuesto_TipoimpuestoNro",
                table: "detalleventa",
                column: "TipoimpuestoNro",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleventa_venta_NroVenta",
                table: "detalleventa",
                column: "NroVenta",
                principalTable: "venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona",
                column: "IdTipoDocIdentidad",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "TipoDocIdentidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_preciopromocional_articulo_ArticuloId",
                table: "preciopromocional",
                column: "ArticuloId",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_articulo_ProductoId",
                table: "stock",
                column: "ProductoId",
                principalTable: "articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
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
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_preciopromocional_articulo_ArticuloId",
                table: "preciopromocional");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_articulo_ProductoId",
                table: "stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venta",
                table: "venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articulo",
                table: "articulo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "TipoimpuestoId",
                table: "tipoimpuesto");

            migrationBuilder.DropColumn(
                name: "TipoDocIdentidadId",
                table: "tipodocumentoidentidad");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "articulo");

            migrationBuilder.RenameColumn(
                name: "UnidadMedidaId",
                table: "unidadmedida",
                newName: "Unidadmedidanro");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId",
                table: "tiposervicio",
                newName: "TipoServicoNro");

            migrationBuilder.RenameColumn(
                name: "PresentacionId",
                table: "presentacion",
                newName: "Idpresentacion");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "categoriaproduto",
                newName: "Categorianro");

            migrationBuilder.AddColumn<int>(
                name: "NroVenta",
                table: "venta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TipoimpuestoNro",
                table: "tipoimpuesto",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "IdTipoDocIdentidad",
                table: "tipodocumentoidentidad",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                comment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "TipoTimbrado",
                table: "timbrado",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                comment: "Puede ser Autoimprenta Manual Electronico",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<short>(
                name: "TimbradoId",
                table: "timbrado",
                type: "smallint",
                nullable: false,
                comment: "Id de la tabla",
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<short>(
                name: "EmpresaId",
                table: "empresa",
                type: "smallint",
                nullable: false,
                comment: "Id de la tabla",
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TipoimpuestoNro",
                table: "detalleventa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "IdDetalle",
                table: "detalleventa",
                type: "integer",
                nullable: false,
                comment: "Id de la tabla",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TipoimpuestoId",
                table: "articulo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "articulo",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                comment: "Estado del Producto,Servicio",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Articulonro",
                table: "articulo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Id de la tabla")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_venta",
                table: "venta",
                column: "NroVenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipoimpuesto",
                table: "tipoimpuesto",
                column: "TipoimpuestoNro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipodocumentoidentidad",
                table: "tipodocumentoidentidad",
                column: "IdTipoDocIdentidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articulo",
                table: "articulo",
                column: "Articulonro");

            migrationBuilder.AddForeignKey(
                name: "FK_articulo_tipoimpuesto_TipoimpuestoId",
                table: "articulo",
                column: "TipoimpuestoId",
                principalTable: "tipoimpuesto",
                principalColumn: "TipoimpuestoNro");

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
                name: "FK_persona_tipodocumentoidentidad_IdTipoDocIdentidad",
                table: "persona",
                column: "IdTipoDocIdentidad",
                principalTable: "tipodocumentoidentidad",
                principalColumn: "IdTipoDocIdentidad");

            migrationBuilder.AddForeignKey(
                name: "FK_preciopromocional_articulo_ArticuloId",
                table: "preciopromocional",
                column: "ArticuloId",
                principalTable: "articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_articulo_ProductoId",
                table: "stock",
                column: "ProductoId",
                principalTable: "articulo",
                principalColumn: "Articulonro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
