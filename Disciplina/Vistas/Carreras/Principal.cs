using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Carreras
{
    public partial class Principal : Form
    {
        private Controladores.Carrera controller;
        private DataTable carreras;

        public Principal(DataTable carreras)
        {
            InitializeComponent();
            this.controller = new Controladores.Carrera();
            this.carreras = carreras;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataCarreras.Columns.Clear();
            this.filterCarrera();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataCarreras.DataSource = this.carreras;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataCarreras.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar la(s) carrera(s) seleccionada(s)?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataCarreras.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.filterCarrera();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataCarreras.SelectedRows.Count == 0)
            {
                return;
            }

            string idCarrera = this.dataCarreras.SelectedRows[0].Cells[0].Value.ToString();

            this.controller.actualizar(idCarrera);

            this.filterCarrera();
        }

        private void filterCarrera()
        {
            string nombre = this.txtNombre.Text;

            this.dataCarreras.DataSource = this.controller.filterCarreras(nombre);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.filterCarrera();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
        }
    }
}
