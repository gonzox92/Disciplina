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
    public partial class Buscar : Form
    {
        private DataTable estudiantes;
        private Controladores.Estudiante controller;
        public List<DataGridViewRow> estudiantesSeleccionados;

        public Buscar(DataTable estudiantes)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
            this.estudiantesSeleccionados = new List<DataGridViewRow>();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int total = this.dataEstudiantes.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (total > 0)
            {
                foreach (DataGridViewRow estudiante in this.dataEstudiantes.SelectedRows)
                {
                    this.estudiantesSeleccionados.Add(estudiante);
                }
                this.Close();
            }
        }
    }
}
