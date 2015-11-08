using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Faltas_Estudiantes
{
    public partial class Faltas : Form
    {
        private Dictionary<string, string> detalleEstudiante;

        public Faltas(Dictionary<string, string> detalleEstudiante)
        {
            InitializeComponent();
            this.detalleEstudiante = detalleEstudiante;
        }

        private void Faltas_Load(object sender, EventArgs e)
        {
            //Cargar detalles detalles del estudiante
            this.labelCodigo.Text = this.detalleEstudiante["codigo"];
            this.labelYear.Text = this.detalleEstudiante["year"];
            this.labelPeriodo.Text = this.detalleEstudiante["periodo"];
            this.labelCurso.Text = this.detalleEstudiante["curso"];
            this.labelCarrera.Text = this.detalleEstudiante["carrera"];
            this.labelNombre.Text = this.detalleEstudiante["nombre"];
        }
    }
}
