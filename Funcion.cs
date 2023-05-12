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

        public Sala miSala { get; set; }

        public Pelicula miPelicula { get; set; }

        public List<Usuario> clientes { get; set;}

        public DateTime fecha { get; set; }

        public int cantClientes { get; set; }

        public double costo { get; set; }

        public Funcion(int ID, Sala miSala, Pelicula miPelicula, List<Usuario> clientes, DateTime fecha, int cantClientes, double costo) 
        {
            this.ID = ID;
            this.miSala = miSala;
            this.miPelicula = miPelicula;
            this.clientes = new List<Usuario>();
            this.fecha = fecha;
            this.cantClientes = clientes.Count;
            this.costo = costo;
            
        }

        public string[] ToString()
        {
            return new string[] { ID.ToString(), miSala.ubicacion, miPelicula.nombre, fecha.ToString(), cantClientes.ToString(),costo.ToString() };
        }
    }
}
