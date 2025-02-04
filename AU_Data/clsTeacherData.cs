using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsTeacherData
    {

        public static int AddTeacher(int personid, string specialization)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into teachers values (@personid,@spec);Select Scope_Identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@spec", specialization);

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

        public static DataTable GetTeachersList()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select teachers.teacherid,TeacherFullName=persons.firstname  +' ' + " +
                "persons.lastname,teachers.specialization from teachers join persons on teachers.personid=persons.personid;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtTeachers = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtTeachers.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtTeachers;
        }

        public static int GetTeachersCount()
        {
            return clsDataSettings.GetRowsCount("Teachers");
        }

        public static bool FindTeacherByID(int teacherid, ref int personid, ref string specialization)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from teachers where teacherid=" + teacherid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    personid = Convert.ToInt32(reader["personid"]);
                    specialization = (string)reader["specialization"];
                }

                reader.Close();

            }
            finally { connection.Close(); }
            return isfound;
        }


        public static bool FindTeacherByPersonID(ref int teacherid, int personid, ref string specialization)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from teachers where personid=" + personid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    teacherid = Convert.ToInt32(reader["teacherid"]);
                    specialization = (string)reader["specialization"];
                }

                reader.Close();

            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool DeleteTeacher(int teacherid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from exams where scheduledcourseid in (select scheduledcourseid from scheduledcourses where teacherid=@id);delete from SessionAttendances where SessionID=(select SessionID from Sessions join ScheduledCourses on Sessions.ScheduledCourseID=ScheduledCourses.ScheduledCourseID\r\n where ScheduledCourses.TeacherID=@id)\r\ndelete from sessions where sessions.ScheduledCourseID=(select ScheduledCourseID from ScheduledCourses where ScheduledCourses.TeacherID=@id)\r\ndelete from EnrolledCourses where EnrolledCourses.ScheduledCourseID=(select ScheduledCourseID from ScheduledCourses where TeacherID=@id)\r\ndelete from ScheduledCourses where TeacherID=@id\r\ndelete from Teachers where TeacherID=@id"
                ;
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@id", teacherid);

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

        public static bool UpdateTeacher(int teacherid, string specialization)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update teachers set specialization=@spec where teacherid=" + teacherid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@spec", specialization);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rows = sqlCommand.ExecuteNonQuery();

                if (rows > 0)
                {
                    isupdated = true;
                }
            }
            finally { connection.Close(); }
            return isupdated;
        }
    }
}
