using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsScheduledCourse
    {
        public int ScheduledCourseID { get; set; }

        public int CourseID { get; set; }

        public clsCourse Course { get; set; }
        public int TeacherID { get; set; }

        public clsTeacher Teacher { get; set; }
        public string Status { get; set; }

        public clsScheduledCourse()
        {
            this.ScheduledCourseID = -1;
            this.CourseID = -1;
            this.TeacherID = -1;
            this.Status = "";
            this.Course=new clsCourse();
            this.Teacher = new clsTeacher();
        }

        private clsScheduledCourse(int scheduledCourseID, int courseID, int TeacherID, string Status)
        {
            this.CourseID=courseID;
            this.ScheduledCourseID=scheduledCourseID;
            this.TeacherID=TeacherID;
            this.Status=Status;
            this.Teacher=clsTeacher.FindTeacherByID(TeacherID);
            this.Course=clsCourse.Find(courseID);
            
        }

        public static string ConvertStatus(int status)
        {
            switch (status)
            {
                case 1:
                    return "In Progress";
                case 2:
                    return "Completed";
                default:
                    return "";
            }

        }

        public static DataTable ListScheduledCoursesForAdministrator()
        {
            return clsScheduledCourseData.ListScheduledCoursesForAdministrator();
        }

        public static DataTable ListScheduledCoursesForteacher(int teacherid)
        {
            return clsScheduledCourseData.ListScheduledCoursesForTeacher(teacherid);
        }

        public static DataTable ListScheduledCoursesForStudent(int studentid)
        {
            return clsScheduledCourseData.ListScheduledCoursesForStudent(studentid);
        }

        public bool ScheduleCourse()
        {
            this.ScheduledCourseID=clsScheduledCourseData.ScheduleCourse(this.CourseID,this.TeacherID);

            return this.ScheduledCourseID != -1;
        }

        public static bool CompleteScheduledCourse(int scheduledcourseid)
        {
            return clsScheduledCourseData.CompleteScheduledCourse(scheduledcourseid);
        
        }

        public static int GetScheduledCoursesCount()
        {
            return clsScheduledCourseData.GetScheduledCoursesCount();
        }

        public static clsScheduledCourse Find(int scheduledcourseid)
        {
            int CourseID = -1;
            int TeacherID = -1;
            int Status = -1;

            if(clsScheduledCourseData.FindScheduledCourseByID(scheduledcourseid,ref TeacherID,ref CourseID,ref  Status))
            {
                return new clsScheduledCourse(scheduledcourseid,CourseID,TeacherID,ConvertStatus(Status));
            }
            return new clsScheduledCourse();
        }

        public static bool RemoveScheduledCourse(int scheduledcourseid)
        {
            return clsScheduledCourseData.RemoveScheduledCourse(scheduledcourseid);
        }




    }
}
