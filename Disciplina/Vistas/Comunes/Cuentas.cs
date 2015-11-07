using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Comunes
{
    public partial class Cuentas : Form
    {
        private Controladores.Encargado controller;
        private DataTable cuentas;

        public Cuentas(DataTable cuentas)
        {
            InitializeComponent(); 
            this.controller = new Controladores.Encargado();
            this.cuentas = cuentas;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataCuentas.Columns.Clear();
            this.dataCuentas.DataSource = this.controller.getCuentas();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            this.dataCuentas.DataSource = this.cuentas;
        }
    }
}
