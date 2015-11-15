using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Disciplina.Controladores
{
    class Controller
    {
        public void resolver(Form vista)
        {
            vista.ShowDialog();
        }

        public bool actualizar(string tabla, Dictionary<string, String[]> datos, Dictionary<string, String[]> llaves)
        {
            return Modelos.Consultas.Server.update(tabla, datos, llaves);
        }

        public void actualizarCuenta()
        {
            Form updateCuenta = new Vistas.Comunes.CambiarPassword();
            this.resolver(updateCuenta);
        }
    }
}
