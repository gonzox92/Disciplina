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
        private Dictionary<string, string> carreras;
        DataTable cursos;

        public Principal(DataTable cursos, Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.controller = new Controladores.Curso();
            this.cursos = cursos;
            this.carreras = carreras;
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
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.DisplayMember = "Value";
            this.txtCarrera.ValueMember = "Key";
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

        private void filterCursos()
        {
            string carrera = this.txtCarrera.Text;
            string year = this.txtYear.Value.ToString();
            string periodo = this.txtPeriodo.Text == "" ? "%" : this.txtPeriodo.Text;
            string paralelo = this.txtParalelo.Text;
            string curso = this.txtCurso.Text;

            this.dataSemestres.DataSource = this.controller.filterCursos(carrera, year, periodo, paralelo, curso);
        }

        private void txtCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterCursos();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            this.filterCursos();
        }

        private void txtPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterCursos();
        }

        private void txtParalelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterCursos();
        }

        private void txtCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterCursos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtCarrera.Text = "";
            this.txtYear.Value = DateTime.Now.Year;
            this.txtPeriodo.Text = "";
            this.txtParalelo.Text = "";
            this.txtCurso.Text = "";
        }
    }
}
