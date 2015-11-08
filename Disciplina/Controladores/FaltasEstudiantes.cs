using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class FaltasEstudiantes : Controller
    {
        private Carrera carrera;
        private Estudiante estudiante;

        public FaltasEstudiantes()
        {
            this.carrera = new Carrera();
            this.estudiante = new Estudiante();
        }

        public DataTable getEstudiantes(string idCurso)
        {
            string[] columnas = { 
                "E.ID as ID", 
                "E.codigo AS Codigo",
                "E.ci AS CI",
                "E.nombre AS Nombre", 
                "E.apellidoPaterno AS Paterno", 
                "E.apellidoMaterno AS Materno"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS CR", "cursos AS C", "cursoEstudiantes AS CE" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "CR.ID", "AND" });
            filtro.Add("E.ID", new string[] { "=", "CE.IDEstudiante", "AND" });
            filtro.Add("C.ID", new string[] { "=", "CE.IDCurso", "AND" });
            filtro.Add(" C.ID", new string[] { "=", string.Format("'{0}'", idCurso), "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public void principal()
        {
            DataTable carrerasTable = this.carrera.getCarreras();
            Dictionary<string, string> carreras = new Dictionary<string, string>();

            foreach (DataRow fila in carrerasTable.Rows)
            {
                carreras.Add(fila["ID"].ToString(), fila["Nombre"].ToString());
            }

            Form vista = new Vistas.Faltas_Estudiantes.Principal(carreras);
            this.resolver(vista);
        }

        public void detalleFaltas(string idEstudiante, string idCurso)
        {
            Dictionary<string, string> detalleEstudiante = estudiante.getDetallesAlumnoPorCurso(idEstudiante, idCurso);

            Form vista = new Vistas.Faltas_Estudiantes.Faltas(detalleEstudiante);
            this.resolver(vista);
        }
    }
}
