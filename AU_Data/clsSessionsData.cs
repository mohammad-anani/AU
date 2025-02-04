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
    public class clsSessionsData
    {
        public static  int AddNewSession(int scheduledCourseID, DateTime SessionDate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into sessions values (@courseid,@date);" +
                "select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@courseid", scheduledCourseID);
            command.Parameters.AddWithValue("@date", SessionDate);

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

        public static int GetStudentAttendance(int sessionid, int studentid, bool ispresent)
        {
          SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

        string query = "insert into sessionattendances values (@session,@student,@ispresent);" +
            "select scope_identity();";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@session", sessionid);
        command.Parameters.AddWithValue("@student", studentid);
        command.Parameters.AddWithValue("@ispresent", ispresent);

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

        public static DataTable ListSessionsForStudent(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select courses.CourseName,TeacherFullName=persons.firstname + " +
                "' '+persons.lastname,Sessions.SessionDate\r\n,SessionAttendances.IsPresent\r\n\r\n" +
                "from SessionAttendances join Sessions on SessionAttendances.SessionID=Sessions.SessionID\r" +
                "\njoin ScheduledCourses on Sessions.ScheduledCourseID=ScheduledCourses.ScheduledCourseID\r" +
                "\njoin Courses on ScheduledCourses.CourseID=Courses.CourseID\r\njoin teachers on" +
                " Teachers.TeacherID=ScheduledCourses.TeacherID\r\njoin Persons on " +
                "Teachers.PersonID=Persons.PersonID\r\nwhere " +
                " SessionAttendances.StudentID=" + studentid;

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtsessions=new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtsessions.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtsessions;

        }


        public static DataTable ListStudentsAttendance(int scheduledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select Students.StudentID,StudentFullName=persons.firstname +' '\r\n    " +
                "                   +Persons.SecondName+ ' '+persons.lastname\r\n       " +
                "             from EnrolledCourses join Students on         \r\n    " +
                "             Students.StudentID=EnrolledCourses.StudentID join Persons on\r\n " +
                "                       students.PersonID=Persons.PersonID where\r\n    " +
                "                       EnrolledCourses.ScheduledCourseID=" + scheduledcourseid;

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtstudents = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtstudents.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtstudents;

        }
    }
}
