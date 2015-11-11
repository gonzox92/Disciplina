using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Configuracion.Conexion.connect())
            {
                MessageBox.Show("Verifique la conexion a la base de datos.");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Vistas.Encargado.Principal());
            Application.Run(new Login());
            Configuracion.Conexion.close();
        }
    }
}
