using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class FaltaEstudiante : IModelo
    {
        private String idCurso;
        private String idEstudiante;
        private String idFalta;
        private String fecha;
        private String concepto;
        private String detalleConcepto;
        private String puntos;

        public FaltaEstudiante(String idCurso, String idEstudiante, String idFalta, String fecha,
            String concepto, String detalleConcepto, String puntos)
        {
            this.idCurso = idCurso;
            this.idEstudiante = idEstudiante;
            this.idFalta = idFalta;
            this.fecha = fecha;
            this.concepto = concepto;
            this.detalleConcepto = detalleConcepto;
            this.puntos = puntos;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("IDCurso", this.idCurso);
            tabla.Add("IDEstudiante", this.idEstudiante);
            tabla.Add("IDFalta", this.idFalta);
            tabla.Add("fecha", this.fecha);
            tabla.Add("concepto", this.concepto);
            tabla.Add("detalleConcepto", this.detalleConcepto);
            tabla.Add("puntos", this.puntos);

            return tabla;
        }
    }
}
