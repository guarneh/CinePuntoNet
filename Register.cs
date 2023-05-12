using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemania
{
    public partial class Register : Form
    {

        public Cine miCine;
        public RegisterToLogin registerToLogin;
        public Register(Cine cine)
        {
            miCine = cine;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dni = Int32.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string mail = textBox4.Text;
            string pass = textBox5.Text;
            DateTime fechaNacimiento = dateTimePicker1.Value;
            bool admin = checkBox1.Checked;
            int intentos = 0;
            bool bloqueo = false;
            double credit = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            if (dni != null && nombre != null && nombre != "" && apellido != null && apellido != "" && mail != null && mail != "" && pass != null && pass != "" && fechaNacimiento != null)
            {

                if (miCine.agregarUsuario(dni, nombre, apellido, mail, pass, fechaNacimiento, admin, intentos, bloqueo, credit))
                {
                    MessageBox.Show("Registrado con éxito");
                    this.registerToLogin();
                }
                else
                {
                    MessageBox.Show("Error, usuario o contraseña incorrectos");
                }
            }
            else
                MessageBox.Show("Debe ingresar un usuario y contraseña!");
        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            this.registerToLogin();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //validacion de numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            //validacion de letras
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar >= 255))
            {
                MessageBox.Show("Solo Letras", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        public delegate void RegisterToLogin();
    }
}
