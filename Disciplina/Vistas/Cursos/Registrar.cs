using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Cursos
{
    public partial class Registrar : Form
    {
        private Controladores.Curso controller;
        private Dictionary<string, string> carreras;
        private Modelos.Curso curso;
        private string operacion;

        public Registrar(string operacion, Dictionary<string, string> carreras, Dictionary<string, string> curso)
        {
            InitializeComponent();
            this.controller = new Controladores.Curso();
            this.carreras = carreras;
            this.operacion = operacion;
            this.curso = curso != null ? new Modelos.Curso(curso["ID"], curso["IDCarrera"], curso["year"], curso["periodo"],
                curso["curso"], curso["paralelo"]) : null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            this.txtYear.Value = DateTime.Now.Year;
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.DisplayMember = "Value";
            this.txtCarrera.ValueMember = "Key";

            if (this.operacion == "actualizar")
            {
                //int year = int.Parse(this.curso.year);
                this.labelRegistrarCurso.Text = "Actualizar Curso";
                this.btnRegistrar.Text = "Actualizar";
                this.txtYear.Value = int.Parse(this.curso.year);

                int index = 0;
                foreach (KeyValuePair<string, string> carrera in this.carreras)
                {
                    if (carrera.Key == this.curso.IDCarrera)
                    {
                        break;
                    }
                    else
                    {
                        ++index;
                    }
                }

                this.txtCarrera.SelectedIndex = index;
                this.txtPeriodo.Text = this.curso.periodo;
                this.txtCurso.Text = this.curso.curso;
                this.txtParalelo.Text = this.curso.paralelo;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtCarrera.Text == "")
            {
                MessageBox.Show("Seleccione la carrera");
                return;
            }
            if (this.txtPeriodo.Text == "")
            {
                MessageBox.Show("Seleccione el periodo");
                return;
            }
            if (this.txtCurso.Text == "")
            {
                MessageBox.Show("Seleccione el curso");
                return;
            }

            if (this.operacion == "actualizar")
            {
                this.curso.IDCarrera = ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key;
                this.curso.year = this.txtYear.Text;
                this.curso.periodo = this.txtPeriodo.Text;
                this.curso.curso = this.txtCurso.Text;
                this.curso.paralelo = this.txtParalelo.Text;

                string tabla = "cursos";

                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("IDCarrera", new string[] { "=", this.curso.IDCarrera, "," });
                datos.Add("year", new string[] { "=", string.Format("'{0}'", this.curso.year), "," });
                datos.Add("periodo", new string[] { "=", string.Format("'{0}'", this.curso.periodo), "," });
                datos.Add("curso", new string[] { "=", string.Format("'{0}'", this.curso.curso), "," });
                datos.Add("paralelo", new string[] { "=", string.Format("'{0}'", this.curso.paralelo), "" });

                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", this.curso.ID, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    this.Close();
                }
                return;
            }

            Modelos.IModelo curso = new Modelos.Curso(
                ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key, 
                this.txtYear.Value.ToString(), 
                this.txtPeriodo.Text, 
                this.txtCurso.Text, 
                this.txtParalelo.Text);

            if (controller.registrar(curso)) 
            {
                this.Close();
            }
        }
    }
}
