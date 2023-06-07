using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemania
{
    public class Pelicula
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string sinopsis { get; set; }

        public string poster { get; set; }

        public List<Funcion> misFunciones { get; set; } = new List<Funcion>();

        public int duracion { get; set; }

        public Pelicula() { }

        public Pelicula(int id, string nombre, string sinopsis, string poster, int duracion)
        {
            this.id = id;
            this.nombre = nombre;
            this.sinopsis = sinopsis;
            this.poster = poster;
            this.duracion = duracion;
        }

        public string[] ToString()
        {
            return new string[] { id.ToString(), nombre, sinopsis, poster, duracion.ToString()};
        }
    }
}
