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

        public Dictionary<string, string> buscar()
        {
            DataTable faltas = this.getFaltas();
            Vistas.Faltas.Buscar vista = new Vistas.Faltas.Buscar(faltas);
            vista.ShowDialog();
            return vista.faltaSeleccionada;
        }

        public Dictionary<string, string> getFalta(string idFalta)
        {
            string[] columnas = { 
                "ID", 
                "nombre",
                "grado",
                "puntos"
            };
            string[] tablas = { "faltasRac" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("ID", new string[] { "=", idFalta, "" });

            DataTable carreraTable = Modelos.Consultas.Server.select(columnas, tablas, filtro);
            string id = carreraTable.Rows[0][0].ToString();
            string nombre = carreraTable.Rows[0][1].ToString();
            string grado = carreraTable.Rows[0][2].ToString();
            string puntos = carreraTable.Rows[0][3].ToString();

            Dictionary<string, string> carrera = new Dictionary<string, string>();
            carrera.Add("ID", id);
            carrera.Add("nombre", nombre);
            carrera.Add("grado", grado);
            carrera.Add("puntos", puntos);

            return carrera;
        }

        public void registrar()
        {
            Form vista = new Vistas.Faltas.Registrar("registrar", null);
            this.resolver(vista);
        }

        public void actualizar(string idFalta)
        {
            Form vista = new Vistas.Faltas.Registrar("actualizar", this.getFalta(idFalta));
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("faltasRac", datos.esquema());
        }

        public bool eliminar(string idFalta)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("ID", new string[] { "=", idFalta, "" });

            return Modelos.Consultas.Server.delete("faltasRac", datos);
        }
    }
}
