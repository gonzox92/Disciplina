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
        private Controladores.Encargado controlador;
        public Principal()
        {
            InitializeComponent();
            this.controlador = new Controladores.Encargado();
        }

        private void btnAdminCuentas_Click(object sender, EventArgs e)
        {
            this.controlador.cuentas();
        }
    }
}
