using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Disciplina.Modelos
{
    class Login
    {
        public string ingresar (String usuario, String password)
        {
            String[] columna = new String[] { "password", "privilegio" };
            String[] tabla = new String[] { "usuarios" };
            Dictionary<string, String[]> condicional = new Dictionary<string, String[]>();
            condicional.Add("usuario", new String[] {"= ", "'" + usuario + "'", "AND"});
            condicional.Add("password", new String[] { "=", "'" + Utilidades.encriptarPassword(password) + "'", "" });

            DataTable acceso = Consultas.Server.select(columna, tabla, condicional);

            if (acceso.Rows.Count.ToString() == "1")
            {
                return Convert.ToString(acceso.Rows[0]["privilegio"]);
            }
            return "denegado";
        }
    }
}
