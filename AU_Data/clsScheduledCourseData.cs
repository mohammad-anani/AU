using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsScheduledCourseData
    {
        public static DataTable ListScheduledCoursesForAdministrator()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select scheduledcourses.scheduledcourseid,courses.CourseName," +
                "TeacherName=persons.firstname + ' '+persons.lastname" +
                ",Courses.CourseCredits,Status=case when scheduledcourses.status=1 then 'In Progress' when scheduledcourses.status=2" +
                " then 'Completed' else '' end " +
                " \r\nfrom scheduledCourses join Courses on " +
                "scheduledCourses.CourseID=Courses.CourseID " +
                "join teachers on teachers.teacherid=scheduledcourses.teacherid " +
                "join persons on teachers.personid=persons.personid";

            SqlCommand cmd = new SqlCommand(query, connection);

            DataTable dtScheduledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtScheduledCourses.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dtScheduledCourses;
        }

        public static DataTable ListScheduledCoursesForStudent(int studentid,int year)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select distinct scheduledcourses.scheduledcourseid,courses.CourseName,\r\n " +
                "         TeacherFullName=persons.firstname + ' '+persons.lastname,\r\n   " +
                "    Courses.CourseCredits\r\n       from scheduledCourses join Courses on\r\n   " +
                "       scheduledCourses.CourseID=Courses.CourseID\r\n          " +
                "    join teachers on teachers.teacherid=scheduledcourses.teacherid\r\n     " +
                "          join persons on teachers.personid=persons.personid \r\n " +
                " join MajorCourses on Courses.CourseID=MajorCourses.CourseID\r\n" +
                "  left join EnrolledCourses on EnrolledCourses.ScheduledCourseID=ScheduledCourses.ScheduledCourseID\r\n " +
                " left join students on Students.StudentID=EnrolledCourses.StudentID\r\nwhere " +
                "(MajorCourses.EnrollmentYear=@year and ScheduledCourses.Status=1)\r\nor(MajorCourses.EnrollmentYear<@year" +
                " and Courses.CourseID in (select ScheduledCourses.CourseID from EnrolledCourses join ScheduledCourses\r\non" +
                " EnrolledCourses.ScheduledCourseID=ScheduledCourses.ScheduledCourseID\r\nwhere EnrolledCourses.StudentID=@studentid" +
                " and grade<50) and ScheduledCourses.Status=1)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@studentid", studentid);

            DataTable dtScheduledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtScheduledCourses.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dtScheduledCourses;
        }


        public static DataTable ListScheduledCoursesForTeacher(int teacherid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select scheduledcourses.scheduledcourseid,courses.CourseName\r\n       " +
                "" +
                "                 \r\n                 from scheduledCourses join Courses on\r\n   " +
                "               scheduledCourses.CourseID=Courses.CourseID \r\n            " +
                "          join teachers on teachers.teacherid=scheduledcourses.teacherid\r\n     " +
                "                  join persons on teachers.personid=persons.personid\r\n       " +
                "        where scheduledcourses.status=1 and scheduledcourses.teacherid=" + teacherid;

            SqlCommand cmd = new SqlCommand(query, connection);

           

            DataTable dtScheduledCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtScheduledCourses.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dtScheduledCourses;
        }

        public static int ScheduleCourse(int courseid, int teacherid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into scheduledcourses values (@course,@teacher,1);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@course", courseid);
            command.Parameters.AddWithValue("@teacher", teacherid);

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


        public static bool CompleteScheduledCourse(int scheduledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update scheduledcourses set status=2 where scheduledcourseid=" + scheduledcourseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool ischanged = false;

            try
            {
                connection.Open();

                int rows = sqlCommand.ExecuteNonQuery();

                if (rows > 0)
                {
                    ischanged = true;
                }

            }
            finally { connection.Close(); }
            return ischanged;
        }

        public static bool RemoveScheduledCourse(int scheduledcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from exams where scheduledcourseid=@id;delete from SessionAttendances where SessionID=(select SessionID from Sessions where Sessions.ScheduledCourseID=@id);delete from sessions where sessions.ScheduledCourseID=@id\r\n\r\ndelete from EnrolledCourses where EnrolledCourses.ScheduledCourseID=@id\r\ndelete from ScheduledCourses where ScheduledCourseID=@id";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@id", scheduledcourseid);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = sqlCommand.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }
            }

            finally { connection.Close(); }
            return isdeleted;
        }

        public static int GetScheduledCoursesCount()
        {
            return clsDataSettings.GetRowsCount("ScheduledCourses");
        }


        public static bool FindScheduledCourseByID(int scheduledcourseid, ref int teacherid, ref int courseid, ref int status)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from scheduledcourses where scheduledcourseid=" + scheduledcourseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    teacherid = Convert.ToInt32(reader["teacherid"]);
                    courseid = Convert.ToInt32(reader["courseid"]);
                    status = Convert.ToInt32(reader["status"]);
                    isfound = true;
                }
                reader.Close();

            }
            finally { connection.Close(); }
            return isfound;
        }


    }
}
