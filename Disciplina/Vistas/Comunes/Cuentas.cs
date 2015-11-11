using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Comunes
{
    public partial class Cuentas : Form
    {
        private Controladores.Encargado controller;
        private DataTable cuentas;

        public Cuentas(DataTable cuentas)
        {
            InitializeComponent(); 
            this.controller = new Controladores.Encargado();
            this.cuentas = cuentas;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataCuentas.Columns.Clear();
            this.dataCuentas.DataSource = this.controller.getCuentas();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            this.dataCuentas.DataSource = this.cuentas;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataCuentas.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar los cursos seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataCuentas.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.dataCuentas.DataSource = this.controller.getCuentas();
            }
        }
    }
}
