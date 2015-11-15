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
    public partial class CambiarPassword : Form
    {
        private Controladores.Encargado controller;

        public CambiarPassword()
        {
            InitializeComponent();
            this.controller = new Controladores.Encargado();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text == "" || this.txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Contraseña no permitida");
                return;
            }

            string usuario = Configuracion.Cuenta.usuario;
            string tabla = "usuarios";
            Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
            datos.Add("password", new string[] { "=", string.Format("'{0}'", Modelos.Utilidades.encriptarPassword(this.txtPassword.Text)), "" });
            Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
            llaves.Add("usuario", new string[] { "=", string.Format("'{0}'", usuario), "" });

            if (controller.actualizar(tabla, datos, llaves))
            {
                MessageBox.Show("Contraseña cambiada");
                this.Close();
            }
        }
    }
}
