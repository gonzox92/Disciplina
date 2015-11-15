using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Oficial
{
    public partial class Principal : Form
    {
        private Controladores.Falta falta;
        private Controladores.Reportes reportes;
        private Controladores.FaltasEstudiantes faltasEstudiante;

        public Principal()
        {
            InitializeComponent();
            this.falta = new Controladores.Falta();
            this.reportes = new Controladores.Reportes();
            this.faltasEstudiante = new Controladores.FaltasEstudiantes();
        }

        private void btnAdminFaltas_Click(object sender, EventArgs e)
        {
            this.falta.faltas();
        }

        private void btnAdminConsultas_Click(object sender, EventArgs e)
        {
            this.reportes.opciones();
        }

        private void btnEstudiantesFaltas_Click(object sender, EventArgs e)
        {
            this.faltasEstudiante.principal();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.falta.actualizarCuenta();
        }
    }
}
