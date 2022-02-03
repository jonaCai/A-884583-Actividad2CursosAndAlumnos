using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2_DeCursosAndAlumnos
{
    class Curso
    {
        public int codigo { get; set; }
        public int capacidadmaxima { get; set; }


        public Curso(string code, string capacidad)
        {            
            codigo = Validadores.validarint(code);
            capacidadmaxima = Validadores.validarint(capacidad);
                    
        }
    }
}
