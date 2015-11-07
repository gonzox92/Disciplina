﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Controladores
{
    class Carrera : Controller
    {
        public DataTable getCarreras()
        {
            string[] columnas = { 
                "ID", 
                "nombre AS Nombre"
            };
            string[] tablas = { "carreras" };
            Dictionary<string, string[]> filtro = new Dictionary<string, string[]>();
            filtro.Add("1", new string[] { "=", "1", "" });

            return Modelos.Consultas.Server.select(columnas, tablas, filtro);
        }

        public void carreras()
        {
            DataTable cuentas = this.getCarreras();
            Form vista = new Vistas.Carreras.Principal(cuentas);
            this.resolver(vista);
        }

        public void registrar()
        {
            Form vista = new Vistas.Carreras.Registrar();
            this.resolver(vista);
        }

        public bool registrar(Modelos.IModelo datos)
        {
            return Modelos.Consultas.Server.insert("carreras", datos.esquema());
        }
    }
}
