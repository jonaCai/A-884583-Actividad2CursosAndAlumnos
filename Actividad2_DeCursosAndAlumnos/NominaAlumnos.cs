using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Actividad2CursosAndAlumnos
{
    static class NominaAlumnos
    {//podriamos restringir el nivel de accero de los diccionarios y solo accederlos a traves de las propiedades...
        public static Dictionary<int, Alumno> nomina = new Dictionary<int, Alumno>();
        static string nombreArchivo = "NominaAlumnos.txt";
        public static Dictionary<string, AlumnosCursos> Al_Cur = new Dictionary<string, AlumnosCursos>();
        static string nombreArchivo_0 = "AlumnosCursos.txt";

        public static void CargarNominaAlumnos()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var x = linea.Split('|');
                        if (!Validadores.ValidarCodigo(int.Parse(x[0])))
                        {
                            var alumno = new Alumno(linea);
                            nomina.Add(alumno.Legajo, alumno);
                        }


                    }
                }
            }
        }

        public static void IngresoDeAlumnos()
        {
            string ruta = @"C:\Users\User\Downloads\FCE\CAI\2021\Practica\Actividad2_DeCursosAndAlumnos\Actividad2_DeCursosAndAlumnos\bin\Debug\NominaAlumnos.txt";
            int registro;
            decimal ranking;
            bool seguir = true;
            var random = new Random();
            List<string> alumnos = new List<string>();

            //secuencia para pedir y guardar alumnos en el txt.
            if (File.Exists(ruta)) { CargarNominaAlumnos(); }

            do
            {
                registro = Validadores.validarint("Ingrese el numero de legajo del alumno:");

                if (alumnos.Exists(x => x.Contains(registro.ToString() + " |")) || (Validadores.ValidarCodigo(registro)))
                {
                    Console.WriteLine("El legajo ingresado ya existe.");
                    continue;

                }
                else
                {
                    ranking = decimal.Parse((random.NextDouble() * 100.0).ToString("0.00"));
                    alumnos.Add(registro.ToString() + " |" + ranking.ToString() + "|");
                    seguir = Validadores.TextoEsp("Alumno ingresado con exito, desea ingresar más?s/n: ", "S", "N");


                }

            } while (seguir == true);


            using (var Writer = new StreamWriter(ruta, append: true))
            {
                foreach (var a in alumnos)
                {
                    Writer.WriteLine(a);
                }
            }

            CargarNominaAlumnos();


        }


        public static void AsignacionEquitativa()
        {
            int cantidadAlumnos = nomina.Count();
            int cantidadCursos = NominaCursos.nomina.Count();
            int reparto = (cantidadAlumnos*3) / cantidadCursos;
            string key_alcur;
            int capacidad_max;
            int max_cursos_al;
            int Curso_al=0;
            var alumnkeys = nomina.Keys.ToArray();
            var cursoKeys = NominaCursos.nomina.Keys.ToArray();
            var rankAlumn = nomina.ToList();
            int TopeAlCur=3;
            for (int b= 0; b<cantidadAlumnos; b++)
            {
                max_cursos_al = 0;                
                do
                {
                    capacidad_max = NominaCursos.nomina[cursoKeys[Curso_al]].Capacidadmaxima;
                    int repartocurso = Al_Cur.Count(x => x.Value.CodigoCurso == cursoKeys[Curso_al]);
                    if (capacidad_max > reparto)
                    {                        
                        if (repartocurso == reparto)
                        {
                            //cuento la cantidad de veces que aparece un codigo de curso en el diccionario, para distribuir equitativamente
                            if (Al_Cur.Count(x => x.Value.Legajo == alumnkeys[b]) < 3)
                            {
                                //si el alumno se quedo fuera por el reparto, añadirlo igual ya que hay espacio aun.
                                key_alcur = alumnkeys[b].ToString() + cursoKeys[Curso_al].ToString();
                                AlumnosCursos alumnoscursos = new AlumnosCursos(cursoKeys[Curso_al].ToString(), alumnkeys[b]);
                                Al_Cur.Add(key_alcur, alumnoscursos);
                            }

                        }else
                        {
                            key_alcur = alumnkeys[b].ToString() + cursoKeys[Curso_al].ToString();
                            AlumnosCursos alumnoscursos = new AlumnosCursos(cursoKeys[Curso_al].ToString(), alumnkeys[b]);
                            Al_Cur.Add(key_alcur, alumnoscursos);
                        }
                        
                    }
                    else
                    {
                        if (repartocurso < capacidad_max)
                        {                            
                            rankAlumn.Sort((a, c) => a.Value.Ranking.CompareTo(c.Value.Ranking));
                            //ingreso  todos los alumnos que quepan al curso rankeado.

                            for (int cont_rank= rankAlumn.Count-1; cont_rank>0;--cont_rank)
                            {
                                repartocurso = Al_Cur.Count(x => x.Value.CodigoCurso == cursoKeys[Curso_al]);
                                if ((Al_Cur.Count(x => x.Value.Legajo == rankAlumn[cont_rank].Value.Legajo) < 3) && (repartocurso < capacidad_max))
                                {
                                    key_alcur = rankAlumn[cont_rank].Key.ToString() + cursoKeys[Curso_al].ToString();
                                    AlumnosCursos alumnoscursos = new AlumnosCursos(cursoKeys[Curso_al].ToString(), rankAlumn[cont_rank].Key);
                                    Al_Cur.Add(key_alcur, alumnoscursos);

                                }

                            }
                            

                        }

                        //rank
                    }
                       
                    if (cantidadCursos - 1 < 3)
                    {
                        TopeAlCur = cantidadCursos;
                    }

                    if (Curso_al == cantidadCursos - 1)//si cantidad de cursos fuera cero deberia alertarlo al usuario.
                    {
                        Curso_al = 0;
                    }
                    else { Curso_al += 1; }
                    
                    
                    max_cursos_al +=1;
                    
                        

                } while (max_cursos_al<TopeAlCur);
                             
                

            }         
                  

            using (var Writer = new StreamWriter(nombreArchivo_0, append: false))
            {
                foreach (var a in Al_Cur)
                {
                    Writer.WriteLine(a.Key+" | "+a.Value.CodigoCurso+", "+a.Value.Legajo.ToString());
                }
            }


        }

        
    }

}
