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

        public Principal(DataTable oficiales)
        {
            InitializeComponent();
            this.oficiales = oficiales;
            this.controller = new Controladores.EstudianteOficial();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataOficiales.DataSource = this.oficiales;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataOficiales.Columns.Clear();
            this.dataOficiales.DataSource = this.controller.getOficiales();
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

                this.dataOficiales.DataSource = this.controller.getOficiales();
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

            this.dataOficiales.DataSource = this.controller.getOficiales();
        }
    }
}
