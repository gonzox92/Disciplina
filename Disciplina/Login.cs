using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina
{
    public partial class Login : Form
    {
        private Controladores.Controller controller;

        public Login()
        {
            InitializeComponent();
            this.controller = new Controladores.Controller();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese el nombre de usuario");
                return;
            }
            if (this.txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese el password de usuario");
                return;
            }

            Modelos.Login login = new Modelos.Login();

            string acceso = login.ingresar(this.txtUsuario.Text, this.txtPassword.Text);

            if (acceso != "denegado")
            {
                if (acceso == "encargado")
                {
                    this.Visible = false;

                    Form Encargado = new Vistas.Encargado.Principal();
                    this.controller.resolver(Encargado);

                    this.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Acceso no autorizado");
            }
        }
    }
}
