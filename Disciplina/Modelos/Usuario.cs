using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Usuario: IModelo
    {
        public String nombre;
        public String apellidoPaterno;
        public String apellidoMaterno;
        public String usuario;
        public String password;
        public String privilegio;

        public Usuario(String nombre, String apellidoPaterno, String apellidoMaterno)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.usuario = "";
            this.password = "";
        }

        public Usuario(String nombre, String apellidoPaterno, String apellidoMaterno, String usuario, String password, String privilegio)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.usuario = usuario;
            this.password = Utilidades.encriptarPassword(password);
            this.privilegio = privilegio;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("nombre", this.nombre);
            tabla.Add("apellidoPaterno", this.apellidoPaterno);
            tabla.Add("apellidoMaterno", this.apellidoMaterno);
            tabla.Add("usuario", this.usuario);
            tabla.Add("password", this.password);
            tabla.Add("privilegio", this.privilegio);

            return tabla;
        }
    }
}
