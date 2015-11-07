using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Encargado : Controller
    {
        public DataTable getCuentas()
        {
            string[] columnas = { 
                "ID", 
                "nombre AS Nombre", 
                "apellidoPaterno AS Paterno", 
                "apellidoMaterno AS Materno", 
                "usuario AS Usuario", 
                "privilegio AS Privilegio" 
            };
            string[] tablas = { "usuarios" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("1", new string[] { "=", "1", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public void cuentas()
        {
            DataTable cuentas = this.getCuentas();
            Form vista = new Vistas.Comunes.Cuentas(cuentas);
            this.resolver(vista);
        }

        public void registrar()
        {
            Form vista = new Vistas.Comunes.RegistrarCuenta(null);
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("usuarios", datos.esquema());
        }
    }
}
