using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Estudiantes
{
    public partial class Principal : Form
    {
        private DataTable estudiantes;
        private Controladores.Estudiante controller;

        public Principal(DataTable estudiantes)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataEstudiantes.Columns.Clear();
            this.dataEstudiantes.DataSource = this.controller.getEstudiantes();
        }
    }
}
