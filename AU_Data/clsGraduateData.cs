using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsGraduateData
    {

        public static int AddGraduate(int studentit,DateTime date)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into graduates values (@studentid,@date);select scope_identity();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@studentid", studentit);
            cmd.Parameters.AddWithValue("@date", date);

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
            finally
            {
                connection.Close();
            }
                return newid;
            
        }


        public static DataTable ListGraduates()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select graduates.studentid,StudentFullName=Persons.FirstName+' '+Persons.SecondName+' '+Persons.LastName,\r\ngraduates.graduationdate from graduates join students\r\non graduates.studentid=Students.StudentID\r\njoin Persons\r\non Persons.PersonID=Students.PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            DataTable dtgrads=new DataTable();

            try
            {

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtgrads.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtgrads;

        }

        public static bool IsStudentGraduate(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from graduates where studentid=" + studentid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isgrad = false;

            try
            {
                connection.Open();

                object result = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    isgrad = true;
                }

            }
            finally { connection.Close(); }
            return isgrad;
        }

    }
}
