using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Faltas
{
    public partial class Principal : Form
    {
        private Controladores.Falta controller;
        private DataTable faltas;

        public Principal(DataTable faltas)
        {
            InitializeComponent();
            this.controller = new Controladores.Falta();
            this.faltas = faltas;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataFaltas.DataSource = this.faltas;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataFaltas.Columns.Clear();
            this.filtrarFaltas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataFaltas.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar la(s) falta(s) seleccionada(s)?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataFaltas.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }
                this.filtrarFaltas();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataFaltas.SelectedRows.Count == 0)
            {
                return;
            }

            string idFalta = this.dataFaltas.SelectedRows[0].Cells[0].Value.ToString();

            this.controller.actualizar(idFalta);
            this.filtrarFaltas();
        }

        private void filtrarFaltas()
        {
            string grado = this.txtGrado.Text;
            string falta = this.txtFalta.Text;
            string puntos = this.txtPuntos.Value.ToString();

            this.dataFaltas.DataSource = this.controller.filterFaltas(grado, falta, puntos);
        }

        private void txtGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrarFaltas();
        }

        private void txtFalta_TextChanged(object sender, EventArgs e)
        {
            this.filtrarFaltas();
        }

        private void txtPuntos_ValueChanged(object sender, EventArgs e)
        {
            this.filtrarFaltas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtGrado.Text = "";
            this.txtFalta.Text = "";
            this.txtPuntos.Value = 0;
        }
    }
}
