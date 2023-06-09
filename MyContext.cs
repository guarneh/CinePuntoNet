﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cinemania
{
    class MyContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }    

        public DbSet<Pelicula> peliculas { get; set; }

        public DbSet<Sala> sala { get; set; }

        public DbSet<Funcion> funciones { get; set; } 

        public DbSet<FuncionUsuario> funcionUsuarios { get; set; }

        public MyContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SISTEMAS01\\SQLEXPRESS;Initial Catalog=CineDotNetV2;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //agrego tablas

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.id);

            modelBuilder.Entity<Pelicula>()
                .ToTable("Peliculas")
                .HasKey(p => p.id);

            modelBuilder.Entity<Sala>()
                .ToTable("Salas")
                .HasKey(s => s.id);

            modelBuilder.Entity<Funcion>()
                .ToTable("Funciones")
                .HasKey(f => f.ID);

            //agrego relaciones

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.miPelicula)
                .WithMany(p => p.misFunciones)
                .HasForeignKey(f => f.idPelicula)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.miSala)
                .WithMany(s => s.misFunciones)
                .HasForeignKey(f => f.idSala)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.MisFunciones)
                .WithMany(f => f.clientes)
                .UsingEntity<FuncionUsuario>(
                uf => uf.HasOne(uf => uf.funcion).WithMany(f => f.funcionUsuarios).HasForeignKey(f => f.idFuncion),
                uf => uf.HasOne(uf => uf.usuario).WithMany(u => u.Tickets).HasForeignKey(u => u.idUsuario),
                uf => uf.HasKey(k => new {k.idUsuario, k.idFuncion })
                );

            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr => 
                {
                    usr.Property(u => u.DNI).HasColumnType("int");
                    usr.Property(u => u.Nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.Apellido).HasColumnType("varchar(50)");
                    usr.Property(u => u.Mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.Password).HasColumnType("varchar(50)");
                    usr.Property(u => u.FechaNacimiento).HasColumnType("date");
                    usr.Property(u => u.Credito).HasColumnType("float");
                    usr.Property(u => u.IntentosFallidos).HasColumnType("int");
                    usr.Property(u => u.Bloqueado).HasColumnType("bit");
                    usr.Property(u => u.EsAdmin).HasColumnType("bit");
                });  

            //Ignoro todo esto

            modelBuilder.Ignore<Cine>();


        }
    }
}
