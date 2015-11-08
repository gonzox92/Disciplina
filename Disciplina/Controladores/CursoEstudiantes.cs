using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class CursoEstudiantes : Controller
    {
        private Carrera carrera;

        public CursoEstudiantes()
        {
            this.carrera = new Carrera();
        }

        public DataTable getEstudiantes(string idCurso)
        {
            string[] columnas = { 
                "E.ID as ID", 
                "E.codigo AS Codigo",
                "E.ci AS CI",
                "E.nombre AS Nombre", 
                "E.apellidoPaterno AS Paterno", 
                "E.apellidoMaterno AS Materno",
                "CR.nombre as Carrera"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS CR", "cursos AS C", "cursoEstudiantes AS CE" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "CR.ID", "AND" });
            filtro.Add("E.ID", new string[] { "=", "CE.IDEstudiante", "AND" });
            filtro.Add("C.ID", new string[] { "=", "CE.IDCurso", "AND" });
            filtro.Add(" C.ID", new string[] { "=", string.Format("'{0}'", idCurso), "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("cursoEstudiantes", datos.esquema());
        }

        public void registrar()
        {
            DataTable carrerasTable = this.carrera.getCarreras();
            Dictionary<string, string> carreras = new Dictionary<string, string>();

            foreach (DataRow fila in carrerasTable.Rows)
            {
                carreras.Add(fila["ID"].ToString(), fila["Nombre"].ToString());
            }

            Form vista = new Vistas.Cursos_Estudiantes.Curso(carreras);
            this.resolver(vista);
        }

        public bool delete(string idEstudiante, string idCurso)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("IDEstudiante", new string[] { "=", idEstudiante, "AND" });
            datos.Add("IDCurso", new string[] { "=", idCurso, ""});

            return Modelos.Consultas.Server.delete("cursoEstudiantes", datos);
        }
    }
}
