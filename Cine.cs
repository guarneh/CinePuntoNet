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
        private List<Usuario> usuarios;
        private List<Funcion> funciones;
        private List<Sala> salas;
        private List<Pelicula> peliculas;
        private List<FuncionUsuario> funcionUsuarios;
        private Usuario usuarioActual;

        private int cantPeliculas;
        private int cantSalas;
        private int cantFunciones;
        private DAL db;
        public Cine()
        {
            db = new DAL();
            peliculas = new List<Pelicula>();
            funciones = new List<Funcion>();
            salas = new List<Sala>();
            usuarios = new List<Usuario>();
            funcionUsuarios = new List<FuncionUsuario>();
            inicializarAtributos();
           



        }

        public void inicializarAtributos()
        {
            peliculas = db.inicializarPeliculas();
            salas = db.inicializarSalas();
            usuarios = db.inicializarUsuarios();
            funciones = db.inicializarFunciones();
            funcionUsuarios = db.inicializarFuncionUsuario();

            //relacion 

            foreach (Funcion f in funciones)
            {
                foreach (Pelicula p in peliculas)
                {
                    Pelicula miPeli = null;
                    if (f.idPelicula == p.id)
                    {
                        miPeli = p;
                        p.misFunciones.Add(f);
                        f.miPelicula = miPeli;
                    }
                }
                foreach (Sala s in salas)
                {
                    Sala miSala = null;
                    if (f.idSala == s.id)
                    {
                        miSala = s;
                        s.misFunciones.Add(f);
                        f.miSala = miSala;
                    }
                }
            }


            foreach (FuncionUsuario fu in funcionUsuarios)
            {
                foreach (Funcion f in funciones)
                {
                    foreach (Usuario u in usuarios)
                    {
                        if (fu.idUsuario == u.id && fu.idFuncion == f.ID)
                        {
                            u.MisFunciones.Add(f);
                            f.clientes.Add(u);
                        }
                    }
                }
            }
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
            bool esValido = true;
            foreach (Usuario u in usuarios)
            {
                if (u.DNI == dni)
                    esValido = false;
            }
            if (esValido)
            {
                int idNuevoUsuario;
                idNuevoUsuario = db.agregarUsuario(dni, nombre, apellido, mail, password, intentos, bloqueo, credit, fechaNacimiento, esAdmin);

                if (idNuevoUsuario != -1)
                {
                    //Ahora sí lo agrego en la lista
                    Usuario nuevo = new Usuario(idNuevoUsuario, dni, nombre, apellido, mail, password, intentos, bloqueo, credit, fechaNacimiento, esAdmin);
                    usuarios.Add(nuevo);
                    return true;
                }
                else
                {
                    //algo salió mal con la query porque no generó un id válido
                    return false;
                }
            }
            else
                return false;
        }


        public bool modificarUsuario(int id, int dni, string nombre, string apellido, string mail, string password, DateTime fechaN, bool esAdm, int intFallidos, bool bloqueado, double credito)
        {

            if (db.modificarUsuario(id, dni, nombre, apellido, mail, password, intFallidos, bloqueado, credito, fechaN, esAdm) == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    foreach (Usuario u in usuarios)
                    {
                        if (u.id == id)
                        {
                            u.DNI = dni;
                            u.Nombre = nombre;
                            u.Apellido = apellido;
                            u.Mail = mail;
                            u.Password = password;
                            u.FechaNacimiento = fechaN;
                            u.EsAdmin = esAdm;
                            u.IntentosFallidos = intFallidos;
                            u.Bloqueado = bloqueado;
                            u.Credito = credito;
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
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
            if (db.eliminarUsuario(id) == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    foreach (Usuario u in usuarios)
                        if (u.id == id)
                        {
                            usuarios.Remove(u);
                            return true;
                        }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        // Inicia ABM de Peliculas

        public bool agregarPelicula(string nombre, string sinop, string poster, int duracion)
        {
            int idNuevaPelicula;
            idNuevaPelicula = db.agregarPelicula(nombre, sinop, poster, duracion);

            if (idNuevaPelicula != -1)
            {
                peliculas.Add(new Pelicula(idNuevaPelicula, nombre, sinop, poster, duracion));
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool modificarPelicula(int id, string nombre, string sinop, string poster, int duracion)
        {
            if (db.modificarPelicula(id, nombre, sinop, poster, duracion) == 1)
            {
                try
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
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
            return false;

        }
        public bool eliminarPelicula(int id)
        {

            if (db.eliminarPelicula(id) == 1)
            {
                try
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
                            if (miFuncion != null)
                            {
                                eliminarFuncion(miFuncion.ID);
                            }
                            peliculas.Remove(p);

                            return true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return false;
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
            else
            {
                return false;
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
                            cantFunciones++;
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

