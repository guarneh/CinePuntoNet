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

            string queryString = "SELECT * from Usuarios";

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
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetBoolean(7), reader.GetInt32(8), reader.GetBoolean(9), reader.GetDouble(9));
                        misUsuarios.Add(aux);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
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

        private List<Funcion> inicializarFunciones()
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
    }
}
