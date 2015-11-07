using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Disciplina.Modelos.Consultas
{
    static class Server
    {
        private static string getTablas(String[] tablas)
        {
            string listaTablas = "";
            foreach (String tabla in tablas)
            {
                listaTablas += tabla + ",";
            }
            listaTablas = listaTablas.Remove(listaTablas.Length - 1);

            return listaTablas;
        }

        private static string getColumnas(Dictionary<string, String> datos)
        {
            string columnas = "";

            foreach (KeyValuePair<string, String> item in datos)
            {
                columnas += item.Key + ",";
            }
            columnas = columnas.Remove(columnas.Length - 1);

            return columnas;
        }

        private static string getValores(Dictionary<string, String> datos)
        {
            string valores = "";

            foreach (KeyValuePair<string, String> item in datos)
            {
                valores += "'" + item.Value + "',";
            }
            valores = valores.Remove(valores.Length - 1);

            return valores;
        }

        private static string getValoresComparaciones(Dictionary<string, String[]> datos)
        {
            string valores = "";

            foreach (KeyValuePair<string, String[]> item in datos)
            {
                valores += "" + item.Key + item.Value[0] + " " + item.Value[1] + " " + item.Value[2] + " ";
            }

            return valores;
        }

        public static bool insert(string tabla, Dictionary<string, String> datos)
        {
            string columnas = getColumnas(datos);
            string valores = getValores(datos);

            SqlCommand commmand = new SqlCommand(string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tabla, columnas, valores), Configuracion.Conexion.conn);

            try
            {
                commmand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tabla, columnas, valores));
                return false;
            }
        }

        public static DataTable select(String[] listaColumnas, String[] listaTablas, Dictionary<string, String[]> datos)
        {
            string columnas = getTablas(listaColumnas);
            string tablas = getTablas(listaTablas);
            string valores = getValoresComparaciones(datos);

            SqlCommand commmand = new SqlCommand(string.Format("SELECT {0} FROM {1} WHERE {2}", columnas, tablas, valores), Configuracion.Conexion.conn);

            try
            {
                DataTable tabla = new DataTable();
                tabla.Load(commmand.ExecuteReader());
                return tabla;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public static bool delete(string tabla, Dictionary<string, String[]> datos)
        {
            string valores = getValoresComparaciones(datos);

            SqlCommand commmand = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}", tabla, valores, valores), Configuracion.Conexion.conn);

            try
            {
                commmand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Error al borrar");
                return false;
            }
        }
    }
}
