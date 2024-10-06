﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParcialWebApi.Models;

#nullable disable

namespace ParcialWebApi.Migrations
{
    [DbContext(typeof(CriptoContext))]
    [Migration("20241006035248_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParcialWebApi.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PK_Table_1");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ParcialWebApi.Models.Criptomoneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int")
                        .HasColumnName("categoria");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("simbolo");

                    b.Property<DateTime>("UltimaActualizacion")
                        .HasColumnType("datetime")
                        .HasColumnName("ultima_actualizacion");

                    b.Property<double>("ValorActual")
                        .HasColumnType("float")
                        .HasColumnName("valor_actual");

                    b.HasKey("Id");

                    b.HasIndex("Categoria");

                    b.ToTable("Criptomonedas");
                });

            modelBuilder.Entity("ParcialWebApi.Models.Criptomoneda", b =>
                {
                    b.HasOne("ParcialWebApi.Models.Categoria", "CategoriaNavigation")
                        .WithMany("Criptomoneda")
                        .HasForeignKey("Categoria")
                        .IsRequired()
                        .HasConstraintName("FK_Criptomonedas_Categorias");

                    b.Navigation("CategoriaNavigation");
                });

            modelBuilder.Entity("ParcialWebApi.Models.Categoria", b =>
                {
                    b.Navigation("Criptomoneda");
                });
#pragma warning restore 612, 618
        }
    }
}
