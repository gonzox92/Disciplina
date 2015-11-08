using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Faltas_Estudiantes
{
    public partial class Principal : Form
    {
        private Dictionary<string, string> carreras;
        private Controladores.Curso cursos;
        private Controladores.Estudiante estudiantes;
        private Controladores.FaltasEstudiantes faltas;

        public Principal(Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.carreras = carreras;
            this.cursos = new Controladores.Curso();
            this.estudiantes = new Controladores.Estudiante();
            this.faltas = new Controladores.FaltasEstudiantes();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.DisplayMember = "Value";
            this.txtCarrera.ValueMember = "Key";
        }

        private void loadCursos()
        {
            this.txtCurso.DataSource = null;
            this.txtCurso.Items.Clear();

            if (this.txtPeriodo.Text == "" || this.txtCarrera.Text == "")
            {
                this.labelResultados.Visible = true;
                return;
            }

            Dictionary<string, string> cursos = this.cursos.getCursos(this.txtYear.Value.ToString(),
                this.txtPeriodo.Text, ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key);

            if (cursos.Count == 0)
            {
                this.labelResultados.Visible = true;
                return;
            }

            this.txtCurso.DataSource = new BindingSource(cursos, null);
            this.txtCurso.DisplayMember = "Value";
            this.txtCurso.ValueMember = "Key";
            this.labelResultados.Visible = false;
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            this.loadCursos();
        }

        private void txtCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadCursos();
        }

        private void txtPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadCursos();
        }

        private void txtCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtCurso.Text == "" || this.txtCarrera.Text == "" || this.txtPeriodo.Text == "")
            {
                this.tableEstudiantes.DataSource = null;
                this.tableEstudiantes.Rows.Clear();
                return;
            }
            DataTable estudiantes = this.faltas.getEstudiantes(((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key);
            this.tableEstudiantes.DataSource = estudiantes;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.tableEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }

            string idEstudiante = this.tableEstudiantes.SelectedRows[0].Cells[0].Value.ToString();
            string idCurso = ((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key;

            this.faltas.detalleFaltas(idEstudiante, idCurso);
        }
    }
}
