
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsTuitionFeesData
    {

        public static int AddTuitions(int studentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into tuitionfees values (@studentid,0);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@studentid", studentid);

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


        public static bool UpdateTuitions(int studentid,double tuitions)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update TuitionFees set yearlypaid=@TuitionFeess where studentid=" + studentid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@TuitionFeess", tuitions);

            bool isupdated= false;

            try
            {
                connection.Open();

                int rowsaffected = sqlCommand.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;

        }

        public static bool FindByStudentID(int studentid,ref double tuitions,ref int tuitionid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from tuitionfees where studentid=" + studentid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound= false;    

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    tuitions = Convert.ToDouble(reader["yearlypaid"]);
                    tuitionid = Convert.ToInt32(reader["tuitionfeesid"]);
                    isfound = true;
                }

                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }

    }
}
