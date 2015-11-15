using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class EstudianteOficial : Controller
    {
        private Carrera carrera;

        public EstudianteOficial()
        {
            this.carrera = new Carrera();
        }

        public DataTable getOficiales()
        {
            string[] columnas = { 
                "E.ID as ID", 
                "E.codigo AS Codigo",
                "E.grado AS Grado",
                "E.ci AS CI",
                "E.nombre AS Nombre", 
                "E.apellidoPaterno AS Paterno", 
                "E.apellidoMaterno AS Materno",
                "C.nombre as Carrera"
            };
            string[] tablas = { "oficiales AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public DataTable filterOficiales(string codigo, string grado, string ci, string nombre, string carrera)
        {
            string[] columnas = { 
                "E.ID as ID", 
                "E.codigo AS Codigo",
                "E.grado AS Grado",
                "E.ci AS CI",
                "E.nombre AS Nombre", 
                "E.apellidoPaterno AS Paterno", 
                "E.apellidoMaterno AS Materno",
                "C.nombre as Carrera"
            };
            string[] tablas = { "oficiales AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "AND" });
            filtro.Add("E.codigo", new string[] { " LIKE", string.Format("'%{0}%'", codigo), "AND" });
            filtro.Add("E.grado", new string[] { " LIKE", string.Format("'%{0}%'", grado), "AND" });
            filtro.Add("E.ci", new string[] { " LIKE", string.Format("'%{0}%'", ci), "AND" });
            filtro.Add("(E.nombre + ' ' + E.apellidoPaterno + ' ' + E.apellidoMaterno)", new string[] { " LIKE", string.Format("'%{0}%'", nombre), "AND" });
            filtro.Add("C.nombre", new string[] { " LIKE", string.Format("'%{0}%'", carrera), "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        private Dictionary<string, string> getDatosOficial(string[] columnas, string[] tablas, Dictionary<string, string[]> filtro)
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
            string grado = carreraTable.Rows[0][10].ToString();

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
            estudiante.Add("grado", grado);

            return estudiante;
        }

        public Dictionary<string, string> getOficial(string idOficial)
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
                "C.nombre as carrera",
                "E.grado",
            };
            string[] tablas = { "oficiales AS E", "carreras AS C" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("E.carrera", new string[] { "=", "C.ID", "AND" });
            filtro.Add("E.ID", new string[] { "=", idOficial, "" });

            return this.getDatosOficial(columnas, tablas, filtro);
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

        public void oficiales()
        {
            Form vista = new Vistas.Oficiales.Principal(null, this.returnCarreras());
            this.resolver(vista);
        }

        public void registrar()
        {
            Form vista = new Vistas.Oficiales.Registrar(this.returnCarreras(), "registrar", null);
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("oficiales", datos.esquema());
        }

        public bool eliminar(string id)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("ID", new string[] { "=", id, "" });

            return Modelos.Consultas.Server.delete("oficiales", datos);
        }

        public void actualizar(string idOficial)
        {
            Form vista = new Vistas.Oficiales.Registrar(this.returnCarreras(), "actualizar", this.getOficial(idOficial));
            this.resolver(vista);
        }
    }
}
