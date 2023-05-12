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

        public List<Funcion> misFunciones { get; set; }

        public int duracion { get; set; }

        public Pelicula(int id, string nombre, string sinopsis, string poster,List<Funcion> misFunciones,  int duracion)
        {
            this.id = id;
            this.nombre = nombre;
            this.sinopsis = sinopsis;
            this.poster = poster;
            this.misFunciones = new List<Funcion>();
          
            this.duracion = duracion;
        }

        public string[] ToString()
        {
            return new string[] { id.ToString(), nombre, sinopsis, poster, duracion.ToString()};
        }
    }
}
