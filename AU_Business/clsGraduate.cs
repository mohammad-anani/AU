using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsGraduate
    {
        public int StudentID { get; set; }

        public clsStudent Student { get; set; }

        public DateTime GraduationDate { get; set; }

        public clsGraduate() 
        { 
        
            this.StudentID = 0;
            this.Student = new clsStudent();
            this.GraduationDate = DateTime.MinValue;
        }

        public clsGraduate(int studentid,DateTime date)
        {

            this.StudentID = studentid;
            this.Student = clsStudent.FindStudentByID(studentid) ;
            this.GraduationDate = date;
        }

        public bool AddGraduate()
        {
        return clsGraduateData.AddGraduate(this.StudentID, this.GraduationDate)!=-1;
        }

        public static DataTable ListGrads()
        {
            return clsGraduateData.ListGraduates();
        }
    }
}
