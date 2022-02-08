using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
   /*-	La facultad requiere una aplicación para asignar alumnos a cursos.Para ello se le solicita una aplicación que permita:
o A) El ingreso de una serie de _alumnos_(identificados por número de legajo), junto con su ránking(un número decimal arbitrario).
o B) El ingreso de una serie de _cursos_(identificados por número de curso), junto con la capacidad de participantes de cada uno.
o C) Que asigne automáticamente los alumnos a los cursos ingresados, teniendo en cuenta: 
	1) distribuir equitativamente la cantidad de alumnos en los cursos(ej.: no puede haber un curso con 20 asignados y otro con 0).
	2) asignar a los alumnos por ranking, de manera tal que, en caso de no haber suficientes vacantes, queden sin asignación los de menor ránking.
o D) Reporte alumnos por curso en pantalla.
*/

    class Program
    {
        static void Main(string[] args)
        {

           
            string eleccion;

            do
            {
                NominaAlumnos.CargarNominaAlumnos();
                NominaCursos.CargarNominaCursos();

                Console.WriteLine("Bienvenido! En este programa usted puede hacer lo siguiente:"
                + "\n A. Ingresar alumnos \n B. Ingresar cursos \n C. Asignar automaticamente alumnos a cursos "
                + "\n D. Obtener reporte de alumnos por curso. \n E. Exit.");

                Console.Write("Eleccion:"); eleccion = Console.ReadLine().ToLower();

                switch (eleccion)
                {
                    case "a":
                        NominaAlumnos.IngresoDeAlumnos();
                        Console.WriteLine();
                        break;

                    case "b":
                       NominaCursos.IngresoDeCursos();
                        Console.WriteLine();
                        break;
                    case "c":
                        
                        NominaAlumnos.AsignacionEquitativa();
                        Console.WriteLine();
                        break;

                    case "d":
                        NominaAlumnos.AsignacionEquitativa();
                        NominaCursos.reporteAl_cur();

                        break;

                    case "e":
                        
                        Console.WriteLine();
                        break;
                }

            } while (eleccion != "e");
            
         

        }
                
    }
}
