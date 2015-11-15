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
    public partial class Buscar : Form
    {
        private Controladores.Falta controller;
        private DataTable faltas;
        public Dictionary<string, string> faltaSeleccionada;

        public Buscar(DataTable faltas)
        {
            InitializeComponent();
            this.controller = new Controladores.Falta();
            this.faltas = faltas;
            this.faltaSeleccionada = new Dictionary<string, string>();
            this.faltaSeleccionada.Add("IDFalta", "");
            this.faltaSeleccionada.Add("Falta", "");
            this.faltaSeleccionada.Add("Puntos", "");
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            this.dataFaltas.DataSource = this.faltas;
        }

        private void seleccionarFalta()
        {
            if (this.dataFaltas.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow seleccionado = this.dataFaltas.SelectedRows[0];
            this.faltaSeleccionada["IDFalta"] = seleccionado.Cells[0].Value.ToString();
            this.faltaSeleccionada["Falta"] = seleccionado.Cells[2].Value.ToString();
            this.faltaSeleccionada["Puntos"] = seleccionado.Cells[3].Value.ToString();
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.seleccionarFalta();
        }

        private void dataFaltas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.seleccionarFalta();
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
