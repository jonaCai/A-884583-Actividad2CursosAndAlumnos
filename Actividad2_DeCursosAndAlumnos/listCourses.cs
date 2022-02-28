using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Act2CoursesAndStudents
{
    class ListCourses
    {
        public static Dictionary<string, Course> list = new Dictionary<string, Course>();
        static string archiveName = "NominaCursos.txt";

        public static void loadListCourses()
        {
            if (File.Exists(archiveName))
            {
                using (var reader = new StreamReader(archiveName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var x = line.Split('|');
                        if (!validators.validateCode(x[0]))
                        {
                            var course = new Course(line);
                            list.Add(course.Code, course);
                        }


                    }
                }
            }
        }


        public static void InputCourses()
        {
            string urlArchiveCourses = @"C:\Users\User\Downloads\FCE\CAI\2021\Practica\Actividad2_DeCursosAndAlumnos\Actividad2_DeCursosAndAlumnos\bin\Debug\NominaCursos.txt";
            string courseCode;
            int maxCapacityCourse;
            bool continueAdd = true;            
            List<string> courseList = new List<string>();
            
            if (File.Exists(urlArchiveCourses)) { loadListCourses(); }

            do
            {
                courseCode = validators.validateText("Enter code of the course:");
                maxCapacityCourse = validators.validateInteger("Enter maximun capacity of the course:");
                if (courseList.Exists(x => x.Contains(courseCode+ " |")) || (validators.validateCode(courseCode)))
                {
                    Console.WriteLine("The code of the course already exist.");
                    continue;

                }
                else
                {                    
                    courseList.Add(courseCode + " |" + maxCapacityCourse.ToString() + "|");
                    continueAdd = validators.TextoEsp("Course successfully admitted, do you want to add more?s/n?: ", "S", "N");
                  
                }

            } while (continueAdd == true);

            validators.ListWriter(urlArchiveCourses, courseList);

            loadListCourses();


        }


        public static void reportStudentsForCourses()
        {
            foreach(var student in ListStudents.list)
            {
                Console.WriteLine("File number of the student: " + student.Key.ToString());
                Console.Write("Code of courses: ");
                foreach (var j in ListStudents.listStudentCourse)
                {
                    if (student.Key == j.Value.File)
                    {
                        Console.Write(j.Value.CodeCourse+", ");

                    }

                }
                Console.WriteLine();

            }


        }

    }
}
