using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Jefe_Personal
{
    public partial class Principal : Form
    {
        private Controladores.EstudianteOficial oficial;
        public Principal()
        {
            InitializeComponent();
            this.oficial = new Controladores.EstudianteOficial();
        }

        private void btnOficiales_Click(object sender, EventArgs e)
        {
            this.oficial.oficiales();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.oficial.actualizarCuenta();
        }
    }
}
