using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Reportes : Controller
    {
        private Carrera carrera;
        private Estudiante estudiante;

        public Reportes()
        {
            this.carrera = new Carrera();
            this.estudiante = new Estudiante();
        }

        public void opciones()
        {
            Form listaOpciones = new Vistas.Reportes.Opciones();
            this.resolver(listaOpciones);
        }

        public void cursos()
        {
            DataTable carrerasTable = this.carrera.getCarreras();
            Dictionary<string, string> carreras = new Dictionary<string, string>();

            foreach (DataRow fila in carrerasTable.Rows)
            {
                carreras.Add(fila["ID"].ToString(), fila["Nombre"].ToString());
            }

            Form cursos = new Vistas.Reportes.Cursos(carreras);
            this.resolver(cursos);
        }

        public void listaEstudiantes()
        {
            DataTable estudiantes = this.estudiante.getEstudiantes();
            Form lista = new Vistas.Reportes.ListaEstudiantes(estudiantes);
            this.resolver(lista);
        }

        public void faltasEstudiante(Dictionary<string, string> datos)
        {
            Dictionary<string, string> cursos = this.estudiante.getCursosEstudiante(datos["ID"]);
            Form faltas = new Vistas.Reportes.Estudiante(datos, cursos);
            this.resolver(faltas);
        }
    }
}
