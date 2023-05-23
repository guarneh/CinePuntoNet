using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemania
{
    public class Funcion
    {
        public int ID { get; set; }

        public int idSala { get; set; }

        public int idPelicula { get; set; }

        public Sala miSala { get; set; }

        public Pelicula miPelicula { get; set; }

        public List<Usuario> clientes { get; set;}

        public DateTime fecha { get; set; }

        public int cantClientes { get; set; }

        public double costo { get; set; }

        public Funcion(int ID, int idSala, int idPelicula, DateTime fecha, int cantClientes, double costo) 
        {
            this.ID = ID;
            this.idSala = idSala;
            this.idPelicula = idPelicula;
            this.clientes = new List<Usuario>();
            this.fecha = fecha;
            this.cantClientes = clientes.Count;
            this.costo = costo;
            
        }

        public string[] ToString()
        {
            return new string[] { ID.ToString(),idSala.ToString(), idPelicula.ToString(), fecha.ToString(), cantClientes.ToString(), costo.ToString() };
        }
    }
}
