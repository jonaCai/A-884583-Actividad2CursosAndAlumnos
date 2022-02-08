using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Actividad2CursosAndAlumnos
{
    public class Alumno
    {
        public int legajo { get; set; }
        public decimal ranking { get; set; }

        public Alumno(string linea)
        {  
            var datos = linea.Split('|');
            legajo = int.Parse(datos[0]);
            ranking = decimal.Parse(datos[1]);                
            
        }

       
    }
}
