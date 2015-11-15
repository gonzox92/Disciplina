using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Carrera : Controller
    {
        public DataTable getCarreras()
        {
            string[] columnas = { 
                "ID", 
                "nombre AS Nombre"
            };
            string[] tablas = { "carreras" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("1", new string[] { "=", "1", "" });
            filtro.Add("ORDER BY ", new string[] { "nombre", "ASC", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public DataTable filterCarreras(string nombre)
        {
            string[] columnas = { 
                "ID", 
                "nombre AS Nombre"
            };
            string[] tablas = { "carreras" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("nombre", new string[] { " LIKE", string.Format("'%{0}%'", nombre), "" });
            filtro.Add("ORDER BY ", new string[] { "nombre", "ASC", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public Dictionary<string, string> getCarrera(string idCarrera)
        {
            string[] columnas = { 
                "ID", 
                "nombre"
            };
            string[] tablas = { "carreras" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("ID", new string[] { "=", idCarrera, "" });

            DataTable carreraTable = Modelos.Consultas.Server.select(columnas, tablas, filtro);
            string id = carreraTable.Rows[0][0].ToString();
            string nombre = carreraTable.Rows[0][1].ToString();

            Dictionary<string, string> carrera = new Dictionary<string,string>();
            carrera.Add("ID", id);
            carrera.Add("nombre", nombre);

            return carrera;
        }

        public void carreras()
        {
            DataTable carreras = this.getCarreras();
            Form vista = new Vistas.Carreras.Principal(carreras);
            this.resolver(vista);
        }

        public void registrar()
        {
            Form vista = new Vistas.Carreras.Registrar("registrar", null);
            this.resolver(vista);
        }

        public void actualizar(string idCarrera)
        {
            Form vista = new Vistas.Carreras.Registrar("actualizar", this.getCarrera(idCarrera));
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("carreras", datos.esquema());
        }

        public bool eliminar(string idCarrera)
        {
            Dictionary<string, String[]> datos = new Dictionary<string, String[]>();
            datos.Add("ID", new string[] { "=", idCarrera, "" });

            return Modelos.Consultas.Server.delete("carreras", datos);
        }
    }
}
