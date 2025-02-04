using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsCourse
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public int CourseCredits { get; set; }
        public int DepartmentID { get; set; }

        public clsDepartment Department { get; set; }

        public enum enMode { Add,Update}

        public enMode Mode { get; set; }

        public clsCourse()
        {
           this.CourseId = -1;
           this.CourseName = "";
           this.CourseDescription = "";
           this.CourseCredits = -1;
           this.DepartmentID = -1;
            this.Department = new clsDepartment();
            this.Mode = enMode.Add;
        }

        private clsCourse(int courseId, string courseName, string courseDescription, int courseCredits, int departmentID)
        {
           this.CourseId = courseId;
           this.CourseName = courseName;
           this.CourseDescription = courseDescription;
           this.CourseCredits = courseCredits;
           this.DepartmentID = departmentID;
            this.Department=clsDepartment.Find(departmentID);
            this.Mode=enMode.Update;
          
        }

        public static int GetCoursesCount()
        {
            return clsCourseData.GetCoursesCount();
        }

        public static DataTable ListCourses()
        {
            return clsCourseData.ListCourses();
        }

        private bool _AddCourse()
        {
            this.CourseId=clsCourseData.AddCourse(this.CourseName,this.CourseDescription,this.CourseCredits,this.DepartmentID);

            return this.CourseId != -1;
        }

        private bool _UpdateCourse()
        {
            return clsCourseData.UpdateCourse(this.CourseId, this.CourseName, this.CourseDescription, this.CourseCredits, this.DepartmentID);
        }

        public bool Save()
        {
            if(this.Mode==enMode.Add)
            {
                if(this._AddCourse())
                {
                    this.Mode = enMode.Update;
                    return true;
                }    
            }
            else if(this.Mode==enMode.Update)
            {
                return this._UpdateCourse();
            }
            return false;
        }

        public static bool DeleteCourse(int courseid)
        {

            return clsCourseData.DeleteCourse(courseid);
        }


        public static clsCourse Find(int courseid)
        {
            string name = "", desc = "";int credits = -1, departmentid = -1;

            if(clsCourseData.FindCourseByID(courseid,ref name,ref desc,ref credits,ref departmentid))
            {
                return new clsCourse(courseid,name,desc,credits,departmentid);
            }
            return new clsCourse();
                    }


        public static clsCourse Find(string name)
        {
            string desc = ""; int credits = -1, departmentid = -1,courseid=-1;

            if (clsCourseData.FindCourseByName(ref courseid, name, ref desc, ref credits, ref departmentid))
            {
                return new clsCourse(courseid, name, desc, credits, departmentid);
            }
            return new clsCourse();
        }
    }
}
