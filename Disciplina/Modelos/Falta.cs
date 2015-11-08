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
        public String puntos;

        public Falta(String grado, String nombre, String puntos)
        {
            this.grado = grado;
            this.nombre = nombre;
            this.puntos = puntos;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("grado", this.grado);
            tabla.Add("nombre", this.nombre);
            tabla.Add("puntos", this.puntos);

            return tabla;
        }
    }
}
