using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Cursos_Estudiantes
{
    public partial class Curso : Form
    {
        private Dictionary<string, string> carreras;
        private Controladores.Curso cursos;
        private Controladores.Estudiante estudiantes;
        private Controladores.CursoEstudiantes cursoEstudiantes;

        public Curso(Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.carreras = carreras;
            this.cursos = new Controladores.Curso();
            this.estudiantes = new Controladores.Estudiante();
            this.cursoEstudiantes = new Controladores.CursoEstudiantes();
        }

        private void Curso_Load(object sender, EventArgs e)
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

        private void txtPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCursos();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            loadCursos();
        }

        private void txtCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCursos();
        }

        private void txtCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtCurso.Text == "" || this.txtCarrera.Text == "" || this.txtPeriodo.Text == "")
            {
                this.tableEstudiantes.DataSource = null;
                this.tableEstudiantes.Rows.Clear();
                return;
            }
            DataTable estudiantes = this.cursoEstudiantes.getEstudiantes(((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key);
            this.tableEstudiantes.DataSource = estudiantes;
        }

        private bool existeEstudiante(string codigo)
        {
            foreach (DataGridViewRow row in this.tableEstudiantes.Rows)
            {
                if (row.Cells[1].Value.ToString() == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtCurso.Text == "")
            {
                MessageBox.Show("Seleccione un curso");
                return;
            }

            var estudiantes = this.estudiantes.buscar();
            foreach (DataGridViewRow estudiante in estudiantes)
            {
                DataGridViewRow row = (DataGridViewRow)estudiante.Clone();
                for (int index = 0; index < estudiante.Cells.Count; index++)
                {
                    row.Cells[index].Value = estudiante.Cells[index].Value;
                }
                if (existeEstudiante(row.Cells[1].Value.ToString()))
                {
                    return;
                }

                Modelos.IModelo cursoEstudiante = new Modelos.CursoEstudiante(
                    ((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key,
                    row.Cells[0].Value.ToString());
                if (!cursoEstudiantes.registrar(cursoEstudiante))
                {
                    return;
                }

                DataTable estudiantesSource = this.cursoEstudiantes.getEstudiantes(((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key);
                this.tableEstudiantes.DataSource = estudiantesSource;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.tableEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar el registro del/los estudiante(s)", "Eliminar",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.tableEstudiantes.SelectedRows)
                {
                    this.cursoEstudiantes.delete(row.Cells[0].Value.ToString(), ((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key);
                }

                DataTable estudiantesSource = this.cursoEstudiantes.getEstudiantes(((KeyValuePair<string, string>)this.txtCurso.SelectedItem).Key);
                this.tableEstudiantes.DataSource = estudiantesSource;
            }
        }
    }
}
