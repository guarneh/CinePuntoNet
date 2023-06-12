using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinemania
{
    public class Cine
    {

        private Usuario usuarioActual;

        private MyContext context;
        public Cine()
        {
            inicializarAtributos();
        }

        public void inicializarAtributos()
        {
            try
            {
                context = new MyContext();

                context.usuarios.Include(u => u.MisFunciones).Load();
                context.funciones.Include(f => f.clientes).Load();
                context.peliculas.Include(p => p.misFunciones).Load();
                context.salas.Include(s => s.misFunciones).Load();
                context.funcionUsuarios.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //Inicia ABM de Usuarios

        public bool agregarUsuario(int dni, string nombre, string apellido, string mail, string password, DateTime fechaNacimiento)
        {
            try
            {
                Usuario nuevo = new Usuario { DNI = dni, Nombre = nombre, Apellido = apellido, Mail = mail, Password = password, FechaNacimiento = fechaNacimiento, EsAdmin = false, IntentosFallidos = 0, Bloqueado = false, Credito = 0 };
                context.usuarios.Add(nuevo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool modificarUsuario(int id, int dni, string nombre, string apellido, string mail, string password, DateTime fechaN, bool esAdm, int intFallidos, bool bloqueado, double credito)
        {
            Usuario usr = context.usuarios.Where(u => u.id == id).FirstOrDefault();
            if (usr != null)
            {
                usr.DNI = dni;
                usr.Nombre = nombre;
                usr.Apellido = apellido;
                usr.Mail = mail;
                usr.Password = password;
                usr.FechaNacimiento = fechaN;
                usr.EsAdmin = esAdm;
                usr.IntentosFallidos = intFallidos;
                usr.Bloqueado = bloqueado;
                usr.Credito = credito;
                context.usuarios.Update(usr);
                context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public bool modificarMisDatos(int id, int dni, string nombre, string apellido, string mail, string password, DateTime fechaNacimiento)
        {


            if (usuarioActual.id == id)
            {
                usuarioActual.DNI = dni;
                usuarioActual.Password = password;
                usuarioActual.Nombre = nombre;
                usuarioActual.Apellido = apellido;
                usuarioActual.Mail = mail;
                usuarioActual.FechaNacimiento = fechaNacimiento;
                context.usuarios.Update(usuarioActual);
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool eliminarUsuario(int id)
        {
            try
            {
                Usuario usr = context.usuarios.Where(u => u.id == id).FirstOrDefault();
                if (usr != null)
                {
                    context.usuarios.Remove(usr);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Inicia ABM de Peliculas

        public bool agregarPelicula(string nombre, string sinop, string poster, int duracion)
        {
            try
            {
                Pelicula nuevo = new Pelicula { Nombre = nombre, Sinopsis = sinop, Poster = poster, Duracion = duracion };
                context.peliculas.Add(nuevo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool modificarPelicula(int id, string nombre, string sinop, string poster, int duracion)
        {
            Pelicula peli = context.peliculas.Where(p => p.id == id).FirstOrDefault();
            if (peli != null)
            {
                peli.Nombre = nombre;
                peli.Sinopsis = sinop;
                peli.Poster = poster;
                peli.Duracion = duracion;
                context.peliculas.Update(peli);
                context.SaveChanges();
                return true;
            }
            else
                return false;

        }
        public bool eliminarPelicula(int id)
        {
            try
            {
                Pelicula peli = context.peliculas.Where(p => p.id == id).FirstOrDefault();
                if (peli != null)
                {
                    context.peliculas.Remove(peli);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Inicio ABM Sala

        public bool agregarSala(string ubicacion, int capacidad)
        {
            try
            {
                Sala sala = new Sala { ubicacion = ubicacion, capacidad = capacidad };
                context.salas.Add(sala);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool modificarSala(int id, string ubicacion, int capacidad)
        {
            try
            {
                Sala miSala = context.salas.Where(s => s.id == id).FirstOrDefault();
                miSala.ubicacion = ubicacion;
                miSala.capacidad = capacidad;
                context.salas.Update(miSala);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarSala(int id)
        {
            try
            {
                Sala miSala = context.salas.Where(s => s.id == id).FirstOrDefault();
                context.salas.Remove(miSala);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool iniciarSesion(string usuario, string pass)
        {



        }

        public void cerrarSesion()
        {
            usuarioActual = null;
        }


        public Usuario usuarioLogueado()
        {

            return usuarioActual;

        }

        public double usuarioCredito()
        {

            return usuarioActual.Credito;
        }

        public List<Usuario> obtenerUsuarios()
        {
            return context.usuarios.ToList();
        }

        public List<Pelicula> obtenerPeliculas()
        {
            return context.peliculas.ToList();
        }

        public List<Sala> obtenerSalas()
        {
            return context.salas.ToList();
        }

        public List<Funcion> obtenerFunciones()
        {
            return context.funciones.ToList();
        }




        public bool agregarFuncion(int idSala, int idPelicula, DateTime fecha, double costo)
        {
            Pelicula miPeli = context.peliculas.Where(p => p.id == idPelicula).FirstOrDefault();
            Sala miSala = context.salas.Where(s => s.id == idSala).FirstOrDefault();
            if (miPeli != null && miSala != null)
            {
                Funcion funcion = new Funcion { idSala = idSala, idPelicula = idPelicula, miSala = miSala, miPelicula = miPeli,fecha=fecha,cantClientes=0,costo=costo };
                miPeli.misFunciones.Add(funcion);
                miSala.misFunciones.Add(funcion);
                context.funciones.Add(funcion);
                context.peliculas.Update(miPeli);
                context.salas.Update(miSala);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool eliminarFuncion(int id)
        {
            try
            {
                Funcion miFuncion = context.funciones.Where(f => f.ID == id).FirstOrDefault();
                if (miFuncion != null)
                {
                    miFuncion.miPelicula.misFunciones.Remove(miFuncion);
                    miFuncion.miSala.misFunciones.Remove(miFuncion);
                    context.peliculas.Update(miFuncion.miPelicula);
                    context.salas.Update(miFuncion.miSala);
                    context.funciones.Remove(miFuncion);
                    context.SaveChanges();
                    return true;

                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool comprarCredito(double credito)
        {
            double nuevoCredito;
            nuevoCredito = usuarioActual.Credito + credito;

            if (credito > 0)
            {
                usuarioActual.Credito = nuevoCredito;
                return true;
            }
            else
            {
                return false;
            }


        }


        public bool comprarEntrada(int idUsuario, int idFuncion, int cantClientes)
        {


            usuarioActual.id = idUsuario;
            Funcion miFuncion = null;
            Sala miSala = null;


            foreach (Funcion f in funciones)
            {
                if (idFuncion == f.ID)
                {
                    miFuncion = f;

                    break;
                }
            }

            foreach (Sala s in salas)
            {
                if (miFuncion.miSala.id == s.id)
                {
                    miSala = s;
                }

            }


            double totEntradas = miFuncion.costo * cantClientes;


            if (usuarioActual.Credito >= miFuncion.costo && usuarioActual.Credito >= totEntradas && miFuncion.cantClientes <= miSala.capacidad)
            {
                miFuncion.cantClientes += cantClientes;
                db.modificarFuncion(miFuncion.ID, miFuncion.idSala, miFuncion.idPelicula, miFuncion.fecha, miFuncion.cantClientes, miFuncion.costo);
                usuarioActual.Credito -= miFuncion.costo * cantClientes;
                usuarioActual.MisFunciones.Add(miFuncion);
                miSala.capacidad -= cantClientes;

                return true;
            }
            else
            {
                return false;
            }
        }


    }
    /*
        public bool modificarFuncion(int id, int idSala, int idPelicula, DateTime fecha, int cantClientes, double costo)
        {

            return true;
        }
    */
        

    
    /*
    public bool cambiarPassword(string passwordActual, string passwordNueva)
    {
       
    }
    */

}




