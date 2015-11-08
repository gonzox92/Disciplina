using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Falta : Controller
    {
        public DataTable getFaltas()
        {
            string[] columnas = { 
                "ID", 
                "grado AS Grado",
                "nombre AS Falta",
                "puntos AS Puntos"
            };
            string[] tablas = { "faltasRac" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("1", new string[] { "=", "1", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public void faltas()
        {
            DataTable faltas = this.getFaltas();
            Form vista = new Vistas.Faltas.Principal(faltas);
            this.resolver(vista);
        }

        public void registrar()
        {
            Form vista = new Vistas.Faltas.Registrar();
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("faltasRac", datos.esquema());
        }
    }
}
