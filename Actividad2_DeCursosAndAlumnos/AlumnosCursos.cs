using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
    class AlumnosCursos
    {
        public string codigoCurso { get; set; }
        public int legajo { get; set; }

        public AlumnosCursos(string code, int legajo)
        {
            this.codigoCurso = code;
            this.legajo = legajo;
            
        }


    }
}
