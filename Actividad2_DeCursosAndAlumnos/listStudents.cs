using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Act2CoursesAndStudents
{
    static class ListStudents
    {
        public static Dictionary<int, Student> list = new Dictionary<int, Student>();
        static string nameArchiveStudents = "NominaAlumnos.txt";
        public static Dictionary<string, studentsCourses> listStudentCourse = new Dictionary<string, studentsCourses>();
        static string nameArchiveCourses = "AlumnosCursos.txt";

        public static void loadListStudents()
        {
            if (File.Exists(nameArchiveStudents))
            {
                using (var reader = new StreamReader(nameArchiveStudents))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var x = line.Split('|');
                        if (!validators.validateCode(int.Parse(x[0])))
                        {
                            var student = new Student(line);
                            list.Add(student.File, student);
                        }


                    }
                }
            }
        }

        public static void InputStudents()
        {
            string urlArchiveStudents = @"C:\Users\User\Downloads\FCE\CAI\2021\Practica\Actividad2_DeCursosAndAlumnos\Actividad2_DeCursosAndAlumnos\bin\Debug\NominaAlumnos.txt";
            int fileStudents;
            decimal ranking;
            bool continueAdd = true;
            var random = new Random();
            List<string> studentsList = new List<string>();
            
            if (File.Exists(urlArchiveStudents)) { loadListStudents(); }

            do
            {
                fileStudents = validators.validateInteger("Enter number file of the student: ");

                if (studentsList.Exists(x => x.Contains(fileStudents.ToString() + " |")) || (validators.validateCode(fileStudents)))
                {
                    Console.WriteLine("Number file it already exists.");
                    continue;

                }
                else
                {
                    ranking = decimal.Parse((random.NextDouble() * 100.0).ToString("0.00"));
                    studentsList.Add(fileStudents.ToString() + " |" + ranking.ToString() + "|");
                    continueAdd = validators.TextoEsp("Student successfully admitted, do you want to add more?s/n: ", "S", "N");
                    
                }

            } while (continueAdd == true);


            validators.ListWriter(urlArchiveStudents,studentsList);
            
            loadListStudents();


        }


        public static void equitableAssignmetn()
        {
            int amountStudents = list.Count();
            int amountCourses = ListCourses.list.Count();
            int distributionStudentForCourse = (amountStudents*3) / amountCourses;
            string keyStudentCourse="";
            int maximunCapacity;
            int maximunStudentCourse;
            int courseStudent=0;
            var studentKey = list.Keys.ToArray();
            var courseKey = ListCourses.list.Keys.ToArray();
            var studentRanking = list.ToList();
            int MaxStudentForCourse=3;
            for (int student= 0; student<amountStudents; student++)
            {
                maximunStudentCourse = 0;                
                do
                {
                    maximunCapacity = ListCourses.list[courseKey[courseStudent]].MaximunCapacity;
                    int distributionCourse = listStudentCourse.Count(x => x.Value.CodeCourse == courseKey[courseStudent]);
                    if (maximunCapacity > distributionStudentForCourse)
                    {                        
                        if (distributionCourse == distributionStudentForCourse)
                        {
                           
                            if (listStudentCourse.Count(x => x.Value.File == studentKey[student]) < 3)
                            {
                                enterStudent(keyStudentCourse, studentKey, student, courseKey, courseStudent);
                            }

                        }else
                        {
                            enterStudent(keyStudentCourse, studentKey, student, courseKey, courseStudent);
                        }
                        
                    }
                    else
                    {
                        if (distributionCourse < maximunCapacity)
                        {                            
                            studentRanking.Sort((a, c) => a.Value.Ranking.CompareTo(c.Value.Ranking));
                            
                            for (int cont_rank= studentRanking.Count-1; cont_rank>0;--cont_rank)
                            {
                                distributionCourse = listStudentCourse.Count(x => x.Value.CodeCourse == courseKey[courseStudent]);
                                if ((listStudentCourse.Count(x => x.Value.File == studentRanking[cont_rank].Value.File) < 3) && (distributionCourse < maximunCapacity))
                                {
                                    keyStudentCourse = studentRanking[cont_rank].Key.ToString() + courseKey[courseStudent].ToString();
                                    studentsCourses studentCourse = new studentsCourses(courseKey[courseStudent].ToString(), studentRanking[cont_rank].Key);
                                    listStudentCourse.Add(keyStudentCourse, studentCourse);

                                }

                            }
                            

                        }

                        //rank
                    }
                       
                    if (amountCourses - 1 < 3)
                    {
                        MaxStudentForCourse = amountCourses;
                    }

                    if (courseStudent == amountCourses - 1)
                    {
                        courseStudent = 0;
                    }
                    else { courseStudent += 1; }
                    
                    
                    maximunStudentCourse +=1;
                    
                        

                } while (maximunStudentCourse<MaxStudentForCourse);
                             
                

            }         
                  

            using (var Writer = new StreamWriter(nameArchiveCourses, append: false))
            {
                foreach (var a in listStudentCourse)
                {
                    Writer.WriteLine(a.Key+" | "+a.Value.CodeCourse+", "+a.Value.File.ToString());
                }
            }


        }

        private static void enterStudent(string keyStudentCourse, int[] studentKey,int student, string[]courseKey, int courseStudent)
        {
            keyStudentCourse = studentKey[student].ToString() + courseKey[courseStudent].ToString();
            studentsCourses studentCourse = new studentsCourses(courseKey[courseStudent].ToString(), studentKey[student]);
            listStudentCourse.Add(keyStudentCourse, studentCourse);

        }        
    }

}
