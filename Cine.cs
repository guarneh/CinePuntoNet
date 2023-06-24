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

        /*
          eliminarFuncion Si la función todavía no ocurrió, podes eliminarla pero tenes que devolverle la plata a todos los usuarios
          El context no crea datos por defecto, es un nice to have
            El context no crea datos por defecto, es un nice to have
            FALTA BUSCAR FUNCIÓN!
        */

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
                var funcFinded = context.funcionUsuarios.Where(f => f.usuario == usr);
                if (usr != null)
                {
                    if (funcFinded != null)
                    {
                        foreach (var f in funcFinded)
                        {
                            usr.Credito += f.funcion.costo * f.cantEntradas;
                        }   
                    }
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
                var funcEliminadas = context.funciones.Where(f => f.idPelicula == peli.id && f.fecha >= DateTime.Now);
                if (peli != null && funcEliminadas == null)
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
                var funcEliminada = context.funciones.Where(f => f.miSala == miSala && f.fecha >= DateTime.Now);
                if (miSala != null && funcEliminada == null)
                {
                    context.salas.Remove(miSala);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool iniciarSesion(string usuario, string pass)
        {
            Usuario usr = context.usuarios.Where(u => u.Mail.Equals(usuario)).FirstOrDefault();
            if (usr != null && usr.Bloqueado == false)
            {
                if (usr.Password.Equals(pass))
                {
                    usr.IntentosFallidos = 0;
                    context.usuarios.Update(usr);
                    context.SaveChanges();
                    usuarioActual = usr;
                    return true;
                }
                else
                {
                    usr.IntentosFallidos++;
                    if (usr.IntentosFallidos >= 3)
                    {
                        usr.Bloqueado = true;
                        MessageBox.Show("Usuario Bloqueado");
                        context.usuarios.Update(usr);
                        context.SaveChanges();
                        return false;
                    }
                    else
                    {
                        context.usuarios.Update(usr);
                        context.SaveChanges();
                        return false;
                    }


                }
            }
            else
            {
                MessageBox.Show("no se encontro usuario");
                return false;
            }



        }

        public void cerrarSesion()
        {
            usuarioActual = null;
        }


        public int usuarioLogueado()
        {

            return usuarioActual.id ;

        }

        public bool UsuarioAdministrador()
        {
            if (usuarioActual.EsAdmin)
            {
                return true;
            }
            else
                return false;
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

        public Funcion BuscarFuncion(int id)
        { 
            Funcion func = context.funciones.Where(f => f.ID == id).FirstOrDefault();
                       
                return func;
        }
        public FuncionUsuario BuscarFuncionUsuario(int idUsuario, int idFuncion)
        { 
            FuncionUsuario fuFinded = context.funcionUsuarios.Where(fu => fu.idUsuario == idUsuario && fu.idFuncion == idFuncion).FirstOrDefault();
            return fuFinded;
        }

        public int devolverDni()
        {

            return usuarioActual.DNI;
        }

        public string devolverNombre()
        {
            return usuarioActual.Nombre;
        }

        public string devolverCredito()
        {

            return usuarioActual.Credito.ToString();
        }

        public string devolverMail(int idUsuario)
        {
            return usuarioActual.Mail;
        }

        public List<Funcion> devolerMisFuncionesFuturas(int idUsuario)
        {
            

            return usuarioActual.MisFunciones.Where(f => f.fecha > DateTime.Now).ToList();

        }



        public bool agregarFuncion(int idSala, int idPelicula, DateTime fecha, double costo)
        {
            Pelicula miPeli = context.peliculas.Where(p => p.id == idPelicula).FirstOrDefault();
            Sala miSala = context.salas.Where(s => s.id == idSala).FirstOrDefault();
            if (miPeli != null && miSala != null)
            {
                Funcion funcion = new Funcion { idSala = idSala, idPelicula = idPelicula, miSala = miSala, miPelicula = miPeli, fecha = fecha, cantClientes = 0, costo = costo };
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
                Funcion miFuncion = context.funciones.Where(f => f.ID == id && f.fecha < DateTime.Now).FirstOrDefault();
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
                context.usuarios.Update(usuarioActual);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }


         public bool comprarEntrada(int idUsuario, int idFuncion, int cantClientes)
         {
            
            
            Funcion func = context.funciones.Where(f => f.ID == idFuncion).FirstOrDefault();
            
            if (usuarioActual != null && func != null)
            {
                
                if (func.cantClientes + cantClientes <= func.miSala.capacidad)
                {
                    if (usuarioActual.Credito >= func.costo * cantClientes)
                    {
                        
                        usuarioActual.MisFunciones.Add(func);
                        context.usuarios.Update(usuarioActual);
                        usuarioActual.Credito = usuarioActual.Credito - func.costo * cantClientes;
                        func.clientes.Add(usuarioActual);
                        context.funciones.Update(func);
                        context.SaveChanges();
                        if (usuarioActual.Tickets.Last<FuncionUsuario>().cantEntradas > 0)
                        {
                            usuarioActual.Tickets.Last<FuncionUsuario>().cantEntradas = usuarioActual.Tickets.Last<FuncionUsuario>().cantEntradas + cantClientes;
                            context.usuarios.Update(usuarioActual);
                            context.SaveChanges() ;
                        }
                        else
                        {
                            usuarioActual.Tickets.Last<FuncionUsuario>().cantEntradas = cantClientes;
                            context.usuarios.Update(usuarioActual);
                            context.SaveChanges () ;
                        }
                        return true;

                    }
                    else
                        return false;
                }
                else 
                    return false;
            }
            else
                return false;

         }

        public bool devolverEntrada(int idFuncion, int cantEntradas)
        {
            
            FuncionUsuario fuSelected = context.funcionUsuarios.Where(fu => fu.usuario == usuarioActual && fu.idFuncion == idFuncion).FirstOrDefault();
            if (fuSelected != null)
            {
                if (fuSelected.cantEntradas >= cantEntradas)
                {
                    usuarioActual.Credito += fuSelected.funcion.costo * cantEntradas;
                    fuSelected.cantEntradas -= cantEntradas;
                    if (fuSelected.cantEntradas == 0)
                    {
                        usuarioActual.Tickets.Remove(fuSelected);
                        fuSelected.funcion.funcionUsuarios.Remove(fuSelected);
                        fuSelected.funcion.clientes.Remove(usuarioActual);
                        context.funcionUsuarios.Remove(fuSelected);  
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {  
                    context.usuarios.Update(usuarioActual);
                    context.funcionUsuarios.Update(fuSelected);
                    context.SaveChanges();
                    return true;
                    }
                }
                else
                    return false;  
            }
            else
                return false;
        }
        

        public void cerrar()
        {
            context.Dispose();
        }


        





        public bool cambiarPassword(string passwordActual, string passwordNueva)
        {

            if (usuarioActual.Password.Equals(passwordActual))
            {
                usuarioActual.Password = passwordNueva;
                context.usuarios.Update(usuarioActual);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool modificarFuncion(int idFuncion,int idSala,int idPelicula,DateTime fechaNueva,double costo)
        {
            Funcion func = context.funciones.Where(f => f.ID == idFuncion).FirstOrDefault();
            Pelicula nuevaPeli = context.peliculas.Where(p => p.id == idPelicula).FirstOrDefault();
            Sala salaNueva = context.salas.Where(s => s.id == idSala).FirstOrDefault();
            if (func != null)
            {
                if (func.idSala != idSala)
                {
                    func.idSala = idSala;
                    context.funciones.Update(func);
                }
                if (func.idPelicula != idPelicula)
                {
                    func.idPelicula = idPelicula;
                    context.funciones.Update(func);
                }
                func.fecha = fechaNueva;
                func.costo = costo;
                context.funciones.Update(func);
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
    

}




