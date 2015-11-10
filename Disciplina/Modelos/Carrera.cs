using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Carrera : IModelo
    {
        public String nombre;
        public String id;

        public Carrera(String nombre)
        {
            this.nombre = nombre;
        }

        public Carrera(String id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("nombre", this.nombre);

            return tabla;
        }
    }
}
