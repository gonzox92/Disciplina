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

        public void registrar()
        {
            DataTable estudiantes = this.getEstudiantes();
            Form vista = new Vistas.Cursos_Estudiantes.Registrar(estudiantes);
            this.resolver(vista);
        }
    }
}
