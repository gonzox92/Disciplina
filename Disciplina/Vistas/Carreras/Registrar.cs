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
    public partial class Registrar : Form
    {
        private Controladores.Carrera controller;

        public Registrar()
        {
            InitializeComponent();
            this.controller = new Controladores.Carrera();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }

            Modelos.IModelo carrera = new Modelos.Carrera(this.txtNombre.Text);

            if (controller.registrar(carrera))
            {
                this.Close();
            }
        }
    }
}
