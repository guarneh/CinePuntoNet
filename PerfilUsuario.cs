using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemania
{

    public partial class PerfilUsuario : Form
    {
        public Cine cinema;
        public usuarioToMain transfMain;
        private int selectedUser;
        private int selectedFuncion;
        public PerfilUsuario(Cine cine)
        {
            InitializeComponent();
            cinema = cine;
            label2.Text = cine.usuarioCredito().ToString();
        }



        public delegate void usuarioToMain();
        private void btnToMain_Click(object sender, EventArgs e)
        {
            this.transfMain();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();


            actualizarMisDatos();
            selectedUser = -1;
        }

        private void actualizarMisDatos()
        {
            dataGridView1.Rows.Clear();


            foreach (Usuario user in cinema.obtenerUsuarios())
            {
                dataGridView1.Rows.Add(user.ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTextBox1 = textBox1.Text;
            int dni;
            bool success = int.TryParse(textoTextBox1, out dni);
            if (success)
            {
                Console.WriteLine("La conversión fue exitosa: " + textoTextBox1);
            }
            else
            {
                Console.WriteLine("La conversión falló.");
            }


            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string mail = textBox4.Text;
            string pass = textBox5.Text;
            DateTime fechaNacimiento = dateTimePicker1.Value;

            if (selectedUser != 0)
            {
                if (cinema.modificarMisDatos(selectedUser, dni, nombre, apellido, mail, pass, fechaNacimiento))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
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


            textBox1.Text = dni;
            textBox2.Text = nombre;
            textBox5.Text = apellido;
            textBox3.Text = mail;
            textBox4.Text = password;
            selectedUser = int.Parse(ID);


            DateTime fecha;

            if (DateTime.TryParse(fechaString, out fecha)) // Convertir string en datetime
            {

                dateTimePicker1.Value = fecha;
            }
            else
            {

                Console.WriteLine("La cadena no se pudo convertir en un objeto DateTime válido.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            actualizarDatosFuncion();
            selectedFuncion = -1;
        }

        private void actualizarDatosFuncion()
        {
            dataGridView3.Rows.Clear();

            foreach (Funcion f in cinema.obtenerFunciones())
            {
                dataGridView3.Rows.Add(f.ToString());

            }
        }
    }
}
