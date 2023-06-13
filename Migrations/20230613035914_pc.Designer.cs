﻿// <auto-generated />
using System;
using Cinemania;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinemania.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230613035914_pc")]
    partial class pc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cinemania.Funcion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("cantClientes")
                        .HasColumnType("int");

                    b.Property<double>("costo")
                        .HasColumnType("float");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPelicula")
                        .HasColumnType("int");

                    b.Property<int>("idSala")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("idPelicula");

                    b.HasIndex("idSala");

                    b.ToTable("Funciones", (string)null);
                });

            modelBuilder.Entity("Cinemania.FuncionUsuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int>("idFuncion")
                        .HasColumnType("int");

                    b.HasKey("idUsuario", "idFuncion");

                    b.HasIndex("idFuncion");

                    b.ToTable("funcionUsuarios");
                });

            modelBuilder.Entity("Cinemania.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Peliculas", (string)null);
                });

            modelBuilder.Entity("Cinemania.Sala", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("capacidad")
                        .HasColumnType("int");

                    b.Property<string>("ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Salas", (string)null);
                });

            modelBuilder.Entity("Cinemania.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<double>("Credito")
                        .HasColumnType("float");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int>("IntentosFallidos")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Cinemania.Funcion", b =>
                {
                    b.HasOne("Cinemania.Pelicula", "miPelicula")
                        .WithMany("misFunciones")
                        .HasForeignKey("idPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinemania.Sala", "miSala")
                        .WithMany("misFunciones")
                        .HasForeignKey("idSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("miPelicula");

                    b.Navigation("miSala");
                });

            modelBuilder.Entity("Cinemania.FuncionUsuario", b =>
                {
                    b.HasOne("Cinemania.Funcion", "funcion")
                        .WithMany("funcionUsuarios")
                        .HasForeignKey("idFuncion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinemania.Usuario", "usuario")
                        .WithMany("Tickets")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("funcion");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Cinemania.Funcion", b =>
                {
                    b.Navigation("funcionUsuarios");
                });

            modelBuilder.Entity("Cinemania.Pelicula", b =>
                {
                    b.Navigation("misFunciones");
                });

            modelBuilder.Entity("Cinemania.Sala", b =>
                {
                    b.Navigation("misFunciones");
                });

            modelBuilder.Entity("Cinemania.Usuario", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
