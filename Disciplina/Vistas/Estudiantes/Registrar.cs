using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Estudiantes
{
    public partial class Registrar : Form
    {
        private Controladores.Estudiante controller;
        private Controladores.Encargado usuario;
        private Dictionary<string, string> carreras;

        public Registrar(Dictionary<string, string> carreras)
        {
            InitializeComponent();
            this.controller = new Controladores.Estudiante();
            this.usuario = new Controladores.Encargado();
            this.carreras = carreras;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Modelos.IModelo estudiante = new Modelos.Estudiante(
                this.txtCI.Text,
                this.txtNombre.Text,
                this.txtApellidoPaterno.Text,
                this.txtApellidoMaterno.Text,
                this.txtCodigo.Text,
                ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key,
                this.txtTelefono.Text,
                this.txtDireccion.Text);

            Modelos.IModelo cuenta = new Modelos.Usuario("", "", "", this.txtCodigo.Text, this.txtCodigo.Text, "estudiante");

            if (controller.registrar(estudiante) && usuario.registrar(cuenta))
            {
                this.Close();
            }
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            this.txtCarrera.DataSource = new BindingSource(this.carreras, null);
            this.txtCarrera.ValueMember = "Key";
            this.txtCarrera.DisplayMember = "Value";
        }
    }
}
