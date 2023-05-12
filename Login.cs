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

namespace Cinemania
{
    public partial class Form2 : Form
    {
        public Cine miCine;
        public TransfDelegado TransfEvento;
        public LoginToRegister loginToRegister;
        public Form2(Cine cine)
        {
            miCine = cine;
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.loginToRegister();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox6.Text;
            string pass = textBox7.Text;



            textBox6.Clear();
            textBox7.Clear();
            if (usuario != null && usuario != "" && pass != null && pass != "")
            {

                if (miCine.iniciarSesion(usuario, pass))

                    this.TransfEvento();
            }

            else
                MessageBox.Show("Debe ingresar un usuario y contraseña!");
        }

        public delegate void TransfDelegado();

        public delegate void LoginToRegister();
    }
}
