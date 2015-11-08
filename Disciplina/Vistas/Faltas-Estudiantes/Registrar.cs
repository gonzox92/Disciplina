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
    public partial class Registrar : Form
    {
        private Controladores.Falta faltas;
        private Controladores.FaltasEstudiantes faltaEstudiante;
        private string idEstudiante;
        private string idCurso;
        private string idFalta;

        public Registrar(string idEstudiante, string idCurso)
        {
            InitializeComponent();
            this.faltas = new Controladores.Falta();
            this.faltaEstudiante = new Controladores.FaltasEstudiantes();
            this.idEstudiante = idEstudiante;
            this.idCurso = idCurso;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            this.txtConcepto.SelectedIndex = 0;
        }

        private void txtConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtConcepto.Text == "Merito")
            {
                this.btnSeleccionarFalta.Enabled = false;
                this.txtDetalle.Text = "";
                this.txtDetalle.ReadOnly = false;
                this.txtPuntos.Text = "";
                this.txtPuntos.ReadOnly = false;
                this.txtDetalle.Focus();
                return;
            }

            this.btnSeleccionarFalta.Enabled = true;
            this.txtDetalle.ReadOnly = true;
            this.txtPuntos.ReadOnly = true;
        }

        private void btnSeleccionarFalta_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> falta = this.faltas.buscar();
            this.txtDetalle.Text = falta["Falta"];
            this.txtPuntos.Value = int.Parse(falta["Puntos"]);
            this.idFalta = falta["IDFalta"];
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtDetalle.Text == "")
            {
                MessageBox.Show("Ingrese el detalle de la falta");
                return;
            }

            if (this.txtConcepto.SelectedIndex == 1)
            {
                this.idFalta = "";
            }

            Modelos.IModelo nuevaFalta = new Modelos.FaltaEstudiante(this.idCurso,
                this.idEstudiante, this.idFalta, this.txtFecha.Value.Date.ToString("yyyy-MM-dd"),
                this.txtConcepto.Text, this.txtDetalle.Text, this.txtPuntos.Value.ToString());

            if (this.faltaEstudiante.registrar(nuevaFalta))
            {
                this.Close();
            }
        }
    }
}
