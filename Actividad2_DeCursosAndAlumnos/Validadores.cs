using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Actividad2CursosAndAlumnos
{
    static class Validadores
    {

        public static int validarint(string texto)
        {
            int numero;
            string entrada;
            bool flag=true;

            do
            {
                Console.Write(texto);
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor numérico como legajo.");
                    flag = false;
                }else { flag = true; }

            } while (flag==false);

            return numero;
        }

        public static decimal validardecimal(string entrada)
        {
            decimal numero;
            do
            {
                if (!decimal.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor decimal como ranking.");

                }

            } while (numero == 0);

            return numero;
        }

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
        

        public static bool ValidarCodigo(int legajo)
        {
            bool flag = false;            
            foreach (var a in NominaAlumnos.nomina)
            {
                if (legajo == a.Key)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool ValidarCodigo(string code)
        {
            bool flag = false;
            foreach (var a in NominaCursos.nomina)
            {
                if (code == a.Key)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static string Valtexto(string texto)
        {
            bool flag;           
            string ingreso = "";
            do
            {
                flag = false;
                Console.Write(texto);
                ingreso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    flag = true;
                    Console.WriteLine("Debe ingresar un codigfo.");
                }
                


            } while (flag == true);

            return ingreso;


        }

        //nuevo validador aqui
    }
}
