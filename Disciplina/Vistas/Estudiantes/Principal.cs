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
        private Dictionary<string, string> carreras;

        public Principal(DataTable estudiantes, Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
            this.carreras = carreras;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.ValueMember = "Key";
            this.txtCarrera.DisplayMember = "Value";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataEstudiantes.Columns.Clear();
            this.filterEstudiante();
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

                this.filterEstudiante();
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

            this.filterEstudiante();
        }

        private void filterEstudiante()
        {
            string codigo = this.txtCodigo.Text;
            string ci = this.txtCI.Text;
            string nombre = this.txtNombre.Text;
            string carrera = this.txtCarrera.Text;
            string year = this.txtYear.Value.ToString();
            string periodo = this.txtPeriodo.Text == "" ? "%" : this.txtPeriodo.Text;
            string paralelo = this.txtParalelo.Text;
            string curso = this.txtCurso.Text;

            this.dataEstudiantes.DataSource =
                this.controller.filterEstudiantes(codigo, ci, nombre, carrera, year, periodo, paralelo, curso);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = "";
            this.txtCI.Text = "";
            this.txtNombre.Text = "";
            this.txtCarrera.Text = "";
            this.txtYear.Value = DateTime.Now.Year;
            this.txtPeriodo.Text = "";
            this.txtParalelo.Text = "";
            this.txtCurso.Text = "";
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtCI_TextChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtParalelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }

        private void txtCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterEstudiante();
        }
    }
}
