using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Cinemania
{
    class DAL
    {
        private string connectionString;

        public DAL()
        {
            connectionString = "Data Source=DESKTOP-NH6VC1C\\SQLEXPRESS;Initial Catalog=CineDotNet;Integrated Security=True";
        }

        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            string queryString = "SELECT * from Usuario";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;

                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0),reader.GetInt32(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetInt32(6),reader.GetBoolean(7),reader.GetDouble(8),reader.GetDateTime(9),reader.GetBoolean(10));
                        misUsuarios.Add(aux);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("esto anda re mal");
                    Console.WriteLine(ex);
                }
                return misUsuarios;
            }
        }

        public List<Pelicula> inicializarPeliculas()
        {
            List<Pelicula> misPeliculas = new List<Pelicula>();

            string queryString = "SELECT * FROM Pelicula";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Pelicula aux;

                    while (reader.Read())
                    {
                        aux = new Pelicula(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                        misPeliculas.Add(aux);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return misPeliculas;
            }

        }

        public List<Sala> inicializarSalas()
        {
            List<Sala> misSalas = new List<Sala>();

            string queryString = "SELECT * FROM Sala";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Sala aux;

                    while (reader.Read())
                    {
                        aux = new Sala(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        misSalas.Add(aux);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return misSalas;
            }
        }

        public List<Funcion> inicializarFunciones()
        {
            List<Funcion> misFunciones = new List<Funcion>();
            List<Sala> misSalas = inicializarSalas();
            List<Pelicula> misPeliculas = inicializarPeliculas();

            string queryString = "SELECT * FROM Funcion";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Funcion aux;
                    Pelicula miPeli = null;
                    Sala miSala = null;
                    int idPelicula;
                    int idSala;

                    while (reader.Read())
                    {
                        idPelicula = reader.GetInt32(2);
                        idSala = reader.GetInt32(1);
                        foreach (Sala s in misSalas)
                        {
                            if (s.id == idSala)
                            {
                                miSala = s;
                                break;
                            }
                        }
                        foreach (Pelicula p in misPeliculas)
                        {
                            if (p.id == idPelicula)
                            {
                                miPeli = p;
                                break;
                            }
                        }


                        aux = new Funcion(reader.GetInt32(0), miSala, miPeli, reader.GetDateTime(3), reader.GetInt32(4), reader.GetDouble(5));
                        misFunciones.Add(aux);
                        miPeli.misFunciones.Add(aux);
                        miSala.misFunciones.Add(aux);


                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return misFunciones;
            }

        }

        public List<FuncionUsuario> inicializarFuncionUsuario()
        {
            List<FuncionUsuario> misFuncionesUsuario = new List<FuncionUsuario>();
            List<Usuario> misUsuarios = inicializarUsuarios();
            List<Funcion> misFunciones = inicializarFunciones();

            string queryString = "SELECT * FROM funcionUsuario";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    FuncionUsuario aux;
                    Funcion miFuncion = null;
                    Usuario miUsuario = null;
                    int idFuncion;
                    int idUsuario;

                    while (reader.Read())
                    {
                        idUsuario = reader.GetInt32(0);
                        idFuncion = reader.GetInt32(1);
                        
                        foreach (Usuario user in misUsuarios)
                        {
                            if (user.id == idUsuario)
                            {
                                miUsuario = user;
                                break;
                            }
                        }
                        foreach (Funcion f in misFunciones)
                        {
                            if (f.ID == idFuncion)
                            {
                                miFuncion = f;
                                break;
                            }
                        }


                        aux = new FuncionUsuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                        misFuncionesUsuario.Add(aux);
                        miUsuario.MisFunciones.Add(miFuncion);
                        miFuncion.clientes.Add(miUsuario);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return misFuncionesUsuario;
            }
        }
    }
}
