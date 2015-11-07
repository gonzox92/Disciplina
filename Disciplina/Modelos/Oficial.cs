using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Oficial : Usuario, IModelo
    {
        public String codigo;
        public String grado;

        public Oficial(String nombre, String apellidoPaterno, String apellidoMaterno, String codigo, String grado, String usuario, String password)
            : base(nombre, apellidoPaterno, apellidoMaterno, usuario, password, "oficial")
        {
            this.codigo = codigo;
            this.grado = grado;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("nombre", this.nombre);
            tabla.Add("apellidoPaterno", this.apellidoPaterno);
            tabla.Add("apellidoMaterno", this.apellidoMaterno);
            tabla.Add("codigo", this.codigo);
            tabla.Add("grado", this.grado);
            tabla.Add("usuario", this.usuario);
            tabla.Add("password", this.password);

            return tabla;
        }
    }
}
