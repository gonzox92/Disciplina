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
        private Controladores.Reportes reportes;
        private Controladores.Estudiante estudiante;

        public Login()
        {
            InitializeComponent();
            this.controller = new Controladores.Controller();
            this.reportes = new Controladores.Reportes();
            this.estudiante = new Controladores.Estudiante();
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
                this.Visible = false;
                if (acceso == "Encargado de disciplina")
                {
                    Form Encargado = new Vistas.Encargado.Principal();
                    this.controller.resolver(Encargado);
                }
                if (acceso == "Oficial")
                {
                    Form Oficial = new Vistas.Oficial.Principal();
                    this.controller.resolver(Oficial);
                }
                if (acceso == "Secretaria")
                {
                    Form Secretaria = new Vistas.Secretaria.Principal();
                    this.controller.resolver(Secretaria);
                }
                if (acceso == "Jefe de Personal")
                {
                    Form Jefe = new Vistas.Jefe_Personal.Principal();
                    this.controller.resolver(Jefe);
                }
                if (acceso == "estudiante")
                {
                    Dictionary<string, string> estudiante = this.estudiante.getEstudianteByCodigo(this.txtUsuario.Text);
                    Dictionary<string, string> datos = new Dictionary<string, string>();
                    datos.Add("ID", estudiante["ID"]);
                    datos.Add("Codigo", estudiante["codigo"]);
                    datos.Add("Nombre", string.Format("{0} {1} {2}",
                        estudiante["nombre"], estudiante["apellidoPaterno"], estudiante["apellidoMaterno"]));

                    this.reportes.faltasEstudiante(datos);
                }
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Acceso no autorizado");
            }
        }
    }
}
