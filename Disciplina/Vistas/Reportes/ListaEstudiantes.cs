using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Reportes
{
    public partial class ListaEstudiantes : Form
    {
        private DataTable estudiantes;
        private Controladores.Estudiante controller;
        private Controladores.Reportes reportes;
        private Dictionary<string, string> carreras;

        public ListaEstudiantes(DataTable estudiantes, Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
            this.reportes = new Controladores.Reportes();
            this.carreras = carreras;
        }

        private void ListaEstudiantes_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.ValueMember = "Key";
            this.txtCarrera.DisplayMember = "Value";
        }

        private void showFaltasEstudiante()
        {
            if (this.dataEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow seleccionado = this.dataEstudiantes.SelectedRows[0];

            Dictionary<string, string> datos = new Dictionary<string, string>();
            datos.Add("ID", seleccionado.Cells[0].Value.ToString());
            datos.Add("Codigo", seleccionado.Cells[1].Value.ToString());
            datos.Add("Nombre", string.Format("{0} {1} {2}",
                seleccionado.Cells[3].Value.ToString(),
                seleccionado.Cells[4].Value.ToString(),
                seleccionado.Cells[5].Value.ToString()));

            this.reportes.faltasEstudiante(datos);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.showFaltasEstudiante();
        }

        private void dataEstudiantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.showFaltasEstudiante();
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
