using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsMajorCourse
    {
        public int MajorCourseID { get; set; }

        public clsCourse Course { get; set; }
        public int CourseID { get; set; }

        public clsMajor Major {  get; set; }
        public int MajorID { get; set; }

        public int EnrollmentYear { get; set; }

        public clsMajorCourse()
        {
            this.MajorCourseID = -1;
            this.EnrollmentYear = -1;
            this.CourseID= -1;
            this.MajorID= -1;
            this.Major = new clsMajor();
            this.Course = new clsCourse();
        }

        public clsMajorCourse(int majorcourseid,int majorid,int courseid,int enrollmentyear)
        {
            this.MajorCourseID = majorcourseid;
            this.MajorID = majorid;
            this.EnrollmentYear = enrollmentyear;
            this.CourseID = courseid;
            this.MajorID = majorid;
            this.Major=clsMajor.Find(majorid);
            this.Course=clsCourse.Find(courseid);
        }

        public static DataTable ListMajorCourses()
        {
            return clsMajorCourseData.ListMajorCourses();
        }

        public bool AddMajorCourse()
        {

            this.MajorCourseID=clsMajorCourseData.AddMajorCourse(this.MajorID,this.CourseID,this.EnrollmentYear);

            return this.MajorCourseID != -1;
        }

        public static bool RemoveMajorCourse(int majorCourseID)
        {
            return clsMajorCourseData.RemoveMajorCourse(majorCourseID);
        }

        public static clsMajorCourse FindByCourse(int CourseID)
        {
            
            int EnrollmentYear = -1;
            int majorcourseid = -1;
            int MajorID = -1;

            if(clsMajorCourseData.FindMajorCourseByCourseID(ref majorcourseid,ref MajorID, CourseID,ref EnrollmentYear))
            {
                return new clsMajorCourse(majorcourseid, MajorID, CourseID, EnrollmentYear);
            }  
            return new clsMajorCourse();
        }

        public static clsMajorCourse FindById(int MajorCourseID)
        {

            int EnrollmentYear = -1;
            int courseid = -1;
            int MajorID = -1;

            if (clsMajorCourseData.FindMajorCourseByID( MajorCourseID, ref MajorID,ref courseid, ref EnrollmentYear))
            {
                return new clsMajorCourse(MajorCourseID, MajorID, courseid, EnrollmentYear);
            }
            return new clsMajorCourse();
        }

    }
}
