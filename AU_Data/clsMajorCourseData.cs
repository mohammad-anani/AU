using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsMajorCourseData
    {

        public static DataTable ListMajorCourses()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select majorcourses.majorcourseid,courses.CourseName,Majors.MajorName,Courses.CourseCredits" +
                ",MajorCourses.EnrollmentYear\r\nfrom MajorCourses join Courses on " +
                "MajorCourses.CourseID=Courses.CourseID\r\njoin majors on Majors.MajorID=MajorCourses.MajorID";

            SqlCommand cmd = new SqlCommand(query, connection);

            DataTable dtMajorCourses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMajorCourses.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dtMajorCourses;
        }

        public static int AddMajorCourse(int majorid, int courseid, int enrollmentyear)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into majorcourses values (@major,@course,@year);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@major", majorid);
            command.Parameters.AddWithValue("@course", courseid);
            command.Parameters.AddWithValue("@year", enrollmentyear);

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

        public static bool RemoveMajorCourse(int majorcourseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from majorcourses where majorcourseid=" + majorcourseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

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

        public static bool FindMajorCourseByCourseID(ref int majorcourseid, ref int majorid, int courseid, ref int enrollmentyear)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from majorcourses where courseid=" + courseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    majorid = Convert.ToInt32(reader["majorid"]);
                    majorcourseid = Convert.ToInt32(reader["majorcourseid"]);
                    enrollmentyear = Convert.ToInt32(reader["enrollmentyear"]);
                    isfound = true;
                }
                reader.Close();

            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool FindMajorCourseByID( int majorcourseid, ref int majorid,ref int courseid, ref int enrollmentyear)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from majorcourses where majorcourseid=" + majorcourseid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    majorid = Convert.ToInt32(reader["majorid"]);
                    courseid = Convert.ToInt32(reader["courseid"]);
                    enrollmentyear = Convert.ToInt32(reader["enrollmentyear"]);
                    isfound = true;
                }
                reader.Close();

            }
            finally { connection.Close(); }
            return isfound;
        }
    }
}
