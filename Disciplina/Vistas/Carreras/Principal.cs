using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Carreras
{
    public partial class Principal : Form
    {
        private Controladores.Carrera controller;
        private DataTable carreras;

        public Principal(DataTable carreras)
        {
            InitializeComponent();
            this.controller = new Controladores.Carrera();
            this.carreras = carreras;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataCarreras.Columns.Clear();
            this.dataCarreras.DataSource = this.controller.getCarreras();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.dataCarreras.DataSource = this.carreras;
        }
    }
}
