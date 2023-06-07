using System;
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
    }
}
