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

        public Dictionary<string, string> getCursosEstudiante(string idEstudiante)
        {
            Dictionary<string, string> cursos = new Dictionary<string, string>();
            Dictionary<string, string> datos = new Dictionary<string, string>();

            string[] columnas = {
                "C.ID",
                "(C.curso+' '+C.paralelo) AS curso",
                "C.year",
                "CR.nombre",
                "C.periodo"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS CR", "cursos AS C", "cursoEstudiantes AS CE" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.ID", new string[] { "=", "CE.IDEstudiante", "AND" });
            filtro.Add("C.ID", new string[] { "=", "CE.IDCurso", "AND" });
            filtro.Add("C.IDCarrera", new string[] { "=", "CR.ID", "AND" });
            filtro.Add(" E.ID", new string[] { "=", idEstudiante, "" });

            DataTable consulta = Modelos.Consultas.Server.selectDistinct(columnas, tablas, filtro);

            foreach (DataRow curso in consulta.Rows)
            {
                cursos.Add(curso["ID"].ToString(), 
                    string.Format("{0} - {1}/{2}/{3}",
                        curso["curso"], curso["nombre"], curso["year"], curso["periodo"]));
            }

            return cursos;
        }

        private Dictionary<string, string> getDatosEstudiante(string[] columnas, string[] tablas, Dictionary<string, string[]> filtro)
        {
            DataTable carreraTable = Modelos.Consultas.Server.select(columnas, tablas, filtro);
            string id = carreraTable.Rows[0][0].ToString();
            string codigo = carreraTable.Rows[0][1].ToString();
            string nombre = carreraTable.Rows[0][2].ToString();
            string apellidoPaterno = carreraTable.Rows[0][3].ToString();
            string apellidoMaterno = carreraTable.Rows[0][4].ToString();
            string direccion = carreraTable.Rows[0][5].ToString();
            string telefono = carreraTable.Rows[0][6].ToString();
            string ci = carreraTable.Rows[0][7].ToString();
            string idCarrera = carreraTable.Rows[0][8].ToString();
            string carrera = carreraTable.Rows[0][9].ToString();

            Dictionary<string, string> estudiante = new Dictionary<string, string>();
            estudiante.Add("ID", id);
            estudiante.Add("codigo", codigo);
            estudiante.Add("nombre", nombre);
            estudiante.Add("apellidoPaterno", apellidoPaterno);
            estudiante.Add("apellidoMaterno", apellidoMaterno);
            estudiante.Add("direccion", direccion);
            estudiante.Add("telefono", telefono);
            estudiante.Add("ci", ci);
            estudiante.Add("IDCarrera", idCarrera);
            estudiante.Add("carrera", carrera);

            return estudiante;
        }

        public Dictionary<string, string> getEstudiante(string idEstudiante)
        {
            string[] columnas = { 
                "E.ID", 
                "E.codigo",
                "E.nombre", 
                "E.apellidoPaterno", 
                "E.apellidoMaterno",
                "E.direccion",
                "E.telefono",
                "E.ci",
                "C.ID AS IDCarrera",
                "C.nombre as carrera"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "AND" });
            filtro.Add("E.ID", new string[] { "=", idEstudiante, "" });

            return this.getDatosEstudiante(columnas, tablas, filtro);
        }

        public Dictionary<string, string> getEstudianteByCodigo(string codigo)
        {
            string[] columnas = { 
                "E.ID", 
                "E.codigo",
                "E.nombre", 
                "E.apellidoPaterno", 
                "E.apellidoMaterno",
                "E.direccion",
                "E.telefono",
                "E.ci",
                "C.ID AS IDCarrera",
                "C.nombre as carrera"
            };
            string[] tablas = { "estudiantes AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "AND" });
            filtro.Add("E.codigo", new string[] { "=", string.Format("'{0}'", codigo), "" });

            return this.getDatosEstudiante(columnas, tablas, filtro);
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

            Form vista = new Vistas.Estudiantes.Registrar(carrerasEmi, "registrar", null);
            this.resolver(vista);
        }

        public void actualizar(string idEstudiante)
        {
            Controladores.Carrera carreraController = new Controladores.Carrera();
            DataTable carreras = carreraController.getCarreras();

            Dictionary<string, string> carrerasEmi = new Dictionary<string, string>();
            foreach (DataRow carrera in carreras.Rows)
            {
                carrerasEmi.Add(carrera["ID"].ToString(), carrera["nombre"].ToString());
            }

            Form vista = new Vistas.Estudiantes.Registrar(carrerasEmi, "actualizar", this.getEstudiante(idEstudiante));
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

        public bool eliminar(string id)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("ID", new string[] { "=", id, "" });

            return Modelos.Consultas.Server.delete("estudiantes", datos);
        }
    }
}
