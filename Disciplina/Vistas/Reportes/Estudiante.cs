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
    public partial class Estudiante : Form
    {
        private Dictionary<string, string> datos;
        private Dictionary<string, string> cursos;
        private Controladores.FaltasEstudiantes faltasEstudiante;
        private int totalPuntos;

        public Estudiante(Dictionary<string, string> datos, Dictionary<string, string> cursos)
        {
            InitializeComponent();
            this.datos = datos;
            this.cursos = cursos;
            this.faltasEstudiante = new Controladores.FaltasEstudiantes();
            this.totalPuntos = 0;
        }

        private void Estudiante_Load(object sender, EventArgs e)
        {
            this.labelCodigo.Text = datos["Codigo"];
            this.labelNombre.Text = datos["Nombre"];

            this.txtCursos.DataSource = new BindingSource(this.cursos, null);
            this.txtCursos.ValueMember = "Key";
            this.txtCursos.DisplayMember = "Value";
        }

        private void loadFaltas()
        {
            if (this.txtCursos.Text == "")
            {
                return;
            }

            DataTable faltas = this.faltasEstudiante.getFaltasEstudiante(
                this.datos["ID"], ((KeyValuePair<string, string>)this.txtCursos.SelectedItem).Key);
            this.tableFaltas.DataSource = faltas;

            this.totalPuntos = 0;

            foreach (DataRow falta in faltas.Rows)
            {
                if (falta["Concepto"].ToString() == "Demerito")
                {
                    this.totalPuntos -= int.Parse(falta["Puntos"].ToString());
                }
                else
                {
                    this.totalPuntos += int.Parse(falta["Puntos"].ToString());
                }
            }

            this.labelTotal.Text = this.totalPuntos.ToString();
        }

        private void txtCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadFaltas();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.faltasEstudiante.actualizarCuenta();
        }
    }
}
