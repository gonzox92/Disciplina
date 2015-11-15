using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Oficiales
{
    public partial class Registrar : Form
    {
        private Controladores.EstudianteOficial controller;
        private Controladores.Encargado usuario;
        private Dictionary<string, string> carreras;
        private Modelos.EstudianteOficial oficial;
        private string operacion;

        public Registrar(Dictionary<string, string> carreras, string operacion, Dictionary<string, string> oficial)
        {
            InitializeComponent();
            this.carreras = carreras;
            this.operacion = operacion;
            this.oficial = oficial != null ?
                new Modelos.EstudianteOficial(oficial["ID"], oficial["grado"], oficial["nombre"], oficial["apellidoPaterno"], oficial["apellidoMaterno"],
                    oficial["codigo"], oficial["direccion"], oficial["telefono"], oficial["IDCarrera"], oficial["ci"]) : null;

            this.controller = new Controladores.EstudianteOficial();
            this.usuario = new Controladores.Encargado();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.operacion == "actualizar")
            {
                this.oficial.carrera = ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key;
                this.oficial.codigo = this.txtCodigo.Text;
                this.oficial.ci = this.txtCI.Text;
                this.oficial.grado = this.txtGrado.Text;
                this.oficial.nombre = this.txtNombre.Text;
                this.oficial.apellidoPaterno = this.txtApellidoPaterno.Text;
                this.oficial.apellidoMaterno = this.txtApellidoMaterno.Text;
                this.oficial.telefono = this.txtTelefono.Text;
                this.oficial.direccion = this.txtDireccion.Text;

                string tabla = "oficiales";

                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("carrera", new string[] { "=", this.oficial.carrera, "," });
                datos.Add("codigo", new string[] { "=", string.Format("'{0}'", this.oficial.codigo), "," });
                datos.Add("grado", new string[] { "=", string.Format("'{0}'", this.oficial.grado), "," });
                datos.Add("ci", new string[] { "=", string.Format("'{0}'", this.oficial.ci), "," });
                datos.Add("nombre", new string[] { "=", string.Format("'{0}'", this.oficial.nombre), "," });
                datos.Add("apellidoPaterno", new string[] { "=", string.Format("'{0}'", this.oficial.apellidoPaterno), "," });
                datos.Add("apellidoMaterno", new string[] { "=", string.Format("'{0}'", this.oficial.apellidoMaterno), "," });
                datos.Add("telefono", new string[] { "=", string.Format("'{0}'", this.oficial.telefono), "," });
                datos.Add("direccion", new string[] { "=", string.Format("'{0}'", this.oficial.direccion), "" });

                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", this.oficial.ID, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    this.Close();
                }
                return;
            }            
            
            Modelos.IModelo estudianteOficial = new Modelos.EstudianteOficial(this.txtGrado.Text, this.txtNombre.Text, this.txtApellidoPaterno.Text,
                this.txtApellidoMaterno.Text, this.txtCodigo.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                ((KeyValuePair<string, string>)this.txtCarrera.SelectedItem).Key, this.txtCI.Text);

            Modelos.IModelo cuenta = new Modelos.Usuario(
                this.txtNombre.Text, this.txtApellidoPaterno.Text, this.txtApellidoMaterno.Text, this.txtCodigo.Text, this.txtCodigo.Text, "Oficial");

            if (controller.registrar(estudianteOficial) && usuario.registrar(cuenta))
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
                this.labelRegistrarEstudiante.Text = "Actualizar Oficial";
                this.btnRegistrar.Text = "Actualizar";

                int index = 0;
                foreach (KeyValuePair<string, string> carrera in this.carreras)
                {
                    if (carrera.Key == this.oficial.carrera)
                    {
                        break;
                    }
                    else
                    {
                        ++index;
                    }
                }

                this.txtCarrera.SelectedIndex = index;
                this.txtGrado.Text = this.oficial.grado;
                this.txtCodigo.Text = this.oficial.codigo;
                this.txtCI.Text = this.oficial.ci;
                this.txtNombre.Text = this.oficial.nombre;
                this.txtApellidoPaterno.Text = this.oficial.apellidoPaterno;
                this.txtApellidoMaterno.Text = this.oficial.apellidoMaterno;
                this.txtTelefono.Text = this.oficial.telefono;
                this.txtDireccion.Text = this.oficial.direccion;
            }
        }
    }
}
