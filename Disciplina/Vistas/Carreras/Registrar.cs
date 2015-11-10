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
        private string operacion;
        private Modelos.Carrera carrera;

        public Registrar(string operacion, Dictionary<string, string> carrera)
        {
            InitializeComponent();
            this.controller = new Controladores.Carrera();
            this.operacion = operacion;
            this.carrera = carrera != null ? new Modelos.Carrera(carrera["ID"], carrera["nombre"]) : null;
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

            if (this.operacion == "actualizar")
            {
                this.carrera.nombre = this.txtNombre.Text;

                string tabla = "carreras";

                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("nombre", new string[] { "=", string.Format("'{0}'", this.carrera.nombre), "" });

                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", this.carrera.id, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    this.Close();
                }
                return;
            }

            Modelos.IModelo carrera = new Modelos.Carrera(this.txtNombre.Text);

            if (controller.registrar(carrera))
            {
                this.Close();
            }
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            if (this.operacion == "actualizar")
            {
                this.labelRegistrarCarrera.Text = "Actualizar Carrera";
                this.btnRegistrar.Text = "Actualizar";
                this.txtNombre.Text = this.carrera.nombre;
            }
        }
    }
}
