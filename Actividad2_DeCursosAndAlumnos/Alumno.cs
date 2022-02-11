using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Actividad2CursosAndAlumnos
{
    class Alumno
    {
        private int legajo { get; set; }
        private decimal ranking { get; set; }

        public Alumno(string linea)
        {  
            var datos = linea.Split('|');
            legajo = int.Parse(datos[0]);
            ranking = decimal.Parse(datos[1]);                
            
        }
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }

        }
        public decimal Ranking
        {
            get { return ranking; }
            set { ranking = value; }

        }

    }
}
