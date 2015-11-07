using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Disciplina.Configuracion
{
    static class Conexion
    {
        /// <summary>
        /// Instancia del client Sql Server
        /// </summary>
        public static SqlConnection conn = new SqlConnection();
        
       /// <summary>
       /// Parametros de conexion
       /// </summary>
        static string server = @"GONZALO-PC\SQLEXPRESS";
        static string database = "disciplina";
        static string username = "";
        static string password = "";

        static string cadenaConexion = string.Format("Server={0};Database={1};User Id={2};Password={3};Trusted_Connection=True;", server, database, username, password);

        public static bool connect()
        {
            conn.ConnectionString = cadenaConexion;
            try
            {
                conn.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public static bool close()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
