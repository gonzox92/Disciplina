using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class EstudianteOficial : IModelo
    {
        public String ID;
        public String grado;
        public String nombre;
        public String apellidoPaterno;
        public String apellidoMaterno;
        public String codigo;
        public String direccion;
        public String telefono;
        public String carrera;
        public String ci;

        public EstudianteOficial(String ID, String grado, String nombre, String apellidoPaterno, 
            String apellidoMaterno, String codigo, String direccion, String telefono, String carrera, String ci)
        {
            this.ID = ID;
            this.grado = grado;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.codigo = codigo;
            this.direccion = direccion;
            this.telefono = telefono;
            this.carrera = carrera;
            this.ci = ci;
        }

        public EstudianteOficial(String grado, String nombre, String apellidoPaterno,
            String apellidoMaterno, String codigo, String direccion, String telefono, String carrera, String ci)
        {
            this.grado = grado;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.codigo = codigo;
            this.direccion = direccion;
            this.telefono = telefono;
            this.carrera = carrera;
            this.ci = ci;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("nombre", this.nombre);
            tabla.Add("apellidoPaterno", this.apellidoPaterno);
            tabla.Add("apellidoMaterno", this.apellidoMaterno);
            tabla.Add("codigo", this.codigo);
            tabla.Add("grado", this.grado);
            tabla.Add("direccion", this.direccion);
            tabla.Add("telefono", this.telefono);
            tabla.Add("carrera", this.carrera);
            tabla.Add("ci", this.ci);

            return tabla;
        }
    }
}
