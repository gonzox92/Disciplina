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

        public Registrar(Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.controller = new Controladores.Curso();
            this.carreras = carreras;
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
