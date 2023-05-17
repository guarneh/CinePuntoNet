using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemania
{
    internal class FuncionUsuario
    {
        public int idUsuario;
        public int idFuncion;
        public int cantEntradas;

        public FuncionUsuario(int idUsuario, int idFuncion, int cantEntradas)
        { 
            this.idUsuario = idUsuario;
            this.idFuncion = idFuncion;
            this.cantEntradas = cantEntradas;
        }



    }
}
