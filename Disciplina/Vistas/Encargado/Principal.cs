﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disciplina.Vistas.Encargado
{
    public partial class Principal : Form
    {
        private Dictionary<string, object> datos;
        private Controladores.Encargado controlador;
        private Controladores.Carrera carrera;
        private Controladores.Curso curso;
        private Controladores.Estudiante estudiante;
        private Controladores.EstudianteOficial oficial;
        private Controladores.Falta falta;
        private Controladores.CursoEstudiantes cursoEstudiante;
        private Controladores.FaltasEstudiantes faltasEstudiante;
        private Controladores.Reportes reportes;

        public Principal()
        {
            InitializeComponent();
            this.datos = new Dictionary<string, object>();
            this.controlador = new Controladores.Encargado();
            this.carrera = new Controladores.Carrera();
            this.curso = new Controladores.Curso();
            this.estudiante = new Controladores.Estudiante();
            this.oficial = new Controladores.EstudianteOficial();
            this.falta = new Controladores.Falta();
            this.cursoEstudiante = new Controladores.CursoEstudiantes();
            this.faltasEstudiante = new Controladores.FaltasEstudiantes();
            this.reportes = new Controladores.Reportes();
        }

        private void btnAdminCuentas_Click(object sender, EventArgs e)
        {
            this.controlador.cuentas();
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            this.carrera.carreras();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            this.curso.cursos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.estudiante.estudiantes();
        }

        private void btnAdminFaltas_Click(object sender, EventArgs e)
        {
            this.falta.faltas();
        }

        private void btnCursosEstudiantes_Click(object sender, EventArgs e)
        {
            this.cursoEstudiante.registrar();
        }

        private void btnEstudiantesFaltas_Click(object sender, EventArgs e)
        {
            this.faltasEstudiante.principal();
        }

        private void btnAdminConsultas_Click(object sender, EventArgs e)
        {
            this.reportes.opciones();
        }

        private void btnOficiales_Click(object sender, EventArgs e)
        {
            this.oficial.oficiales();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlador.actualizarCuenta();
        }
    }
}
