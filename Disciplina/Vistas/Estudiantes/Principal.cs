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

        private void filterEstudiante()
        {
            string codigo = this.txtCodigo.Text;
            string ci = this.txtCI.Text;
            string nombre = this.txtNombre.Text;
            string carrera = this.txtCarrera.Text;

            this.dataEstudiantes.DataSource = this.controller.filterEstudiantes(codigo, ci, nombre, carrera);
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
    }
}
