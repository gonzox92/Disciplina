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
        private string operacion;
        private Modelos.Falta falta;

        public Registrar(string operacion, Dictionary<string, string> falta)
        {
            InitializeComponent();
            this.controller = new Controladores.Falta();
            this.operacion = operacion;
            this.falta = falta != null ? 
                new Modelos.Falta(falta["ID"], falta["grado"], falta["nombre"], falta["puntos"]) : null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.operacion == "actualizar")
            {
                this.falta.grado = this.txtGrado.Text;
                this.falta.nombre = this.txtFalta.Text;
                this.falta.puntos = this.txtPuntos.Text;

                string tabla = "faltasRac";

                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("grado", new string[] { "=", string.Format("'{0}'", this.falta.grado), "," });
                datos.Add("nombre", new string[] { "=", string.Format("'{0}'", this.falta.nombre), "," });
                datos.Add("puntos", new string[] { "=", string.Format("'{0}'", this.falta.puntos), "" });

                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", this.falta.id, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    this.Close();
                }
                return;
            }

            Modelos.IModelo falta = new Modelos.Falta(this.txtGrado.Text, this.txtFalta.Text, this.txtPuntos.Text);

            if (controller.registrar(falta))
            {
                this.Close();
            }
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            if (this.operacion == "actualizar")
            {
                this.labelRegistrarFalta.Text = "Actualizar Falta";
                this.btnRegistrar.Text = "Actualizar";
                this.txtGrado.Text = this.falta.grado;
                this.txtFalta.Text = this.falta.nombre;
                this.txtPuntos.Text = this.falta.puntos;
            }
        }
    }
}
