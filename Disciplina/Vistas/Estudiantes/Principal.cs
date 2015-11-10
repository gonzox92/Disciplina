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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar los estudiantes seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataEstudiantes.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.dataEstudiantes.DataSource = this.controller.getEstudiantes();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }

            string idEstudiante = this.dataEstudiantes.SelectedRows[0].Cells[0].Value.ToString();

            this.controller.actualizar(idEstudiante);

            this.dataEstudiantes.DataSource = this.controller.getEstudiantes();
        }
    }
}
