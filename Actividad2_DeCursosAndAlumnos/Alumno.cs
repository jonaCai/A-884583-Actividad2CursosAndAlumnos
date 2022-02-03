using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2_DeCursosAndAlumnos
{
    class Alumno
    {
        public int legajo { get; set; }
        public decimal ranking { get; set; }

        public Alumno(string linea)
        {
            var datos = linea.Split('|');

            legajo = Validadores.validarint(datos[0]);
            ranking = validardecimal(datos[1]);
            
        }

       
    }
}
