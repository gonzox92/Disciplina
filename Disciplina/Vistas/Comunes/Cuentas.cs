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
    public partial class Cuentas : Form
    {
        private Controladores.Encargado controller;
        private DataTable cuentas;

        public Cuentas(DataTable cuentas)
        {
            InitializeComponent(); 
            this.controller = new Controladores.Encargado();
            this.cuentas = cuentas;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.controller.registrar();
            this.dataCuentas.Columns.Clear();
            this.filterCuentas();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            this.dataCuentas.DataSource = this.cuentas;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataCuentas.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Desea eliminar los cursos seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataCuentas.SelectedRows)
                {
                    this.controller.eliminar(row.Cells[0].Value.ToString());
                }

                this.filterCuentas();
            }
        }

        private void filterCuentas()
        {
            string nombre = this.txtNombre.Text;
            string usuario = this.txtUsuario.Text;
            string privilegio = this.txtPrivilegio.Text;

            this.dataCuentas.DataSource = this.controller.filterCuentas(nombre, usuario, privilegio);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtUsuario.Text = "";
            this.txtPrivilegio.Text = "";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.filterCuentas();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            this.filterCuentas();
        }

        private void txtPrivilegio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterCuentas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dataCuentas.SelectedRows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("Resetear contraseña?", "Reset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string idCuenta = this.dataCuentas.SelectedRows[0].Cells[0].Value.ToString();
                string user = this.dataCuentas.SelectedRows[0].Cells[4].Value.ToString();

                string tabla = "usuarios";
                Dictionary<string, string[]> datos = new Dictionary<string, string[]>();
                datos.Add("password", new string[] { "=", string.Format("'{0}'", Modelos.Utilidades.encriptarPassword(user)), "" });
                Dictionary<string, string[]> llaves = new Dictionary<string, string[]>();
                llaves.Add("ID", new string[] { "=", idCuenta, "" });

                if (controller.actualizar(tabla, datos, llaves))
                {
                    MessageBox.Show("Contraseña reseteada");
                }
            }
        }
    }
}
