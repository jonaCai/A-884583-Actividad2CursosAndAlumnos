using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
    public class Curso
    {
        public string codigo { get; set; }
        public int capacidadmaxima { get; set; }


        public Curso(string linea)
        {
            var datos = linea.Split('|');
            codigo = datos[0];
            capacidadmaxima =int.Parse(datos[1]);
                    
        }
    }
}
