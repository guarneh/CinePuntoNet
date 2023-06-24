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
        public usuarioToCambiarPassword transfCambiarPassword;
        private int selectedUser;
        private int selectedFuncion;
        public PerfilUsuario(Cine cine)
        {
            InitializeComponent();
            cinema = cine;
            label2.Text = cinema.devolverCredito().ToString();
            label5.Text = cinema.devolverDni().ToString();
            label7.Text = cinema.devolverMail(cinema.usuarioLogueado());
            label8.Text = cinema.devolverNombre();
        }



        public delegate void usuarioToMain();
        public delegate void usuarioToCambiarPassword();
        private void btnToMain_Click(object sender, EventArgs e)
        {
            this.transfMain();
        }






        private void button3_Click(object sender, EventArgs e)
        {
            actualizarDatosFuncion();
            selectedFuncion = -1;
        }

        private void actualizarDatosFuncion()
        {
            dataGridView3.Rows.Clear();

            foreach (Funcion f in cinema.devolerMisFuncionesFuturas(cinema.usuarioLogueado()))
            {
                //if (f.fecha.Date <= DateTime.Now)
                //{
                dataGridView3.Rows.Add(f.ToString());

                // }

            }
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idFuncion = dataGridView3[0, e.RowIndex].Value.ToString();
            string sala = dataGridView3[1, e.RowIndex].Value.ToString();
            string pelicula = dataGridView3[2, e.RowIndex].Value.ToString();
            string fechaString = dataGridView3[3, e.RowIndex].Value.ToString();
            string cantClientesString = dataGridView3[4, e.RowIndex].Value.ToString();
            string costoString = dataGridView3[5, e.RowIndex].Value.ToString();

            label12.Text = pelicula;
            label13.Text = sala;
            label14.Text = fechaString;
            idFuncionOculta.Text = idFuncion;

            selectedFuncion = int.Parse(idFuncion);

            
            
            label16.Text = cinema.BuscarFuncionUsuario(cinema.usuarioLogueado(), selectedFuncion).cantEntradas.ToString();
            


        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            this.transfCambiarPassword();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantEntradas = int.Parse(textBox1.Text);
            int idFuncion = int.Parse(idFuncionOculta.Text);
            if (cinema.devolverEntrada(idFuncion, cantEntradas))
            {
                MessageBox.Show("Entradas Devueltas");
            }
            else
            {
                MessageBox.Show("Error al Devolver");
            }

        }
    }
}
