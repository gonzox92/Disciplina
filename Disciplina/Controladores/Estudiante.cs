using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Estudiante : Controller
    {
        public DataTable getEstudiantes()
        {
            string[] columnas = { 
                "E.ID as ID", 
                "E.codigo AS Codigo",
                "E.ci AS CI",
                "E.nombre AS Nombre", 
                "E.apellidoPaterno AS Paterno", 
                "E.apellidoMaterno AS Materno",
                "C.nombre as Carrera"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public Dictionary<string, string> getDetallesAlumnoPorCurso(string idEstudiante, string idCurso)
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();

            string[] columnas = {
                "E.ID AS IDEstudiante",
                "E.codigo",
                "(E.nombre + ' ' + E.apellidoPaterno + ' ' + E.apellidoMaterno) AS nombre",
                "C.ID as IDCurso",
                "C.periodo",
                "C.year",
                "C.periodo",
                "(C.curso + ' ' + C.paralelo) AS curso",
                "CR.nombre as carrera"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS CR", "cursos AS C", "cursoEstudiantes AS CE" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.ID", new string[] { "=", "CE.IDEstudiante", "AND" });
            filtro.Add("C.ID", new string[] { "=", "CE.IDCurso", "AND" });
            filtro.Add("C.IDCarrera", new string[] { "=", "CR.ID", "AND" });
            filtro.Add(" C.ID", new string[] { "=", idCurso, "AND" });
            filtro.Add(" E.ID", new string[] { "=", idEstudiante, "" });

            DataTable consulta = Modelos.Consultas.Server.select(columnas, tablas, filtro);
            foreach (DataRow fila in consulta.Rows)
            {
                datos.Add("IDEstudiante", fila["IDEstudiante"].ToString());
                datos.Add("codigo", fila["codigo"].ToString());
                datos.Add("nombre", fila["nombre"].ToString());
                datos.Add("IDCurso", fila["IDCurso"].ToString());
                datos.Add("year", fila["year"].ToString());
                datos.Add("periodo", fila["periodo"].ToString());
                datos.Add("curso", fila["curso"].ToString());
                datos.Add("carrera", fila["carrera"].ToString());
            }

            return datos;
        }

        public void estudiantes()
        {
            DataTable estudiantes = this.getEstudiantes();
            Form vista = new Vistas.Estudiantes.Principal(estudiantes);
            this.resolver(vista);
        }

        public void registrar()
        {
            Controladores.Carrera carreraController = new Controladores.Carrera();
            DataTable carreras = carreraController.getCarreras();

            Dictionary<string, string> carrerasEmi = new Dictionary<string, string>();
            foreach (DataRow carrera in carreras.Rows) 
            {
                carrerasEmi.Add(carrera["ID"].ToString(), carrera["nombre"].ToString());
            }

            Form vista = new Vistas.Estudiantes.Registrar(carrerasEmi);
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("estudiantes", datos.esquema());
        }

        public List<DataGridViewRow> buscar()
        {
            DataTable estudiantes = this.getEstudiantes();
            Vistas.Estudiantes.Buscar vista = new Vistas.Estudiantes.Buscar(estudiantes);
            vista.ShowDialog();
            return vista.estudiantesSeleccionados;
        }
    }
}
