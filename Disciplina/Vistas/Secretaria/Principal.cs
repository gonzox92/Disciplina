using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Secretaria
{
    public partial class Principal : Form
    {
        private Controladores.Carrera carrera;
        private Controladores.Curso curso;
        private Controladores.CursoEstudiantes cursoEstudiante;
        private Controladores.Estudiante estudiante;

        public Principal()
        {
            InitializeComponent();
            this.carrera = new Controladores.Carrera();
            this.curso = new Controladores.Curso();
            this.cursoEstudiante = new Controladores.CursoEstudiantes();
            this.estudiante = new Controladores.Estudiante();
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            this.carrera.carreras();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            this.curso.cursos();
        }

        private void btnCursosEstudiantes_Click(object sender, EventArgs e)
        {
            this.cursoEstudiante.registrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.estudiante.estudiantes();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.carrera.actualizarCuenta();
        }
    }
}
