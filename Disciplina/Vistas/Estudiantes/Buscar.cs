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
        private Dictionary<string, string> carreras;

        public Buscar(DataTable estudiantes, Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
            this.estudiantesSeleccionados = new List<DataGridViewRow>();
            this.carreras = carreras;
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.ValueMember = "Key";
            this.txtCarrera.DisplayMember = "Value";
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
