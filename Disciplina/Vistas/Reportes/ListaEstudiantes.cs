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

        public ListaEstudiantes(DataTable estudiantes)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.controller = new Controladores.Estudiante();
            this.reportes = new Controladores.Reportes();
        }

        private void ListaEstudiantes_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
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
    }
}
