using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Falta : IModelo
    {
        String grado;
        public String nombre;

        public Falta(String grado, String nombre)
        {
            this.grado = grado;
            this.nombre = nombre;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("grado", this.grado);
            tabla.Add("nombre", this.nombre);

            return tabla;
        }
    }
}
