using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class Curso : IModelo
    {
        public String ID;
        public String IDCarrera;
        public String paralelo;
        public String year;
        public String periodo;
        public String curso;

        public Curso(String ID, String IDCarrera, String year, String periodo, String curso, String paralelo)
        {
            this.ID = ID;
            this.IDCarrera = IDCarrera;
            this.paralelo = paralelo;
            this.year = year;
            this.periodo = periodo;
            this.curso = curso;
        }

        public Curso(String IDCarrera, String year, String periodo, String curso, String paralelo)
        {
            this.IDCarrera = IDCarrera;
            this.paralelo = paralelo;
            this.year = year;
            this.periodo = periodo;
            this.curso = curso;
        }

        public Curso(String year, String periodo, String curso, String paralelo)
        {
            this.paralelo = paralelo;
            this.year = year;
            this.periodo = periodo;
            this.curso = curso;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("IDCarrera", this.IDCarrera);
            tabla.Add("paralelo", this.paralelo);
            tabla.Add("year", this.year);
            tabla.Add("periodo", this.periodo);
            tabla.Add("curso", this.curso);

            return tabla;
        }
    }
}
