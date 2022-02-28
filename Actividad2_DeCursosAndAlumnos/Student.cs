using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_884583_Act2CoursesAndStudents
{
    class Student
    {
        private int file { get; set; }
        private decimal ranking { get; set; }

        public Student(string linea)
        {  
            var dataStudent = linea.Split('|');
            file = int.Parse(dataStudent[0]);
            ranking = decimal.Parse(dataStudent[1]);                
            
        }
        public int File
        {
            get { return file; }
            set { file = value; }

        }
        public decimal Ranking
        {
            get { return ranking; }
            set { ranking = value; }

        }

    }
}
