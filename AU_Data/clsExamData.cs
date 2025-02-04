using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsExamData
    {

        public static int AddExam(int scheduledcourseid,string code,int duration)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into exams values (@courseid,@code,@duration,0);" +
                "select scope_identity();";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@courseid", scheduledcourseid);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@duration",duration);

            int newid = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    newid = Convert.ToInt32(result);
                }

            }
            finally { connection.Close(); }
            return newid;
        }

        public static DataTable ListExamsForTeachers(int teacherid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select exams.code,Courses.CourseName,exams.duration," +
                "NumberOfQuestions=\r\n(select count(*) from questions where" +
                " examid=exams.examid)\r\nfrom exams join ScheduledCourses on" +
                " ScheduledCourses.ScheduledCourseID=exams.scheduledcourseid\r\njoin" +
                " courses on ScheduledCourses.CourseID=Courses.CourseID\r\nwhere  exams.istaken=0 and " +
                "ScheduledCourses.TeacherID=" + teacherid;

            SqlCommand command=new SqlCommand(query, connection);

            DataTable dtexams=new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtexams.Load(reader);
                }
                reader.Close();
            }
            finally{connection.Close(); }
            return dtexams;
        }

        public static DataTable ListExamsForStudents(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select scheduledcourses.scheduledcourseid,Courses.CourseName,exams.duration,NumberOfQuestions=" +
                "\r\n(select count(*) from questions where examid=exams.examid)\r\nfrom" +
                " exams\r\njoin ScheduledCourses on ScheduledCourses.ScheduledCourseID=" +
                "exams.scheduledcourseid\r\njoin courses on ScheduledCourses.CourseID=" +
                "Courses.CourseID\r\njoin EnrolledCourses on EnrolledCourses.ScheduledCourseID=" +
                "ScheduledCourses.ScheduledCourseID\r\nwhere exams.istaken=0 and EnrolledCourses.StudentID=" + studentid +" and enrolledcourses.grade is null";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtexams = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtexams.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtexams;
        }

        public static bool FindExamByCode(string code,ref int examid,ref int scheduledcourseid,ref int duration,ref int numberofquestions)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select exams.examid,exams.scheduledcourseid,exams.duration,NumberOfQuestions=\r\n" +
                "(select count(*) from questions where examid=exams.examid)" +
                "\r\nfrom exams\r\njoin ScheduledCourses on ScheduledCourses" +
                ".ScheduledCourseID=exams.scheduledcourseid\r\nwhere exams.code=@code";

            SqlCommand command= new SqlCommand(query, connection);

            bool isfound=false;

            command.Parameters.AddWithValue("@code", code);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    scheduledcourseid = Convert.ToInt32(reader["scheduledcourseid"]);
                    examid = Convert.ToInt32(reader["examid"]);
                    duration = Convert.ToInt32(reader["duration"]);
                    numberofquestions = Convert.ToInt32(reader["numberofquestions"]);
                    isfound = true;
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool FindExamByCode(string code, ref int examid, int scheduledcourseid, ref int duration, ref int numberofquestions)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select exams.examid,exams.scheduledcourseid,exams.duration,NumberOfQuestions=\r\n" +
                "(select count(*) from questions where examid=exams.examid)" +
                "\r\nfrom exams\r\njoin ScheduledCourses on ScheduledCourses" +
                ".ScheduledCourseID=exams.scheduledcourseid\r\nwhere exams.code=@code and exams.scheduledcourseid=" + scheduledcourseid;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            command.Parameters.AddWithValue("@code", code);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    scheduledcourseid = Convert.ToInt32(reader["scheduledcourseid"]);
                    examid = Convert.ToInt32(reader["examid"]);
                    duration = Convert.ToInt32(reader["duration"]);
                    numberofquestions = Convert.ToInt32(reader["numberofquestions"]);
                    isfound = true;
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }


        public static bool UpdateExam(string code,int duration,bool istaken)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update exams set duration=@duration,istaken=@istaken where code=@code";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isupdated=false;

            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@istaken", istaken);
            cmd.Parameters.AddWithValue("@code", code);

            try
            {
                connection.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }
    }
}
