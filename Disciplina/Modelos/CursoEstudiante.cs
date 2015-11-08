using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina.Modelos
{
    class CursoEstudiante : IModelo
    {
        String idCurso;
        String idEstudiante;

        public CursoEstudiante(String idCurso, String idEstudiante)
        {
            this.idCurso = idCurso;
            this.idEstudiante = idEstudiante;
        }

        public Dictionary<string, String> esquema()
        {
            Dictionary<string, String> tabla = new Dictionary<string, String>();
            tabla.Add("IDCurso", this.idCurso);
            tabla.Add("IDEstudiante", this.idEstudiante);

            return tabla;
        }
    }
}
