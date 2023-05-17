using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinemania
{
    public class Cine
    {
        private List<Usuario> usuarios;
        private List<Funcion> funciones;
        private List<Sala> salas;
        private List<Pelicula> peliculas;
        private Usuario usuarioActual;
        private int cantUsuarios;
        private int cantPeliculas;
        private int cantSalas;
        private int cantFunciones;
        private DAL db;
        public Cine()
        {
            DAL db = new DAL();
            this.usuarios = db.inicializarUsuarios();
            this.peliculas = db.inicializarPeliculas();
            this.salas = db.inicializarSalas();
            this.funciones = db.inicializarFunciones();
            cantUsuarios = 1;
            cantPeliculas = 1;
            cantSalas = 1;
            cantFunciones = 1;

            

        }


        //Inicia ABM de Usuarios
        public bool esAdmin()
        {
            if (usuarioActual.EsAdmin)
            {
                return true;
            }
            else
                return false;
        }
        public bool agregarUsuario(int dni, string nombre, string apellido, string mail, string password, DateTime fechaNacimiento, bool esAdmin, int intentos, bool bloqueo, double credit)
        {
            usuarios.Add(new Usuario(cantUsuarios, dni, nombre, apellido, mail, password, fechaNacimiento,  esAdmin, intentos, bloqueo, credit));

            cantUsuarios++;

            return true;
        }


        public bool modificarUsuario(int id, int dni, string nombre, string apellido, string mail, string password, DateTime fechaN, bool esAdm, int intFallidos, bool bloqueado, double credito)

        {

            foreach (Usuario user in usuarios)
            {
                if (user.id == id)
                {
                    user.DNI = dni;

                    user.Password = password;
                    user.Nombre = nombre;
                    user.Apellido = apellido;
                    user.Mail = mail;
                    user.IntentosFallidos = intFallidos;
                    user.Bloqueado = bloqueado;
                    user.Credito = credito;
                    user.EsAdmin = esAdm;
                    user.FechaNacimiento = fechaN;


                    return true;
                }
            }
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
                return true;
            }

            return false;
        }

        public bool eliminarUsuario(int id)
        {
            foreach (Usuario user in usuarios)
            {
                if (usuarioActual.id != id)
                {
                    if (user.id == id)
                    {
                        usuarios.Remove(user);
                        return true;
                    }
                }

            }
            return false;
        }

        // Inicia ABM de Peliculas

        public bool agregarPelicula(string nombre, string sinop, string poster, int duracion)
        {
            
            peliculas.Add(new Pelicula(cantPeliculas, nombre, sinop, poster, duracion));
            cantPeliculas++;
            return true;

        }

        public bool modificarPelicula(int id, string nombre, string sinop, string poster, int duracion)
        {
            foreach (Pelicula peli in peliculas)
            {
                if (peli.id == id)
                {
                    peli.nombre = nombre;
                    peli.sinopsis = sinop;
                    peli.poster = poster;
                    peli.duracion = duracion;
                    return true;
                }
            }
            return false;
        }
        public bool eliminarPelicula(int id)
        {
            Pelicula miPeli = null;
            foreach (Pelicula p in peliculas)
            {
                if (p.id == id)
                {
                    miPeli = p;

                    Funcion miFuncion = null;
                    foreach (Funcion f in funciones)
                    {
                        if (f.miPelicula.id == miPeli.id)
                        {
                            miFuncion = f;
                        }
                    }
                    eliminarFuncion(miFuncion.ID);
                    peliculas.Remove(p);

                    return true;
                }
            }

            return false;
        }


        //Inicio ABM Sala

        public bool agregarSala(string ubicacion, int capcidad)
        {
            
            salas.Add(new Sala(cantSalas, ubicacion, capcidad));
            cantSalas++;

            return true;


        }

        public bool modificarSala(int id, string ubicacion, int capacidad)
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
        }

        public bool eliminarSala(int id)
        {
            Sala miSala = null;
            foreach (Sala s in salas)
            {
                if (s.id == id)
                {
                    miSala = s;

                    Funcion miFuncion = null;
                    foreach (Funcion f in funciones)
                    {
                        if (f.miSala.id == miSala.id)
                        {
                            miFuncion = f;
                        }
                    }
                    eliminarFuncion(miFuncion.ID);
                    salas.Remove(s);

                    return true;
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
                
                Funcion miFuncion = new Funcion(cantFunciones, miSala, miPelicula, fecha, 0, costo);
                miPelicula.misFunciones.Add(miFuncion);
                miSala.misFunciones.Add(miFuncion);
                funciones.Add(miFuncion);
                cantFunciones++;
                return true;

            }



        }

        public bool eliminarFuncion(int id)
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

        public bool comprarCredito(double credito)
        {
            if (credito > 0)
            {
                usuarioActual.Credito += credito;
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

                usuarioActual.Credito -= miFuncion.costo * cantClientes;
                usuarioActual.MisFunciones.Add(miFuncion);
                miFuncion.cantClientes += cantClientes;
                miSala.capacidad -= cantClientes;

                return true;
            }
            else
            {
                return false;
            }


        }

        public bool modificarFuncion(int id, int idSala, int idPelicula, DateTime fecha, double costo)
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

        public bool cambiarPassword(string passwordActual, string passwordNueva)
        {
            if (usuarioLogueado().Password.Equals(passwordActual))
            {
                usuarioLogueado().Password = passwordNueva;
                return true;
            }
            else
            {
            return false;    
            }
        }
            
    }
}
