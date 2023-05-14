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
    public partial class CambiarPassword : Form
    {

        public Cine cinema;
        public cambiarPassToUsuario passToUsuario;
        public CambiarPassword(Cine cine)
        {
            InitializeComponent();
            cinema = cine;
        }

        public delegate void cambiarPassToUsuario();

        private void button2_Click(object sender, EventArgs e)
        {
            this.passToUsuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cinema.cambiarPassword(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("la contraseña ha sido cambiada con exito");
                this.passToUsuario();
            }
            else
            {
                MessageBox.Show("No se ha podido cambiar la contraseña");
            }
        }
    }
}
