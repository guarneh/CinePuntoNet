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
                Usuario nuevo = new Usuario { DNI = dni, Nombre = nombre, Apellido = apellido, Mail = mail, Password = password, FechaNacimiento = fechaNacimiento, EsAdmin = false, IntentosFallidos = 0, Bloqueado = false, Credito = 0};
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
                Pelicula nuevo = new Pelicula { Nombre=nombre,Sinopsis=sinop,Poster = poster, Duracion=duracion};
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
            int idNuevaSala;
            idNuevaSala = db.agregarSala(ubicacion, capacidad);

            if (idNuevaSala != -1)
            {

                salas.Add(new Sala(idNuevaSala, ubicacion, capacidad));

                return true;
                
            }
            else
            {
                return false;
            }




        }

        public bool modificarSala(int id, string ubicacion, int capacidad)
        {
            if (db.modificarSala(id, ubicacion, capacidad) == 1)
            {

                try
                {
                    foreach (Sala s in salas)
                    {
                        if (s.id == id)
                        {
                            s.id = id;
                            s.ubicacion = ubicacion;
                            s.capacidad = capacidad;
                            return true;
                        }
                    }
                    return false;

                } catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool eliminarSala(int id)
        {
            if (db.eliminarSala(id) == 1)
            {

                try
                {

                    Sala miSala = null;
                    foreach (Sala s in salas)
                    {
                        if (s.id == id)
                        {
                            miSala = s;

                            Pelicula miPeli = null;
                            Funcion miFuncion = null;
                            foreach (Funcion f in funciones)
                            {
                                if (f.miSala.id == miSala.id)
                                {
                                    miFuncion = f;
                                    miPeli = f.miPelicula;
                                }
                            }
                            if (miFuncion != null)
                            {
                                funciones.Remove(miFuncion);
                                miPeli.misFunciones.Remove(miFuncion);
                                

                            }
                            salas.Remove(s);

                                return true;
                            }
                        }
            
                }
                catch (Exception ex)
                {
                  return false;
                }
            }

            return false;
            

                    

        }

        

                public bool iniciarSesion(string usuario, string pass)
                {


                    foreach (Usuario user in usuarios)
                    {
                        if (user.Mail.Equals(usuario))
                        {
                            if (user.Password.Equals(pass))
                            {
                                if (user.Bloqueado == false)
                                {
                                    user.IntentosFallidos = 0;
                                    usuarioActual = user;
                                    return true;
                                }
                            }
                            else
                            {
                                user.IntentosFallidos++;
                                MessageBox.Show("Contraseña Incorrecta");
                                if (user.IntentosFallidos == 3)
                                {
                                    user.Bloqueado = true;
                                    MessageBox.Show("Usuario Bloqueado");
                                    return false;
                                }
                                return false;
                            }

                        }

                    }

                    return false;
                }

                public void cerrarSesion()
                {
                    usuarioActual = null;
                }


                public int usuarioLogueado()
                {

                    return usuarioActual;

                }

                public double usuarioCredito()
                {

                    return usuarioActual.Credito;
                }

                public List<Usuario> obtenerUsuarios()
                {
                    return usuarios.ToList();
                }

                public List<Pelicula> obtenerPeliculas()
                {
                    return peliculas.ToList();
                }

                public List<Sala> obtenerSalas()
                {
                    return salas.ToList();
                }

                public List<Funcion> obtenerFunciones()
                {
                    return funciones.ToList();
                }




                public bool agregarFuncion(int idSala, int idPelicula, DateTime fecha, double costo)
                {

                    int idNuevaFuncion;
                    idNuevaFuncion = db.agregarFuncion(idSala, idPelicula, fecha, 0, costo);
                    if (idNuevaFuncion != -1)
                    {

                        try
                        {
                            Sala miSala = null;

                            foreach (Sala s in salas)
                            {

                                if (idSala == s.id)
                                {
                                    miSala = s;
                                    break;
                                }


                            }

                            Pelicula miPelicula = null;

                            foreach (Pelicula p in peliculas)
                            {

                                if (idPelicula == p.id)
                                {
                                    miPelicula = p;
                                    break;
                                }


                        }
                        if (miPelicula == null || miSala == null)
                        {
                            return false;
                        }
                        else
                        {

                                Funcion miFuncion = new Funcion(idNuevaFuncion, idSala, idPelicula, fecha, 0, costo);
                                miFuncion.miPelicula = miPelicula;
                                miFuncion.miSala = miSala;
                                miPelicula.misFunciones.Add(miFuncion);
                                miSala.misFunciones.Add(miFuncion);
                                funciones.Add(miFuncion);
                                
                                return true;

                            }

                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    return false;

                }

                public bool eliminarFuncion(int id)
                {
                    if (db.eliminarFuncion(id) == 1)
                    {
                        try
                        {
                            Funcion miFuncion = null;

                            foreach (Funcion f in funciones)
                            {
                                if (f.ID == id)
                                {
                                    miFuncion = f;
                                    break;
                                }
                            }

                            Sala miSala = null;
                            foreach (Sala s in salas)
                            {
                                if (s.id == miFuncion.miSala.id)
                                {
                                    miSala = s;
                                    miSala.misFunciones.Remove(miFuncion);
                                }
                            }

                            Pelicula miPelicula = null;
                            foreach (Pelicula p in peliculas)
                            {
                                if (p.id == miFuncion.miPelicula.id)
                                {
                                    miPelicula = p;
                                    miPelicula.misFunciones.Remove(miFuncion);

                                }
                            }

                            funciones.Remove(miFuncion);

                            return true;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    return false;
                }

                public bool comprarCredito(double credito)
                {
                    double nuevoCredito;
                    nuevoCredito = usuarioActual.Credito + credito;
                    if (db.modificarUsuario(usuarioActual.id,usuarioActual.DNI,usuarioActual.Nombre,usuarioActual.Apellido,usuarioActual.Mail,usuarioActual.Password,usuarioActual.IntentosFallidos,usuarioActual.Bloqueado,nuevoCredito,usuarioActual.FechaNacimiento,usuarioActual.EsAdmin) == 1)
                    {
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
                    return false;
                }


                public bool comprarEntrada(int idUsuario, int idFuncion, int cantClientes)
                {
                        if (db.agregarFuncionUsuario(idUsuario,idFuncion,cantClientes) == 1)
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
                                db.modificarFuncion(miFuncion.ID,miFuncion.idSala,miFuncion.idPelicula,miFuncion.fecha,miFuncion.cantClientes,miFuncion.costo);
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

                        return false;



                }

                public bool modificarFuncion(int id, int idSala, int idPelicula, DateTime fecha, int cantClientes, double costo)
                {
                    if (db.modificarFuncion(id, idSala, idPelicula, fecha, cantClientes, costo) == 1)
                    {
                        try
                        {
                            foreach (Funcion f in funciones)
                            {
                                if (f.ID == id)
                                {

                                    Pelicula miPeli = f.miPelicula;
                                    miPeli.misFunciones.Remove(f);
                                    Sala miSala = f.miSala;
                                    miSala.misFunciones.Remove(f);

                                    foreach (Pelicula p in peliculas)
                                    {
                                        if (p.id == idPelicula)
                                        {
                                            miPeli = p;
                                            miPeli.misFunciones.Add(f);

                                            break;
                                        }
                                    }


                                    foreach (Sala s in salas)
                                    {
                                        if (s.id == idSala)
                                        {
                                            miSala = s;
                                            miSala.misFunciones.Add(f);
                                            break;
                                        }
                                    }

                                    f.miSala = miSala;
                                    f.miPelicula = miPeli;
                                    f.fecha = fecha;
                                    f.costo = costo;

                                    return true;

                                }
                            }
                            return false;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                    return false;

                }

                public bool cambiarPassword(string passwordActual, string passwordNueva)
                {
                    if (usuarioLogueado().Password.Equals(passwordActual))
                    {
                        if (db.modificarUsuario(usuarioActual.id,usuarioActual.DNI,usuarioActual.Nombre,usuarioActual.Apellido,usuarioActual.Mail,passwordNueva,usuarioActual.IntentosFallidos,usuarioActual.Bloqueado,usuarioActual.Credito,usuarioActual.FechaNacimiento,usuarioActual.EsAdmin) == 1)
                        {
                        usuarioLogueado().Password = passwordNueva;
                                return true;
                    
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                        return false;
                }

    }
}


