using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
    class AlumnosCursos
    {
        private string codigoCurso { get; set; }
        private int legajo { get; set; }

        public AlumnosCursos(string code, int legajo)
        {
            this.codigoCurso = code;
            this.legajo = legajo;            
        }
        public string CodigoCurso
        {
            get { return codigoCurso; }
            set { codigoCurso = value ; }

        }
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }

        }
    }
}
