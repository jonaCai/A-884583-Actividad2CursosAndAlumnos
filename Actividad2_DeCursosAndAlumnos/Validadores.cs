using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2_DeCursosAndAlumnos
{
    class Validadores
    {

        public static int validarint(string entrada)
        {
            int numero;
            do
            {
                if (!int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor numérico como legajo.");

                }

            } while (numero == 0);

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

        //nuevo validador aqui
    }
}
