using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Estudiante : Usuario, IModelo
    {
        public String id;
        public String ci;
        public String codigo;
        public String telefono;
        public String direccion;
        public String carrera;

        public Estudiante(String ci, String nombre, String apellidoPaterno, String apellidoMaterno, String codigo, String carrera, String telefono, String direccion)
            : base(nombre, apellidoMaterno, apellidoMaterno, codigo, codigo, "estudiante")
        {
            this.ci = ci;
            this.codigo = codigo;
            this.telefono = telefono;
            this.direccion = direccion;
            this.carrera = carrera;
        }

        public Estudiante(String id, String ci, String nombre, String apellidoPaterno, String apellidoMaterno, String codigo, String carrera, String telefono, String direccion)
            : base(nombre, apellidoMaterno, apellidoMaterno, codigo, codigo, "estudiante")
        {
            this.id = id;
            this.ci = ci;
            this.codigo = codigo;
            this.telefono = telefono;
            this.direccion = direccion;
            this.carrera = carrera;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("ci", this.ci);
            tabla.Add("nombre", this.nombre);
            tabla.Add("apellidoPaterno", this.apellidoPaterno);
            tabla.Add("apellidoMaterno", this.apellidoMaterno);
            tabla.Add("codigo", this.codigo);
            tabla.Add("direccion", this.direccion);
            tabla.Add("telefono", this.telefono);
            tabla.Add("carrera", this.carrera);

            return tabla;
        }
    }
}
