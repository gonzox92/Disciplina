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
    public partial class RegistrarCuenta : Form
    {
        private Controladores.Encargado controller;
        private Dictionary<string, String> datos;

        public RegistrarCuenta(Dictionary<string, String> datos)
        {
            InitializeComponent();
            this.controller = new Controladores.Encargado();
            this.datos = datos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtPrivilegio.Text == "")
            {
                MessageBox.Show("Ingrese el Privilegio");
                return;
            }
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }
            if (this.txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese el nombre de usuario");
                return;
            }
            if (this.txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese el password del usuario");
                return;
            }

            Modelos.IModelo oficial = new Modelos.Usuario(
                this.txtNombre.Text,
                this.txtApellidoPaterno.Text,
                this.txtApellidoMaterno.Text,
                this.txtUsuario.Text,
                this.txtPassword.Text,
                this.txtPrivilegio.Text);

            if (controller.registrar(oficial))
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
