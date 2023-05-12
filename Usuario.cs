using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cinemania
{
    public class Usuario
    {
        public int id { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<Funcion> MisFunciones { get; set; }
        public double Credito { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsAdmin { get; set; }

        public Usuario(int id, int dni, string nombre, string apellido, string mail, string password, DateTime fechaNacimiento, List<Funcion> misFunciones,bool esAdmin, int intentos,bool bloqueo,double credit)
        {
            this.id = id;
            DNI = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Password = password;
            this.FechaNacimiento = fechaNacimiento;
            this.EsAdmin = esAdmin;
            this.IntentosFallidos = intentos;
            this.Bloqueado = bloqueo;
            this.Credito = credit;
            this.MisFunciones = new List<Funcion>();
        }   

        public string[] ToString()
        {

            return new string[] { id.ToString(),DNI.ToString(), Nombre, Apellido, Mail, Password, FechaNacimiento.ToString(), EsAdmin.ToString(), IntentosFallidos.ToString(), Bloqueado.ToString(), Credito.ToString()};

        }
    }
}
