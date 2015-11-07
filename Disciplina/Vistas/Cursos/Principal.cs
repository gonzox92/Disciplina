using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Cursos
{
    public partial class Principal : Form
    {
        private Controladores.Curso controller;
        DataTable cursos;

        public Principal(DataTable cursos)
        {
            InitializeComponent();
            this.controller = new Controladores.Curso();
            this.cursos = cursos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataSemestres.Columns.Clear();
            this.dataSemestres.DataSource = controller.getCursos();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataSemestres.DataSource = this.cursos;
        }
    }
}
