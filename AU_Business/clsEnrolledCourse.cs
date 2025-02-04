using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsEnrolledCourse
    {
        public int EnrolledCourseID { get; set; }

        public int ScheduledCourseID { get; set; }

        public clsScheduledCourse ScheduledCourse { get; set; }

        public int StudentID { get; set; }

        public clsStudent Student { get; set; }

        public float Grade { get; set; }

        public clsEnrolledCourse()
        {
            this.Student = new clsStudent();
            this.StudentID = -1;
            this.EnrolledCourseID = -1;
            this.ScheduledCourseID = -1;
            this.Grade = -1;
            this.ScheduledCourse=new clsScheduledCourse();

        }

        private clsEnrolledCourse(int enrolledcourseid, int scheduledcourseid,int studentid,float grade)
        {
           
            this.StudentID = studentid;
            this.EnrolledCourseID = enrolledcourseid;
            this.ScheduledCourseID = scheduledcourseid;
            this.Grade = grade;
            this.ScheduledCourse = clsScheduledCourse.Find(scheduledcourseid);
            this.Student =clsStudent.FindStudentByID(studentid);
        }


        public static DataTable ListEnrolledCourses()
        {
            return clsEnrolledCourseData.GetEnrolledCourseslist();
        }

        public static DataTable ListEnrolledCoursesForTeacher(int scheduledcourseid)
        {
            return clsEnrolledCourseData.GetEnrolledCourseslistForTeacher(scheduledcourseid);
        }


        public static DataTable ListEnrolledCoursesForStudent(int studentid)
        {
            return clsEnrolledCourseData.GetEnrolledCourseslistForStudent(studentid);
        }

        public static bool DropCourse(int enrolledcourseid)
        {
            return clsEnrolledCourseData.DropCourse(enrolledcourseid);
        }

        public bool EnrollCourse()
        {
            this.EnrolledCourseID=clsEnrolledCourseData.EnrolllCourse(this.ScheduledCourseID,this.StudentID);
            return this.EnrolledCourseID != -1;
        }
        

        public static bool SetGrade(int enrolledcourseid,float grade)
        {
            return clsEnrolledCourseData.SetGrade(enrolledcourseid,grade);
        }

        public static clsEnrolledCourse Find(int enrolledcourseid)
        {
            int studentid = -1;
            int scheduledcourseid = -1;
            float grade = -1;

            if(clsEnrolledCourseData.FindEnrolledCourseByID(enrolledcourseid, ref scheduledcourseid, ref studentid, ref grade))
            {
                return new clsEnrolledCourse(enrolledcourseid,scheduledcourseid,studentid,grade);   
            }

            return new clsEnrolledCourse();
        }

        public static clsEnrolledCourse Find(int scheduledcourseid,int studentid)
        {
            
            int enrolledcourseid = -1;
            float grade = -1;

            if (clsEnrolledCourseData.FindEnrolledCourseByCourseAndStudentID(ref enrolledcourseid,  scheduledcourseid,  studentid, ref grade))
            {
                return new clsEnrolledCourse(enrolledcourseid, scheduledcourseid, studentid, grade);
            }

            return new clsEnrolledCourse();
        }

        public static bool IsStudentEnrolledInCourse(int studentid,int scheduledcourseid)
        {
            return clsEnrolledCourseData.IsStudentEnrolledInCourse(studentid,scheduledcourseid);
        }

        public static bool StudentHasGradeForCourse(int studentid,int scheduledcourseid)
        {
            return clsEnrolledCourseData.StudentHasGradeForCourse (scheduledcourseid, studentid);
        }
    }
}
