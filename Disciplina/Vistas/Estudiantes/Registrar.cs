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
        private Modelos.Estudiante estudiante;
        private string operacion;

        public Registrar(Dictionary<string, string> carreras, string operacion, Dictionary<string, string> estudiante)
        {
            InitializeComponent();
            this.controller = new Controladores.Estudiante();
            this.usuario = new Controladores.Encargado();
            this.carreras = carreras;
            this.operacion = operacion;
            this.estudiante = estudiante != null ? new Modelos.Estudiante(estudiante["ID"], estudiante["ci"], estudiante["nombre"],
                estudiante["apellidoPaterno"], estudiante["apellidoMaterno"], estudiante["codigo"], estudiante["IDCarrera"],
                estudiante["telefono"], estudiante["direccion"]) : null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.operacion == "actualizar")
            {
                this.estudiante.carrera = ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key;
                this.estudiante.codigo = this.txtCodigo.Text;
                this.estudiante.ci = this.txtCI.Text;
                this.estudiante.nombre = this.txtNombre.Text;
                this.estudiante.apellidoPaterno = this.txtApellidoPaterno.Text;
                this.estudiante.apellidoMaterno = this.txtApellidoMaterno.Text;
                this.estudiante.telefono = this.txtTelefono.Text;
                this.estudiante.direccion = this.txtDireccion.Text;

                string tabla = "estudiantes";

                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("carrera", new string[] { "=", this.estudiante.carrera, "," });
                datos.Add("codigo", new string[] { "=", string.Format("'{0}'", this.estudiante.codigo), "," });
                datos.Add("ci", new string[] { "=", string.Format("'{0}'", this.estudiante.ci), "," });
                datos.Add("nombre", new string[] { "=", string.Format("'{0}'", this.estudiante.nombre), "," });
                datos.Add("apellidoPaterno", new string[] { "=", string.Format("'{0}'", this.estudiante.apellidoPaterno), "," });
                datos.Add("apellidoMaterno", new string[] { "=", string.Format("'{0}'", this.estudiante.apellidoMaterno), "," });
                datos.Add("telefono", new string[] { "=", string.Format("'{0}'", this.estudiante.telefono), "," });
                datos.Add("direccion", new string[] { "=", string.Format("'{0}'", this.estudiante.direccion), "" });

                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", this.estudiante.id, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    this.Close();
                }
                return;
            }

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

            if (this.operacion == "actualizar")
            {
                this.labelRegistrarEstudiante.Text = "Actualizar Estudiante";
                this.btnRegistrar.Text = "Actualizar";

                int index = 0;
                foreach (KeyValuePair<string, string> carrera in this.carreras)
                {
                    if (carrera.Key == this.estudiante.carrera)
                    {
                        break;
                    }
                    else
                    {
                        ++index;
                    }
                }

                this.txtCarrera.SelectedIndex = index;
                this.txtCodigo.Text = this.estudiante.codigo;
                this.txtCI.Text = this.estudiante.ci;
                this.txtNombre.Text = this.estudiante.nombre;
                this.txtApellidoPaterno.Text = this.estudiante.apellidoPaterno;
                this.txtApellidoMaterno.Text = this.estudiante.apellidoMaterno;
                this.txtTelefono.Text = this.estudiante.telefono;
                this.txtDireccion.Text = this.estudiante.direccion;
            }
        }
    }
}
