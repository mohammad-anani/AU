using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AU_Data
{
    public class clsCourseData
    {

        public static DataTable ListCourses()
        {

            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from courses";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            DataTable dtcourses = new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtcourses.Load(reader);
                }
            }
            finally { sqlConnection.Close(); }

            return dtcourses;
        }


        public static int AddCourse(string name, string description, int credits, int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into courses values(@name,@description,@credits,@depid);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@credits", credits);
            command.Parameters.AddWithValue("@depid", departmentid);

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

        public static bool UpdateCourse(int courseid, string name, string description, int credits, int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Update courses set coursename=@name,coursedescription=@description,coursecredits=@credits,departmentid=@depid" +
                " where courseid=" + courseid;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@credits", credits);
            command.Parameters.AddWithValue("@depid", departmentid);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }

        public static bool DeleteCourse(int courseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from exams where scheduledcourseid in (select scheduledcourseid from scheduledcourses where courseid=@id);delete from majorcourses where courseid=@id;delete from SessionAttendances where SessionID=(select SessionID from Sessions join ScheduledCourses\r\non Sessions.ScheduledCourseID=ScheduledCourses.ScheduledCourseID where ScheduledCourses.CourseID=@id)\r\ndelete from sessions where sessions.ScheduledCourseID=\r\n(select ScheduledCourseID from ScheduledCourses where ScheduledCourses.CourseID=@id)\r\ndelete from EnrolledCourses where EnrolledCourses.ScheduledCourseID=(select ScheduledCourseID from ScheduledCourses where CourseID=@id)\r\ndelete from ScheduledCourses where ScheduledCourses.CourseID=@id\r\ndelete from courses where courseid=@id";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", courseid);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }

            }
            finally { connection.Close(); }
            return isdeleted;
        }

        public static int GetCoursesCount()
        {
            return clsDataSettings.GetRowsCount("courses");
        }


        public static bool FindCourseByID(int courseid, ref string name, ref string desc, ref int credits, ref int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from courses where courseid=" + courseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    name = (string)reader["coursename"];
                    desc = (string)reader["coursedescription"];
                    credits = Convert.ToInt32(reader["coursecredits"]);
                    departmentid = Convert.ToInt32(reader["departmentid"]);
                    isfound = true;
                }
                reader.Close();
            }
            finally
            { connection.Close(); }

             return isfound;
        }

        public static bool FindCourseByName(ref int courseid,string name, ref string desc, ref int credits, ref int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from courses where coursename='" + name+"'";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    courseid = Convert.ToInt32( reader["courseid"]);
                    desc = (string)reader["coursedescription"];
                    credits = Convert.ToInt32(reader["coursecredits"]);
                    departmentid = Convert.ToInt32(reader["departmentid"]);
                    isfound = true;
                }
                reader.Close();
            }
            finally
            { connection.Close(); }

            return isfound;
        }

    }
    
}
