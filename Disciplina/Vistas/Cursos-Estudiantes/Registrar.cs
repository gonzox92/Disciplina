using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Cursos_Estudiantes
{
    public partial class Registrar : Form
    {
        private DataTable estudiantes;

        public Registrar(DataTable estudiantes)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            this.dataEstudiantes.DataSource = this.estudiantes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
