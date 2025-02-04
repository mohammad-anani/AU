using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsEnrolledCourseData
    {

        public static DataTable GetEnrolledCourseslist()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select EnrolledCourses.EnrolledCourseID,Courses.CourseName,Persons.FirstName+' '" +
                "+persons.SecondName+' '+\r\npersons.LastName AS StudentFullName,EnrolledCourses.Grade from EnrolledCourses" +
                " join ScheduledCourses\r\non EnrolledCourses.ScheduledCourseID=ScheduledCourses.ScheduledCourseID join" +
                " courses\r\non Courses.CourseID=ScheduledCourses.CourseID join students on students.studentid=EnrolledCourses.StudentID" +
                " join persons on students.personid=persons.personid";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtEnrolledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtEnrolledCourses.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtEnrolledCourses;
        }


        public static DataTable GetEnrolledCourseslistForTeacher(int scheduledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select EnrolledCourses.EnrolledCourseID,Persons.FirstName+' '\r\n      " +
                "          +persons.SecondName+' '+persons.LastName AS" +
                " StudentFullName,EnrolledCourses.Grade from EnrolledCourses\r\n     " +
                "            join  students on students.studentid=EnrolledCourses.StudentID\r\n  " +
                "join persons on persons.personid=students.personid " +
                "             where EnrolledCourses.ScheduledCourseID="+scheduledcourseid;

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtEnrolledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtEnrolledCourses.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtEnrolledCourses;
        }

        public static DataTable GetEnrolledCourseslistForStudent(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select EnrolledCourses.EnrolledCourseID,\r\n  " +
                "     Courses.CourseName,\r\n\t   Persons.FirstName+' '+ " +
                " persons.SecondName +' '+ persons.LastName AS StudentFullName,\r\n    " +
                "   TeacherName=(select Persons.FirstName+' '+Persons.LastName from persons\r\n    " +
                "               join teachers on Persons.PersonID=Teachers.PersonID where\r\n     " +
                "              Teachers.TeacherID=ScheduledCourses.TeacherID),\r\n   " +
                "    EnrolledCourses.Grade\r\n                 from EnrolledCourses\r\n " +
                "                join ScheduledCourses on" +
                " EnrolledCourses.ScheduledCourseID=ScheduledCourses.ScheduledCourseID\r\n\t\t\t\t" +
                " join courses on Courses.CourseID=ScheduledCourses.CourseID \r\n\t\t\t\t " +
                "join Students on EnrolledCourses.StudentID=Students.StudentID\r\n\t\t\t\t " +
                "join Persons on Persons.PersonID=Students.PersonID\r\n             " +
                "    join majorcourses on scheduledcourses.courseid=majorcourses.courseid \r\n  " +
                "               where enrolledcourses.studentid=@studentid order by majorcourses.enrollmentyear desc,enrolledcourses.grade asc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@studentid", studentid);

            DataTable dtEnrolledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtEnrolledCourses.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtEnrolledCourses;
        }


        public static int EnrolllCourse(int scheduledcourseid, int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into enrolledcourses values(@courseid,@studenid,null);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@courseid", scheduledcourseid);
            command.Parameters.AddWithValue("@studenid", studentid);

            int newid = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    newid = Convert.ToInt32(result);
                }

            }
            finally { connection.Close(); }
            return newid;
        }

        public static bool DropCourse(int enrolledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from enrolledcourses where enrolledcourseid=" + enrolledcourseid;

            SqlCommand command = new SqlCommand(query, connection);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isdeleted = true;
                }

            }
            finally { connection.Close(); }

            return isdeleted;
        }


        public static bool FindEnrolledCourseByID(int enrolledcourseid, ref int scheduledcourseid, ref int studentid, ref float Grade)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from enrolledcourses where enrolledcourseid=" + enrolledcourseid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    scheduledcourseid = Convert.ToInt32(reader["scheduledcourseid"]);
                    studentid = Convert.ToInt32(reader["studentid"]);
                    if (reader["grade"] != DBNull.Value)
                    {
                        Grade = Convert.ToSingle(reader["grade"]);
                    }
                    else
                        Grade = -1;
                    isfound = true;
                }


            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool FindEnrolledCourseByCourseAndStudentID(ref int enrolledcourseid,  int scheduledcourseid, int studentid, ref float Grade)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from enrolledcourses where scheduledcourseid=" + scheduledcourseid+" and studentid="+studentid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    enrolledcourseid = Convert.ToInt32(reader["enrolledcourseid"]);    
                    if (reader["grade"] != DBNull.Value)
                    {
                        Grade = Convert.ToSingle(reader["grade"]);
                    }
                    else
                        Grade = -1;
                    isfound = true;
                }


            }
            finally { connection.Close(); }
            return isfound;
        }


        public static bool SetGrade(int enrolledcourseid, float grade)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update enrolledcourses set grade=@grade where enrolledcourseid=" + enrolledcourseid;

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@grade", grade);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }

        public static bool IsStudentEnrolledInCourse(int studentid, int scheduledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from enrolledcourses where scheduledcourseid=@sid " +
                "and studentid=@studentid and (grade>=50 or grade is null)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@sid", scheduledcourseid);
            command.Parameters.AddWithValue("@studentid", studentid);

            bool isfound = false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isfound = true;
                }

            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool StudentHasGradeForCourse(int scheduledcourseid, int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select grade from enrolledcourses where studentid=@studentid and scheduledcourseid=@courseid order by grade asc";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.Parameters.AddWithValue("@courseid", scheduledcourseid);

            bool hasgrade = false;

            try
            {
                connection.Open();

               object result=cmd.ExecuteScalar();

             if(result != DBNull.Value)
                {
                    hasgrade = true;
                }
                


            }
            finally { connection.Close(); }
            return hasgrade;
        }
    }

}
