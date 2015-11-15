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

        public DataTable filterCursos(string carrera, string year, string periodo, string paralelo, string curso)
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
            filtro.Add("C.IDCarrera", new string[] { "=", "R.ID", "AND" });
            filtro.Add("R.nombre", new string[] { " LIKE", string.Format("'%{0}%'", carrera), "AND" });
            filtro.Add("C.year", new string[] { ">=", year, "AND" });
            filtro.Add("C.periodo", new string[] { " LIKE", string.Format("'{0}'", periodo), "AND" });
            filtro.Add("C.paralelo", new string[] { " LIKE", string.Format("'%{0}%'", paralelo), "AND" });
            filtro.Add("C.curso", new string[] { " LIKE", string.Format("'%{0}%'", curso), "" });

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

        public Dictionary<string, string> getCurso(string idCurso)
        {
            string[] columnas = { 
                "*"
            };
            string[] tablas = { "cursos" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("ID", new string[] { "=", idCurso, "" });

            DataTable carreraTable = Modelos.Consultas.Server.select(columnas, tablas, filtro);
            string id = carreraTable.Rows[0][0].ToString();
            string idCarrera = carreraTable.Rows[0][1].ToString();
            string year = carreraTable.Rows[0][2].ToString();
            string periodo = carreraTable.Rows[0][3].ToString();
            string paralelo = carreraTable.Rows[0][4].ToString();
            string nombreCurso = carreraTable.Rows[0][5].ToString();

            Dictionary<string, string> curso = new Dictionary<string, string>();
            curso.Add("ID", id);
            curso.Add("IDCarrera", idCarrera);
            curso.Add("year", year);
            curso.Add("periodo", periodo);
            curso.Add("paralelo", paralelo);
            curso.Add("curso", nombreCurso);

            return curso;
        }

        public void cursos()
        {
            Form vista = new Vistas.Cursos.Principal(null, this.returnCarreras());
            this.resolver(vista);
        }

        private Dictionary<string, string> returnCarreras()
        {
            DataTable carrerasTable = this.carrera.getCarreras();
            Dictionary<string, string> carreras = new Dictionary<string, string>();

            carreras.Add("", "");
            foreach (DataRow fila in carrerasTable.Rows)
            {
                carreras.Add(fila["ID"].ToString(), fila["Nombre"].ToString());
            }

            return carreras;
        }

        public void registrar()
        {
            Form vista = new Vistas.Cursos.Registrar("registrar", this.returnCarreras(), null);
            this.resolver(vista);
        }

        public void actualizar(string idCurso)
        {
            Form vista = new Vistas.Cursos.Registrar("actualizar", this.returnCarreras(), this.getCurso(idCurso));
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("cursos", datos.esquema());
        }

        public bool eliminar(string id)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("ID", new string[] { "=", id, "" });

            return Modelos.Consultas.Server.delete("cursos", datos);
        }
    }
}
