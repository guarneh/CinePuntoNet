using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Cinemania
{
    class DAL
    {
        private string connectionString;

        public DAL()
        {
            //conexion Trabajo
            connectionString = "Data Source=SISTEMAS01\\SQLEXPRESS;Initial Catalog=CineDotNet;Integrated Security=True";

            //conexion laptop
            //connectionString = "Data Source=LAPTOP-UR2EP742\\SQLEXPRESS;Initial Catalog=CineDotNet;Integrated Security=True";

            //conexion pc Casa
            //connectionString = "Data Source=DESKTOP-NH6VC1C\\SQLEXPRESS;Initial Catalog=CineDotNet;Integrated Security=True";
        }

        //***************************************************************************
        // ABM Usuario
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

        public int agregarUsuario(int dni, string nombre, string apellido, string mail,string password,int intentosFallidos, bool bloqueado, double credito, DateTime fechaNacimiento, bool esAdmin)
        {
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuario]([dni],[nombre],[apellido],[mail],[password],[intentosFallidos],[bloqueado],[credito],[fechaNacimiento],[esAdmin]) VALUES (@dni,@nombre,@apellido,@mail,@password,@intentosFallidos,@bloqueado,@credito,@fechaNacimiento,@esAdmin)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@esAdmin", SqlDbType.Bit));
                command.Parameters["@dni"].Value = dni;
                command.Parameters["@nombre"].Value = nombre;
                command.Parameters["@apellido"].Value = apellido;
                command.Parameters["@mail"].Value = mail;
                command.Parameters["@password"].Value = password;
                command.Parameters["@intentosFallidos"].Value = esAdmin;
                command.Parameters["@bloqueado"].Value = bloqueado;
                command.Parameters["@credito"].Value = credito;
                command.Parameters["@fechaNacimiento"].Value = fechaNacimiento;
                command.Parameters["@esAdmin"].Value = esAdmin;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuario]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no anda nada");
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoUsuario;
            }
        }

        public int eliminarUsuario(int id)
        {
            string queryString = "DELETE FROM [dbo].[Usuario] WHERE id=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        public int modificarUsuario(int id,int dni, string nombre,string apellido,string mail,string password,int intentosFallidos,bool bloqueado,double credito,DateTime fechaNacimiento,bool esAdmin)
        {
            string queryString = "UPDATE [dbo].[Usuario] SET [dni] =@dni,[nombre] = @nombre,[apellido] = @apellido,[mail] = @mail,[password] = @password ,[intentosFallidos] = @intentosFallidos,[bloqueado] = @bloqueado,[credito] = @credito ,[fechaNacimiento] = @fechaNacimiento,[esAdmin] =@esAdmin WHERE id = @id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@esAdmin", SqlDbType.Bit));
                command.Parameters["@id"].Value = id;
                command.Parameters["@dni"].Value = dni;
                command.Parameters["@nombre"].Value = nombre;
                command.Parameters["@apellido"].Value = apellido;
                command.Parameters["@mail"].Value = mail;
                command.Parameters["@password"].Value = password;
                command.Parameters["@intentosFallidos"].Value = intentosFallidos;
                command.Parameters["@bloqueado"].Value = bloqueado;
                command.Parameters["@credito"].Value = credito;
                command.Parameters["@fechaNacimiento"].Value = fechaNacimiento;
                command.Parameters["@esAdmin"].Value = esAdmin;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //*****************************************************************************************
        // ABM Peliculas

        

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

        public int agregarPelicula(string nombre, string sinopsis, string poster, int duracion)
        {
            int resultadoQuery;
            int idNuevaPelicula;

            string queryString = "INSERT INTO [dbo].[Pelicula] ([nombre] ,[sinopsis] ,[poster] ,[duracion]) VALUES (@nombre,@sinopsis ,@poster,@duracion)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@sinopsis", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@poster", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@duracion", SqlDbType.Int));
                command.Parameters["@nombre"].Value = nombre;
                command.Parameters["@sinopsis"].Value = sinopsis;
                command.Parameters["@poster"].Value = poster;
                command.Parameters["@duracion"].Value = duracion;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Pelicula]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaPelicula = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no anda nada");
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaPelicula;
            }

        }

        public int modificarPelicula(int id,string nombre,string sinopsis, string poster,int duracion)
        {
            string queryString = "UPDATE [dbo].[Pelicula] SET [nombre] = @nombre ,[sinopsis] = @sinopsis ,[poster] = @poster ,[duracion] = @duracion WHERE id = @id ";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@sinopsis", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@poster", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@duracion", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                command.Parameters["@nombre"].Value = nombre;
                command.Parameters["@sinopsis"].Value = sinopsis;
                command.Parameters["@poster"].Value = poster;
                command.Parameters["@duracion"].Value = duracion;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        public int eliminarPelicula(int id)
        {
            string queryString = "DELETE FROM [dbo].[Pelicula] WHERE id=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //************************************************************
        // ABM Salas


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

        public int agregarSala(string ubicacion, int capacidad)
        {
            int resultadoQuery;
            int idNuevaSala;

            string queryString = "INSERT INTO [dbo].[Sala] ([ubicacion] ,[capacidad]) VALUES (@ubicacion,@capacidad)";

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                command.Parameters["@ubicacion"].Value = ubicacion;
                command.Parameters["@capacidad"].Value = capacidad;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Sala]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaSala = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no anda nada");
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaSala;
            }
        }

        public int eliminarSala(int id)
        {
            string queryString = "DELETE FROM [dbo].[Sala] WHERE id=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int modificarSala(int id, string ubicacion, int capacidad)
        {
            string queryString = "UPDATE [dbo].[Sala] SET [ubicacion] = @ubicacion ,[capacidad] = @capacidad  WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                command.Parameters["@capacidad"].Value = capacidad;
                command.Parameters["@ubicacion"].Value = ubicacion;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }


            }
        }

        //*************************************************
        // ABM Funciones
        public List<Funcion> inicializarFunciones()
        {
            List<Funcion> misFunciones = new List<Funcion>();
           

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
                   

                    while (reader.Read())
                    {
                        


                        aux = new Funcion(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetInt32(4), reader.GetDouble(5));
                        misFunciones.Add(aux);
                       


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

        public int agregarFuncion(int idSala, int idPelicula, DateTime fecha, int cantClientes, double costo) 
        {
            int resultadoQuery;
            int idNuevaFuncion;

            string queryString = "INSERT INTO [dbo].[Funcion] ([idSala],[idPelicula],[fecha],[cantClientes],[costo]) VALUES  (@idSala ,@idPelicula,@fecha,@cantClientes,@costo)";

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idSala", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idPelicula", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@cantClientes", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                command.Parameters["@idSala"].Value = idSala;
                command.Parameters["@idPelicula"].Value = idPelicula;
                command.Parameters["@fecha"].Value = fecha;
                command.Parameters["@cantClientes"].Value = cantClientes;
                command.Parameters["@costo"].Value = costo;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Sala]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaFuncion = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no anda nada");
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaFuncion;
            }
        }

        public int modificarFuncion(int id, int idSala, int idPelicula, DateTime fecha, int cantClientes, double costo)
        {
            string queryString = "UPDATE [dbo].[Funcion] SET [idSala] = @idSala ,[idPelicula] = @idPelicula ,[fecha] = @fecha ,[cantClientes] = @cantClientes ,[costo] = @costo WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idSala", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idPelicula", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@cantClientes", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                command.Parameters["@idSala"].Value = idSala;
                command.Parameters["@idPelicula"].Value = idPelicula;
                command.Parameters["@fecha"].Value = fecha;
                command.Parameters["@cantClientes"].Value = cantClientes;
                command.Parameters["@costo"].Value = costo;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }


            }
        }

        public int eliminarFuncion(int id)
        {
            string queryString = "DELETE FROM [dbo].[Funcion] WHERE id=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
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
