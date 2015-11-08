using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Curso : Controller
    {
        private Carrera carrera;

        public Curso()
        {
            this.carrera = new Carrera();
        }

        public DataTable getCursos()
        {
            string[] columnas = { 
                "C.ID",
                "R.nombre AS Carrera",
                "C.year AS Año",
                "C.periodo AS Periodo",
                "C.paralelo AS Paralelo",
                "C.curso AS Curso"
            };
            string[] tablas = { "cursos AS C", "carreras AS R" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("C.IDCarrera", new string[] { "=", "R.ID", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public Dictionary<string, string> getCursos(string year, string periodo, string carrera)
        {
            string[] columnas = { 
                "ID",
                "(curso + ' ' + paralelo) AS curso",
            };
            string[] tablas = { "cursos" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("IDCarrera", new string[] { "=", carrera, "AND" });
            filtro.Add("year", new string[] { "=", year, "AND" });
            filtro.Add("periodo", new string[] { "=", string.Format("'{0}'", periodo), "" });

            DataTable cursosTable = Modelos.Consultas.Server.selectDistinct(columnas, tablas, filtro);
            Dictionary<string, string> cursos = new Dictionary<string, string>();

            foreach (DataRow fila in cursosTable.Rows)
            {
                cursos.Add(fila["ID"].ToString(), fila["curso"].ToString());
            }

            return cursos;
        }

        public void cursos()
        {
            DataTable cursos = this.getCursos();
            Form vista = new Vistas.Cursos.Principal(cursos);
            this.resolver(vista);
        }

        public void registrar()
        {
            DataTable carrerasTable = this.carrera.getCarreras();
            Dictionary<string, string> carreras = new Dictionary<string, string>();

            foreach (DataRow fila in carrerasTable.Rows)
            {
                carreras.Add(fila["ID"].ToString(), fila["Nombre"].ToString());
            }

            Form vista = new Vistas.Cursos.Registrar(carreras);
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("cursos", datos.esquema());
        }
    }
}
