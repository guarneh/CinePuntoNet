using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cinemania.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cinemania
{
    public partial class Perfil : Form
    {

        public Cine cine;
        public mainToPerfil TransfEvento;
        private int selectedUser;
        private int selectedMovie;

        private int selectedSala;
        private int selectedFuncion;

        public PerfilToMain TransfEvento2;

        public Perfil(Cine cine)
        {
            InitializeComponent();
            this.cine = cine;
        }


        public delegate void mainToPerfil();
        public delegate void PerfilToMain();



        //Perfil Usuario

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            dateTimePicker1.ResetText();
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            actualizarDatosUser();
            selectedUser = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            checkBox1.Checked = false;
            textBox7.Clear();
            checkBox2.Checked = false;
            textBox8.Clear();
        }

        private void actualizarDatosUser()
        {
            dataGridView1.Rows.Clear();


            foreach (Usuario user in cine.obtenerUsuarios())
            {
                dataGridView1.Rows.Add(user.ToString());

            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView1[0, e.RowIndex].Value.ToString();
            string dni = dataGridView1[1, e.RowIndex].Value.ToString();
            string nombre = dataGridView1[2, e.RowIndex].Value.ToString();
            string apellido = dataGridView1[3, e.RowIndex].Value.ToString();
            string mail = dataGridView1[4, e.RowIndex].Value.ToString();
            string password = dataGridView1[5, e.RowIndex].Value.ToString();
            string fechaString = dataGridView1[6, e.RowIndex].Value.ToString();
            string esAdm = dataGridView1[7, e.RowIndex].Value.ToString();
            string intFallidos = dataGridView1[8, e.RowIndex].Value.ToString();
            string block = dataGridView1[9, e.RowIndex].Value.ToString();
            string credito = dataGridView1[10, e.RowIndex].Value.ToString();

            textBox1.Text = ID;
            textBox2.Text = dni;
            textBox5.Text = mail;
            textBox3.Text = nombre;
            textBox4.Text = apellido;
            textBox6.Text = password;
            textBox8.Text = credito;
            textBox7.Text = intFallidos;
            selectedUser = int.Parse(ID);

            actualizarDatosMisFunciones();


            DateTime fecha;

            if (DateTime.TryParse(fechaString, out fecha)) // Convertir string en datetime
            {

                dateTimePicker1.Value = fecha;
            }
            else
            {

                Console.WriteLine("La cadena no se pudo convertir en un objeto DateTime válido.");
            }


            bool value = Boolean.Parse(esAdm);
            checkBox1.Checked = value;

            bool value2 = Boolean.Parse(block);
            checkBox2.Checked = value2;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int dni = Int32.Parse(textBox2.Text);
            string mail = textBox5.Text;
            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            string password = textBox6.Text;
            double credito = double.Parse(textBox8.Text);
            int intentosFallidos = Int32.Parse(textBox7.Text);
            DateTime fechaNacimiento = dateTimePicker1.Value;
            bool esAdmin = checkBox1.Checked;
            bool bloqueado = checkBox2.Checked;


            if (selectedUser != 0)
            {

                if (cine.modificarUsuario(selectedUser,dni,nombre,apellido,mail,password,fechaNacimiento,esAdmin,intentosFallidos,bloqueado,credito))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }



        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            dateTimePicker1.ResetText();
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            if (selectedUser != 0)
            {
                if (cine.eliminarUsuario(selectedUser))
                    MessageBox.Show("Eliminado con éxito");
                else
                    MessageBox.Show("Problemas al eliminar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }

        private void button2_Click(object sender, EventArgs e)
        {



            string textoTextBox2 = textBox2.Text;
            int dni;
            bool success = int.TryParse(textoTextBox2, out dni);
            if (success)
            {
                Console.WriteLine("La conversión fue exitosa: " + textoTextBox2);
            }
            else
            {
                Console.WriteLine("La conversión falló.");
            }

            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            string mail = textBox5.Text;
            string pass = textBox6.Text;
            DateTime fechaNacimiento = dateTimePicker1.Value;
            bool esAdmin = checkBox1.Checked;

            string textoTextBox = textBox7.Text;

            string textoTextBox7 = textBox7.Text;
            int intentos;
            bool success2 = int.TryParse(textoTextBox7, out intentos);
            if (success2)
            {
                Console.WriteLine("La conversión fue exitosa: " + textoTextBox7);
            }
            else
            {
                Console.WriteLine("La conversión falló.");
            }




            bool bloqueo = checkBox2.Checked;


            string textoTextBox8 = textBox8.Text;
            int credito;
            bool success3 = int.TryParse(textoTextBox8, out credito);
            if (success2)
            {
                Console.WriteLine("La conversión fue exitosa: " + textoTextBox8);
            }
            else
            {
                Console.WriteLine("La conversión falló.");
            }


            if (dni == 0 || nombre == "" || nombre == null || apellido == "" || apellido == null || mail == "" || mail == null || pass == "" || pass == null)
                MessageBox.Show("DNI,Nombre,Apellido,Mail y pass son obligatorios");

            else

                if (cine.agregarUsuario(dni,nombre,apellido,mail,pass,fechaNacimiento,esAdmin,intentos,bloqueo,credito))
                MessageBox.Show("Agregado con éxito");
            else
                MessageBox.Show("Problemas al agregar");


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de letras
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar >= 255))
            {
                MessageBox.Show("Solo Letras", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de letras
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar >= 255))
            {
                MessageBox.Show("Solo Letras", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        //Perfil Pelicula

        private void button9_Click(object sender, EventArgs e)
        {
            actualizarDatosFilms();
            selectedMovie = -1;
        }

        private void actualizarDatosFilms()
        {
            dataGridView2.Rows.Clear();

            foreach (Pelicula film in cine.obtenerPeliculas())
            {
                dataGridView2.Rows.Add(film.ToString());

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nombre = textBox12.Text;
            string sinopsis = textBox11.Text;
            string poster = textBox10.Text;
            string textoTextBox = textBox9.Text;
            int duracion = Int32.Parse(textoTextBox);

            if (nombre == "" || sinopsis == "" || poster == "" || textoTextBox == "" || nombre == null || sinopsis == null || poster == null || textoTextBox == null)

                MessageBox.Show("Debe completar los datos para agregar");

            else
            if (cine.agregarPelicula(nombre, sinopsis, poster, duracion))
                MessageBox.Show("Agregado con éxito");
            else
                MessageBox.Show("Problemas al agregar");

            textBox11.Clear();
            textBox12.Clear();
            textBox10.Clear();
            textBox9.Clear();


        }
        private void btnModPelicula_Click(object sender, EventArgs e)
        {
            if (selectedMovie != 0)
            {
                if (cine.modificarPelicula(selectedMovie, textBox12.Text, textBox11.Text, textBox10.Text, int.Parse(textBox9.Text)))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar una pelicula");
        }

        private void btnElimPelicula_Click(object sender, EventArgs e)
        {
            if (selectedMovie != 0)
            {
                if (cine.eliminarPelicula(selectedMovie))
                    MessageBox.Show("Eliminado con éxito");
                else
                    MessageBox.Show("Problemas al eliminar");
            }
            else
                MessageBox.Show("Debe seleccionar una pelicula");
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView2[0, e.RowIndex].Value.ToString();
            string nombre = dataGridView2[1, e.RowIndex].Value.ToString();
            string sinopsis = dataGridView2[2, e.RowIndex].Value.ToString();
            string poster = dataGridView2[3, e.RowIndex].Value.ToString();
            string duracion = dataGridView2[4, e.RowIndex].Value.ToString();

            textBox13.Text = ID;
            textBox12.Text = nombre;
            textBox11.Text = sinopsis;
            textBox10.Text = poster;
            textBox9.Text = duracion;

            selectedMovie = int.Parse(ID);
            actualizarFuncionPelicula();

        }

        private void actualizarFuncionPelicula()
        {
            dataGridView5.Rows.Clear();
            foreach (Pelicula p in cine.obtenerPeliculas())
            {
                if (p.id == selectedMovie)
                {
                    foreach (Funcion f in p.misFunciones)
                    {
                        dataGridView5.Rows.Add(f.ToString());
                    }
                }
            }
        }

        //perfil Sala

        private void button10_Click(object sender, EventArgs e)
        {
            string ubicacion = textBoxUbicacion.Text;
            string textoCapacidad = textBoxCapacidad.Text;
            int capacidad = Int32.Parse(textoCapacidad);

            if (ubicacion == "" || capacidad == null)
            {
                MessageBox.Show("Debe completar los datos para agregar una Sala");
            }
            else if (cine.agregarSala(ubicacion, capacidad))
            {
                MessageBox.Show("Sala agregada con exito");
            }
            else
            {
                MessageBox.Show("Problemas al agregar");
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (selectedMovie != 0)
            {
                if (cine.modificarSala(selectedSala, textBoxUbicacion.Text, int.Parse(textBoxCapacidad.Text)))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar una sala");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (selectedSala != 0)
            {
                if (cine.eliminarSala(selectedSala))
                    MessageBox.Show("Eliminado con éxito");
                else
                    MessageBox.Show("Problemas al eliminar");
            }
            else
                MessageBox.Show("Debe seleccionar una Sala");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            actualizarDatosSala();
            selectedSala = -1;
        }

        private void actualizarDatosSala()
        {
            dataGridView4.Rows.Clear();

            foreach (Sala s in cine.obtenerSalas())
            {
                dataGridView4.Rows.Add(s.ToString());

            }

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView4[0, e.RowIndex].Value.ToString();
            string ubicacion = dataGridView4[1, e.RowIndex].Value.ToString();
            string capacidad = dataGridView4[2, e.RowIndex].Value.ToString();

            textBox14.Text = ID;
            textBoxUbicacion.Text = ubicacion;
            textBoxCapacidad.Text = capacidad;

            selectedSala = int.Parse(ID);
            actualizarFuncionSala();
        }

        private void actualizarFuncionSala()
        {
            dataGridView6.Rows.Clear();
            foreach (Sala s in cine.obtenerSalas())
            {
                if (s.id == selectedSala)
                {
                    foreach (Funcion f in s.misFunciones)
                    {
                        dataGridView6.Rows.Add(f.ToString());
                    }
                }
            }
        }

        //Perfil Funcion

        private void btnAgregarFuncion_Click(object sender, EventArgs e)
        {
            string textoIdSala = textBoxIdSala.Text;
            int idSala = Int32.Parse(textoIdSala);
            string textoIdPelicula = textBoxIdPeli.Text;
            int idPelicula = Int32.Parse(textoIdPelicula);
            DateTime fecha = dateTimePickerFuncion.Value;
            string textoCosto = textBoxCosto.Text;
            Double Costo = Double.Parse(textoCosto);

            if (textoIdSala == "" || textoIdSala == null || textoIdPelicula == "" || textoIdPelicula == null || fecha == null || Costo == null)
            {
                MessageBox.Show("Debe completar los datos para agregar una Funcion");
            }
            else if (cine.agregarFuncion(idSala, idPelicula, fecha, Costo))
            {
                MessageBox.Show("Funcion agregada con exito");
            }
            else
            {
                MessageBox.Show("Problemas al agregar");
            }

        }





        private void btnActualizarFuncion_Click(object sender, EventArgs e)
        {
            actualizarDatosFuncion();
            selectedFuncion = -1;

        }

        private void actualizarDatosFuncion()
        {
            dataGridViewFunciones.Rows.Clear();

            foreach (Funcion f in cine.obtenerFunciones())
            {
                dataGridViewFunciones.Rows.Add(f.ToString());

            }
        }

        private void btnModificarFuncion_Click(object sender, EventArgs e)
        {
            if (selectedMovie != 0)
            {
                if (cine.modificarFuncion(selectedFuncion, int.Parse(textBoxIdSala.Text), int.Parse(textBoxIdPeli.Text), dateTimePickerFuncion.Value, double.Parse(textBoxCosto.Text)))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar una Funcion");
        }

        private void btnEliminarFunciones_Click(object sender, EventArgs e)
        {
            if (selectedFuncion != 0)
            {
                if (cine.eliminarFuncion(selectedFuncion))
                    MessageBox.Show("Eliminado con éxito");
                else
                    MessageBox.Show("Problemas al eliminar");
            }
            else
                MessageBox.Show("Debe seleccionar una funcion");
        }

        private void dataGridViewFunciones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewFunciones[0, e.RowIndex].Value.ToString();
            string sala = dataGridViewFunciones[1, e.RowIndex].Value.ToString();
            string pelicula = dataGridViewFunciones[2, e.RowIndex].Value.ToString();
            string fechaString = dataGridViewFunciones[3, e.RowIndex].Value.ToString();
            string costoString = dataGridViewFunciones[5, e.RowIndex].Value.ToString();


            label22.Text = id;
            textBoxIdSala.Text = sala;
            textBoxIdPeli.Text = pelicula;

            selectedFuncion = int.Parse(id);

            DateTime fecha;

            if (DateTime.TryParse(fechaString, out fecha)) // Convertir string en datetime
            {

                dateTimePickerFuncion.Value = fecha;
            }
            else
            {

                Console.WriteLine("La cadena no se pudo convertir en un objeto DateTime válido.");
            }

            textBoxCosto.Text = costoString;

        }





        //Volver al Main
        private void button5_Click(object sender, EventArgs e)
        {
            this.TransfEvento2();
        }



        private void actualizarDatosMisFunciones()
        {

            foreach (Usuario user in cine.obtenerUsuarios())
            {
                if (user.id == selectedUser)
                {
                    foreach (Funcion f in user.MisFunciones)
                    {
                        dataGridView3.Rows.Add(f.ToString());
                    }
                }
            }

        }
    }
}
