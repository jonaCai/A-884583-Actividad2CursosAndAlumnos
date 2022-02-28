using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Act2CoursesAndStudents
{
    class studentsCourses
    {
        private string codeCourse { get; set; }
        private int file { get; set; }

        public studentsCourses(string code, int file)
        {
            this.codeCourse = code;
            this.file = file;            
        }
        public string CodeCourse
        {
            get { return codeCourse; }
            set { codeCourse = value ; }

        }
        public int File
        {
            get { return file; }
            set { file = value; }

        }
    }
}
