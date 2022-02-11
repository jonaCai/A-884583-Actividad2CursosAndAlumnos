using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
    class Curso
    {
        private string codigo { get; set; }
        private int capacidadmaxima { get; set; }


        public Curso(string linea)
        {
            var datos = linea.Split('|');
            codigo = datos[0];
            capacidadmaxima =int.Parse(datos[1]);
                    
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }                                   
        }
        public int Capacidadmaxima
        {
            get { return capacidadmaxima; }
            set { capacidadmaxima = value; }

        }
    }
}
