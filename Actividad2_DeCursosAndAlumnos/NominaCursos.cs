using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Actividad2CursosAndAlumnos
{
    class NominaCursos
    {
        public static Dictionary<string, Curso> nomina = new Dictionary<string, Curso>();
        static string nombreArchivo = "NominaCursos.txt";

        public static void CargarNominaCursos()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var x = linea.Split('|');
                        if (!Validadores.ValidarCodigo(x[0]))
                        {
                            var curso = new Curso(linea);
                            nomina.Add(curso.Codigo, curso);
                        }


                    }
                }
            }
        }


        public static void IngresoDeCursos()
        {
            string ruta = @"C:\Users\User\Downloads\FCE\CAI\2021\Practica\Actividad2_DeCursosAndAlumnos\Actividad2_DeCursosAndAlumnos\bin\Debug\NominaCursos.txt";
            string codigo;
            int capacidad;
            bool seguir = true;            
            List<string> curso = new List<string>();

            //secuencia para pedir y guardar alumnos en el txt.
            if (File.Exists(ruta)) { CargarNominaCursos(); }

            do
            {
                codigo = Validadores.Valtexto("Ingrese el codigo de curso:");
                capacidad = Validadores.validarint("Ingrese la capacidad del curso:");
                if (curso.Exists(x => x.Contains(codigo+ " |")) || (Validadores.ValidarCodigo(codigo)))
                {
                    Console.WriteLine("El curso ingresado ya existe.");
                    continue;

                }
                else
                {                    
                    curso.Add(codigo + " |" + capacidad.ToString() + "|");
                    seguir = Validadores.TextoEsp("Curso ingresado con exito, desea ingresar más?s/n: ", "S", "N");


                }

            } while (seguir == true);


            using (var Writer = new StreamWriter(ruta, append: true))
            {
                foreach (var a in curso)
                {
                    Writer.WriteLine(a);
                }
            }

            CargarNominaCursos();


        }


        public static void reporteAl_cur()
        {
            foreach(var i in NominaAlumnos.nomina)
            {
                Console.WriteLine("Legajo alumno: "+ i.Key.ToString());
                Console.Write("Codigos cursos: ");
                foreach (var j in NominaAlumnos.Al_Cur)
                {
                    if (i.Key == j.Value.Legajo)
                    {
                        Console.Write(j.Value.CodigoCurso+", ");

                    }

                }
                Console.WriteLine();

            }


        }

    }
}
