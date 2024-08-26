﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaFacturacion_API.Datos;

#nullable disable

namespace SistemaFacturacion_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Articulo", b =>
                {
                    b.Property<int>("Articulonro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasComment("Id de la tabla");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Articulonro"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Estado")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasComment("Estado del Producto,Servicio");

                    b.Property<DateTime?>("Fecharegistro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Fechaultactualizacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Observacion")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.Property<int>("TipoArticulo")
                        .HasColumnType("integer");

                    b.Property<int?>("TipoimpuestoId")
                        .HasColumnType("integer");

                    b.HasKey("Articulonro");

                    b.HasIndex("TipoimpuestoId");

                    b.ToTable("Articulo");

                    b.HasDiscriminator<int>("TipoArticulo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ColaboradorId"));

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("Fechaegreso")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Fechaingreso")
                        .HasColumnType("date");

                    b.Property<int>("PersonaId")
                        .HasColumnType("integer");

                    b.Property<double>("Salario")
                        .HasColumnType("double precision");

                    b.HasKey("ColaboradorId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Colaborador", (string)null);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.HistorialRefreshToken", b =>
                {
                    b.Property<int>("HistorialTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HistorialTokenId"));

                    b.Property<bool?>("EsActivo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("boolean")
                        .HasComputedColumnSql("(FechaExpiracion >= CURRENT_DATE)", true);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("HistorialTokenId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistorialRefreshToken");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Marca", b =>
                {
                    b.Property<int>("Marcanro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Marcanro"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.HasKey("Marcanro");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("Fechanacimiento")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Fecharegistro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LoginActualizacion")
                        .HasColumnType("text");

                    b.Property<string>("LoginRegistro")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nrodocumento")
                        .HasColumnType("text");

                    b.Property<string>("Observacion")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Ultfechaactualizacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("PersonaId");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Presentacion", b =>
                {
                    b.Property<short>("Idpresentacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Idpresentacion"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Idpresentacion");

                    b.ToTable("Presentacion");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer");

                    b.Property<int>("UbicacionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("UbicacionId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.TipoImpuesto", b =>
                {
                    b.Property<int>("TipoimpuestoNro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoimpuestoNro"));

                    b.Property<double>("Baseimponible")
                        .HasColumnType("double precision");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Porcentajeiva")
                        .HasColumnType("double precision");

                    b.HasKey("TipoimpuestoNro");

                    b.ToTable("TipoImpuesto");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.TipoProducto", b =>
                {
                    b.Property<short>("TipoProductonro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("TipoProductonro"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.HasKey("TipoProductonro");

                    b.ToTable("TipoProducto");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.TipoServicio", b =>
                {
                    b.Property<short>("TipoServicoNro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("TipoServicoNro"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.HasKey("TipoServicoNro");

                    b.ToTable("TipoServicio", (string)null);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Ubicacion", b =>
                {
                    b.Property<int>("UbicacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UbicacionId"));

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UbicacionId");

                    b.ToTable("Ubicacion");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.UnidadMedida", b =>
                {
                    b.Property<short>("Unidadmedidanro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Unidadmedidanro"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.HasKey("Unidadmedidanro");

                    b.ToTable("UnidadMedida");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsuarioId"));

                    b.Property<int?>("ColaboradorId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Fechaalta")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Fechabaja")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Producto", b =>
                {
                    b.HasBaseType("SistemaFacturacion_API.Modelos.Articulo");

                    b.Property<string>("Codigobarra")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<short?>("Idpresentacion")
                        .HasColumnType("smallint");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("integer");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("double precision");

                    b.Property<int>("Stockactual")
                        .HasColumnType("integer");

                    b.Property<int>("Stockminimo")
                        .HasColumnType("integer");

                    b.Property<short?>("TipoproductoId")
                        .HasColumnType("smallint");

                    b.Property<short?>("Unidadmedidanro")
                        .HasColumnType("smallint");

                    b.HasIndex("Idpresentacion");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoproductoId");

                    b.HasIndex("Unidadmedidanro");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Servicio", b =>
                {
                    b.HasBaseType("SistemaFacturacion_API.Modelos.Articulo");

                    b.Property<short?>("TipoServicioTipoServicoNro")
                        .HasColumnType("smallint");

                    b.Property<short>("TipoServicoNro")
                        .HasColumnType("smallint");

                    b.HasIndex("TipoServicioTipoServicoNro");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Articulo", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.TipoImpuesto", "TipoImpuesto")
                        .WithMany()
                        .HasForeignKey("TipoimpuestoId");

                    b.Navigation("TipoImpuesto");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Colaborador", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.HistorialRefreshToken", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Stock", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaFacturacion_API.Modelos.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Usuario", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Producto", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.Presentacion", "Presentacion")
                        .WithMany("Productos")
                        .HasForeignKey("Idpresentacion");

                    b.HasOne("SistemaFacturacion_API.Modelos.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId");

                    b.HasOne("SistemaFacturacion_API.Modelos.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("TipoproductoId");

                    b.HasOne("SistemaFacturacion_API.Modelos.UnidadMedida", "UnidadMedida")
                        .WithMany("Productos")
                        .HasForeignKey("Unidadmedidanro");

                    b.Navigation("Marca");

                    b.Navigation("Presentacion");

                    b.Navigation("TipoProducto");

                    b.Navigation("UnidadMedida");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Servicio", b =>
                {
                    b.HasOne("SistemaFacturacion_API.Modelos.TipoServicio", "TipoServicio")
                        .WithMany()
                        .HasForeignKey("TipoServicioTipoServicoNro");

                    b.Navigation("TipoServicio");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.Presentacion", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("SistemaFacturacion_API.Modelos.UnidadMedida", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
