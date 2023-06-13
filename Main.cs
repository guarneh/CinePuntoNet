using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cinemania.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;

namespace Cinemania
{
    public partial class Main : Form
    {
        public Cine cinema;
        public mainToPerfil TransfEvento;
        public mainToLogin TransfLogin;
        public mainToUsuario TransfUsuario;
        private int selectedUser;
        private int selectedFuncion;
        private int cantClientes;

        public Main(Cine cine)
        {
            InitializeComponent();
            cinema = cine;
            label2.Text = cine.usuarioLogueado().Nombre;
            label4.Text = cine.usuarioCredito().ToString();
            selectedUser = cinema.usuarioLogueado().id;
            if (cine.UsuarioAdministrador())
            {
                button3.Visible = true;
                btnMainToUsuario.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                button3.Visible = false;
                btnMainToUsuario.Visible = true;
            }

            foreach (Pelicula p in cinema.obtenerPeliculas())
            {
                comboBox1.Items.Add(p.Nombre);
            }

        }

        public delegate void mainToLogin();
        public delegate void mainToPerfil();
        public delegate void mainToUsuario();


        private void button2_Click(object sender, EventArgs e)
        {
            cinema.cerrarSesion();
            this.TransfLogin();
        }



        private void button3_Click(object sender, EventArgs e)
        {

            this.TransfEvento();
        }

        private void btnMainToUsuario_Click(object sender, EventArgs e)
        {
            this.TransfUsuario();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string strNumero = textBox1.Text;
            double credito;
            if (Double.TryParse(strNumero, out credito))
            {
                // La conversión fue exitosa, el valor de "numero" contiene el resultado de la conversión.
            }
            else
            {
                // La conversión no fue exitosa, debes manejar esta situación en tu código.
            }

            if (cinema.comprarCredito(credito))
            {
                MessageBox.Show("compra exitosa");


            }
            else
            {
                MessageBox.Show("debe ingresar un numero");
            }

            textBox1.Clear();
            string credit = cinema.usuarioCredito().ToString();
            label4.Text = credit;



        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView2[0, e.RowIndex].Value.ToString();
            string sala = dataGridView2[1, e.RowIndex].Value.ToString();
            string pelicula = dataGridView2[2, e.RowIndex].Value.ToString();
            string fechaString = dataGridView2[3, e.RowIndex].Value.ToString();







            textBox2.Text = sala;
            textBox3.Text = pelicula;
            label12.Text = ID;
            selectedFuncion = int.Parse(ID);

            actualizarDatosMisFunciones();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizarDatosMisFunciones();
            selectedUser = -1;
        }
        private void actualizarDatosMisFunciones()
        {
            dataGridView2.Rows.Clear();

            foreach (Funcion f in cinema.obtenerFunciones())
            {
                dataGridView2.Rows.Add(f.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedUser = cinema.usuarioLogueado().id;
            string cantEntradas = textBox5.Text;
            int entradas = int.Parse(cantEntradas);

            if (selectedFuncion != 0)
            {
                if (cinema.comprarEntrada(selectedUser, selectedFuncion, entradas))
                {
                    MessageBox.Show("compra exitosa");
                    label4.Text = cinema.usuarioCredito().ToString();
                }

                else
                    MessageBox.Show("Problemas para comprar");
            }
            else
                MessageBox.Show("Debe seleccionar una Funcion");

            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            label9.ResetText();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (Funcion f in cinema.obtenerFunciones())
            {
                if (f.miPelicula.Nombre.Equals(comboBox1.Text))
                {
                    dataGridView2.Rows.Add(f.ToString());
                }
            }
        }
    }
}
