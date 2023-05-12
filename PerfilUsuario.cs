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
            label5.Text = cine.usuarioLogueado().DNI.ToString();
            label7.Text = cine.usuarioLogueado().Mail;
            label8.Text = cine.usuarioLogueado().Nombre + " " + cine.usuarioLogueado().Apellido;
        }



        public delegate void usuarioToMain();
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

            foreach (Funcion f in cinema.usuarioLogueado().MisFunciones)
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

            selectedFuncion = int.Parse(idFuncion);

        }
    }
}
