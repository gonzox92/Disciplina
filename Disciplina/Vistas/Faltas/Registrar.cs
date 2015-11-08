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
    public partial class Registrar : Form
    {
        private Controladores.Falta controller;

        public Registrar()
        {
            InitializeComponent();
            this.controller = new Controladores.Falta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Modelos.IModelo falta = new Modelos.Falta(this.txtGrado.Text, this.txtFalta.Text, this.txtPuntos.Text);

            if (controller.registrar(falta))
            {
                this.Close();
            }
        }
    }
}
