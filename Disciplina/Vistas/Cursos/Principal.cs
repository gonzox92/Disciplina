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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataSemestres.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar los cursos seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataSemestres.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.dataSemestres.DataSource = this.controller.getCursos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataSemestres.SelectedRows.Count == 0)
            {
                return;
            }

            string idCurso = this.dataSemestres.SelectedRows[0].Cells[0].Value.ToString();

            this.controller.actualizar(idCurso);

            this.dataSemestres.DataSource = this.controller.getCursos();
        }
    }
}
