using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Faltas
{
    public partial class Principal : Form
    {
        private Controladores.Falta controller;
        private DataTable faltas;

        public Principal(DataTable faltas)
        {
            InitializeComponent();
            this.controller = new Controladores.Falta();
            this.faltas = faltas;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataFaltas.DataSource = this.faltas;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataFaltas.Columns.Clear();
            this.dataFaltas.DataSource = this.controller.getFaltas();
        }
    }
}
