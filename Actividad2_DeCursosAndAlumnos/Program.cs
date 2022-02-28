using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Act2CoursesAndStudents
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

            bool check_assig=false;
            string choice;

            do
            {
                ListStudents.loadListStudents();
                ListCourses.loadListCourses();

                Console.WriteLine("Welcome! Choose an item:"
                + "\n A. Input students \n B. Input courses \n C. Assign courses to students "
                + "\n D.Get reports of students for courses. \n E. Exit.");

                Console.Write("Choice:"); choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "a":
                        ListStudents.InputStudents();
                        Console.WriteLine();
                        break;

                    case "b":
                       ListCourses.InputCourses();
                        Console.WriteLine();
                        break;
                    case "c":
                        check_assig = true;
                        ListStudents.equitableAssignmetn();
                        Console.WriteLine();
                        break;

                    case "d":
                        if (check_assig == false) { ListStudents.equitableAssignmetn(); }
                        //si se ejecuto c, no deberia ejecutarse.
                        ListCourses.reportStudentsForCourses();

                        break;

                    case "e":
                        
                        Console.WriteLine();
                        break;
                }

            } while (choice != "e");
            
         

        }
                
    }
}
