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
        private Controladores.Falta faltas;
        private Controladores.FaltasEstudiantes faltasEstudiante;
        private int totalPuntos;

        public Faltas(Dictionary<string, string> detalleEstudiante)
        {
            InitializeComponent();
            this.detalleEstudiante = detalleEstudiante;
            this.faltas = new Controladores.Falta();
            this.faltasEstudiante = new Controladores.FaltasEstudiantes();
            this.totalPuntos = 0;
        }

        private void loadFaltas()
        {
            DataTable faltas = this.faltasEstudiante.getFaltasEstudiante(
                this.detalleEstudiante["IDEstudiante"],
                this.detalleEstudiante["IDCurso"]);
            this.tableFaltas.DataSource = faltas;

            foreach(DataRow falta in faltas.Rows)
            {
                if (falta["Concepto"].ToString() == "Demerito")
                {
                    this.totalPuntos -= int.Parse(falta["Puntos"].ToString());
                }
                else
                {
                    this.totalPuntos += int.Parse(falta["Puntos"].ToString());
                }
            }

            this.labelTotal.Text = this.totalPuntos.ToString();
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

            //Cargar faltas del alumno
            this.loadFaltas();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.faltasEstudiante.registrarFalta(this.detalleEstudiante["IDEstudiante"], this.detalleEstudiante["IDCurso"]);
            this.loadFaltas();
        }
    }
}
