﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaFacturacionWeb.Datos;

#nullable disable

namespace SistemaFacturacionWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231103142353_PonerComoOpcionalFechaActualizacion")]
    partial class PonerComoOpcionalFechaActualizacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaFacturacionWeb.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaActualizacion2")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImagenURL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("MetrosCuadratos")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("integer");

                    b.Property<double>("Tarifa")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Villas");
                });
#pragma warning restore 612, 618
        }
    }
}
