using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsStudentData
    {
        public static int GetStudentsCount()
        {
            return clsDataSettings.GetRowsCount("students");
        }

        public static DataTable GetStudentsList()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "SELECT Students.StudentID,StudentFullName=\r\n" +
                "Persons.FirstName+' '+Persons.SecondName+' '+Persons.LastName," +
                "\r\nMajors.MajorName, Students.AcademicYear\r\nFROM  " +
                "   Students INNER JOIN\r\n                 " +
                " Persons ON Students.PersonID = Persons.PersonID INNER JOIN\r\n        " +
                "          Majors ON Students.MajorID = Majors.MajorID  " +
                " left outer join Graduates\r\non Students.StudentID=Graduates.StudentID" +
                " where Graduates.StudentID is null";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtStudents = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtStudents.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }

            return dtStudents;
        }

        public static int AddStudent(int personid, int majorid,int scholarship)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into students values (@personid,@majorid,1,@scholarship);select scope_identity()";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@personid", personid);
            cmd.Parameters.AddWithValue("@scholarship", scholarship);
            cmd.Parameters.AddWithValue("@majorid", majorid);

            int newid = -1;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    newid = Convert.ToInt32(result);
                }

            }
            finally { connection.Close(); }
            return newid;
        }

        public static bool ChangeAcademicYear(int studentid, int newyear,int scholarship)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update students set academicyear=@newyear,scholarship=@scholarship where studentid=@studentid";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@newyear", newyear);
            command.Parameters.AddWithValue("@studentid", studentid);
            if (scholarship !=-1) 
           { command.Parameters.AddWithValue("@scholarship", scholarship); }
            else
                command.Parameters.AddWithValue("@scholarship", DBNull.Value);

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

        public static bool DeleteStudent(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from tuitionfees where studentid=@id;delete from graduates where studentid=@id;delete from borrowings where studentid=@id;delete from SessionAttendances where StudentID=@id\r\n delete from EnrolledCourses where EnrolledCourses.StudentID=@id\r\ndelete from Students where StudentID=@id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", studentid);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsfaffected = cmd.ExecuteNonQuery();

                if (rowsfaffected > 0)
                {

                    isdeleted = true;
                }

            }
            finally { connection.Close(); }
            return isdeleted;
        }

        public static bool FindStudentByID(int studentid,ref int personid,ref int majorid,ref int academicyear,
            ref int yearpassedcourses,ref int totalpassedcourses,ref int yearrequiredcourses,ref int totalrequiredcourses,ref double yearprice,ref double cgpa,ref int scholarship)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from studentsview where studentid=" + studentid;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    personid = Convert.ToInt32(reader["personid"]);
                    majorid = Convert.ToInt32(reader["majorid"]);
                    academicyear = Convert.ToInt32(reader["academicyear"]);
                    yearpassedcourses = Convert.ToInt32(reader["yearpassedcourses"]);
                    yearrequiredcourses = Convert.ToInt32(reader["yearrequiredcourses"]);
                    totalpassedcourses = Convert.ToInt32(reader["totalpassedcourses"]);
                    totalrequiredcourses = Convert.ToInt32(reader["totalrequiredcourses"]);

                    if (reader["yearprice"] != DBNull.Value)
                    { yearprice = Convert.ToDouble(reader["yearprice"]); }

                    if (reader["cumulativegpa"] != DBNull.Value)
                        cgpa = Convert.ToDouble(reader["cumulativegpa"]);

                    if (reader["scholarship"]!=DBNull.Value)
                    scholarship=Convert.ToInt32(reader["scholarship"]);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;

        }

        public static bool FindStudentByPersonID(ref int studentid,int personid,ref int majorid,ref int academicyear,
             ref int yearpassedcourses, ref int totalpassedcourses, ref int yearrequiredcourses, ref int totalrequiredcourses, ref double yearprice,ref double cgpa,ref int scholarship)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from studentsview where personid=" + personid;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    studentid = Convert.ToInt32(reader["studentid"]);
                    majorid = Convert.ToInt32(reader["majorid"]);
                    academicyear = Convert.ToInt32(reader["academicyear"]);
                    yearpassedcourses = Convert.ToInt32(reader["yearpassedcourses"]);
                    yearrequiredcourses = Convert.ToInt32(reader["yearrequiredcourses"]);
                    totalpassedcourses = Convert.ToInt32(reader["totalpassedcourses"]);
                    totalrequiredcourses = Convert.ToInt32(reader["totalrequiredcourses"]);
                    if (reader["yearprice"]!=DBNull.Value)
                    { yearprice = Convert.ToDouble(reader["yearprice"]); }

                    if (reader["cumulativegpa"] != DBNull.Value)
                        cgpa = Convert.ToDouble(reader["cumulativegpa"]);

                    if(reader["scholarship"]!=DBNull.Value)
                    scholarship = Convert.ToInt32(reader["scholarship"]);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;

        }
    }
}
