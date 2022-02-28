using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Act2CoursesAndStudents
{
    static class validators
    {
    
        public static void ListWriter(string url, List<string>list)
        {
            using (var Writer = new StreamWriter(url, append: true))
            {
                foreach (var courseOrStudent in list)
                {
                    Writer.WriteLine(courseOrStudent);
                }
            }                        

        }

        public static int validateInteger(string texto)
        {
            int number;
            string input;
            bool flag=true;

            do
            {
                Console.Write(texto);
                input = Console.ReadLine();
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("You must enter an integer.");
                    flag = false;
                }else { flag = true; }

            } while (flag==false);

            return number;
        }

        public static decimal validateDecimal(string entrada)
        {
            decimal number;
            do
            {
                if (!decimal.TryParse(entrada, out number))
                {
                    Console.WriteLine("You must enter a decimal.");

                }

            } while (number == 0);

            return number;
        }
        //eliminar lo que sigue, usar un enum.
        public static bool TextoEsp(string texto, string ele1, string ele2)
        {
            string ingreso;
            bool flag;
            bool eleccion = true;
            do
            {
                flag = false;
                Console.Write(texto);
                ingreso = Console.ReadLine().ToUpper();
                
                if (ingreso != ele1.ToUpper() && ingreso != ele2.ToUpper())
                {
                    Console.WriteLine($"Debe ingresar {ele1} o {ele2}.");
                    flag = true;
                }
                else
                {
                    if (ingreso == ele1) { eleccion = true; } else { eleccion = false; }
                }

            } while (flag == true);

            return eleccion;
        }
        

        public static bool validateCode(int file)
        {
            bool flag = false;            
            foreach (var student in ListStudents.list)
            {
                if (file == student.Key)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool validateCode(string code)
        {
            bool flag = false;
            foreach (var a in ListCourses.list)
            {
                if (code == a.Key)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static string validateText(string text)
        {
            bool flag;           
            string input = "";
            do
            {
                flag = false;
                Console.Write(text);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    flag = true;
                    Console.WriteLine("Must enter a code.");
                }
                


            } while (flag == true);

            return input;


        }

        //nuevo validador aqui
    }
}
