using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_884583_Act2CoursesAndStudents
{
    class Course
    {
        private string code { get; set; }
        private int maximunCapacity { get; set; }


        public Course(string linea)
        {
            var dataCourse = linea.Split('|');
            code = dataCourse[0];
            maximunCapacity =int.Parse(dataCourse[1]);
                    
        }
        public string Code
        {
            get { return code; }
            set { code = value; }                                   
        }
        public int MaximunCapacity
        {
            get { return maximunCapacity; }
            set { maximunCapacity = value; }

        }
    }
}
