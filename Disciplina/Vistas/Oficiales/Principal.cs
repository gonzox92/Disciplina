using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Oficiales
{
    public partial class Principal : Form
    {
        private DataTable oficiales;
        private Controladores.EstudianteOficial controller;
        private Dictionary<string, string> carreras;

        public Principal(DataTable oficiales, Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.oficiales = oficiales;
            this.controller = new Controladores.EstudianteOficial();
            this.carreras = carreras;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataOficiales.DataSource = this.oficiales;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.ValueMember = "Key";
            this.txtCarrera.DisplayMember = "Value";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataOficiales.Columns.Clear();
            this.filterOficiales();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataOficiales.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar los oficiales seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataOficiales.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.filterOficiales();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataOficiales.SelectedRows.Count == 0)
            {
                return;
            }

            string idOficial = this.dataOficiales.SelectedRows[0].Cells[0].Value.ToString();

            this.controller.actualizar(idOficial);

            this.filterOficiales();
        }

        private void filterOficiales()
        {
            string codigo = this.txtCodigo.Text;
            string grado = this.txtGrado.Text;
            string ci = this.txtCI.Text;
            string nombre = this.txtNombre.Text;
            string carrera = this.txtCarrera.Text;

            this.dataOficiales.DataSource = this.controller.filterOficiales(codigo, grado, ci, nombre, carrera);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = "";
            this.txtGrado.Text = "";
            this.txtCI.Text = "";
            this.txtNombre.Text = "";
            this.txtCarrera.Text = "";
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.filterOficiales();
        }

        private void txtGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterOficiales();
        }

        private void txtCI_TextChanged(object sender, EventArgs e)
        {
            this.filterOficiales();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.filterOficiales();
        }

        private void txtCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterOficiales();
        }
    }
}
