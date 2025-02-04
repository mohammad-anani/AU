using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsStudent
    {
        public int StudentID { get; set; }

        public int PersonID { get; set; }
        
        public clsPerson Person { get; set; }

        public int MajorID { get; set; }

        public clsMajor Major { get; set; }

        public int AcademicYear { get; set; }

        public int YearPassedCourses { get; set; }

        public int YearRequiredCourses { get; set; }

        public int TotalPassedCourses { get; set; }

        public int TotalRequiredCourses { get; set; }

        public double YearPrice { get; set; }

        public bool IsGrad {  get; set; }

        public int Scholarship { get; set; }

        public double CumulativeGPA { get; set; }
        public clsStudent()
        {
            this.StudentID = -1;
            this.PersonID = -1;
            this.MajorID = -1;
            this.AcademicYear = -1;
            this.YearPassedCourses = -1;
            this.YearRequiredCourses = -1;
            this.TotalRequiredCourses = -1;
            this.TotalPassedCourses = -1;
            this.Major=new clsMajor();
            this.Person=new clsPerson();
            this.YearPrice = -1;
            this.CumulativeGPA = -1;
            this.IsGrad = false;
            this.Scholarship = -1;

        }

        private clsStudent(int studentID,int personid,int majorid,int academicyear,int yearpassedcourses,int yearrequiredcourses,int totalreuqiredcourses,int totalpassedcourses,double yearprice,double cgpa,int scholarship)
        {
            this.StudentID = studentID;
            this.PersonID = personid;
            this.Person=clsPerson.Find(personid);
            this.MajorID = majorid;
            this.Major=clsMajor.Find(majorid);
            this.AcademicYear= academicyear;
            this.YearPassedCourses= yearpassedcourses;
            this.YearRequiredCourses= yearrequiredcourses;
            this.TotalPassedCourses = totalpassedcourses;
            this.TotalRequiredCourses=totalreuqiredcourses;  
            this.YearPrice= yearprice;
            this.CumulativeGPA= cgpa;
            this.IsGrad=clsGraduateData.IsStudentGraduate(studentID);
            this.Scholarship= scholarship;
        }

        public bool AddStudent()
        {
            this.StudentID=clsStudentData.AddStudent(this.PersonID,this.MajorID,this.Scholarship);

            return this.StudentID != -1;
        }


        public static DataTable Liststudents()
        {
            return clsStudentData.GetStudentsList();
        }

        public bool AdvanceAcademicYear()
        {
            if(clsStudentData.ChangeAcademicYear(this.StudentID, this.AcademicYear + 1,this.Scholarship))
            {
                this.AcademicYear++;
                return true;
            }
            return false;
           
        }

        public bool NullScholarship()
        {
            return clsStudentData.ChangeAcademicYear(this.StudentID, this.AcademicYear, this.Scholarship);
        }

        public static bool DeleteStudent(int studentID)
        {
            return clsStudentData.DeleteStudent(studentID);
        }

        public static clsStudent FindStudentByID(int studentid)
        {
            int PersonID = -1;
            int MajorID = -1;
            int AcademicYear = -1;
            int YearPassedCourses = -1;
            int YearRequiredCourses = -1;
            int TotalRequiredCourses = -1;
            int TotalPassedCourses = -1;
            double yearprice = -1;
            double cgpa = -1;
            int scholarship = -1;

            if(clsStudentData.FindStudentByID(studentid,ref PersonID,ref MajorID,ref AcademicYear,ref YearPassedCourses,ref TotalPassedCourses,ref YearRequiredCourses,ref TotalRequiredCourses,ref yearprice,ref cgpa,ref scholarship))
            {
                return new clsStudent(studentid, PersonID, MajorID, AcademicYear, YearPassedCourses, YearRequiredCourses, TotalRequiredCourses, TotalPassedCourses,yearprice,cgpa, scholarship);
            }
            return new clsStudent();
        }

        public static clsStudent FindStudentByPersonID(int PersonID)
        {
            int studentid = -1;
            int MajorID = -1;
            int AcademicYear = -1;
            int YearPassedCourses = -1;
            int YearRequiredCourses = -1;
            int TotalRequiredCourses = -1;
            int TotalPassedCourses = -1;
            double yearprice = -1;
            double cgpa = -1;
            int scholarship = -1;

            if (clsStudentData.FindStudentByPersonID(ref studentid, PersonID, ref MajorID, ref AcademicYear, ref YearPassedCourses, ref TotalPassedCourses, ref YearRequiredCourses, ref TotalRequiredCourses,ref yearprice,ref cgpa, ref scholarship))
            {
                return new clsStudent(studentid, PersonID, MajorID, AcademicYear, YearPassedCourses, YearRequiredCourses, TotalRequiredCourses, TotalPassedCourses,yearprice,cgpa,scholarship);
            }
            return new clsStudent();
        }


        public static int GetStudentsCount()
        {
            return clsStudentData.GetStudentsCount();
        }
    }
}
