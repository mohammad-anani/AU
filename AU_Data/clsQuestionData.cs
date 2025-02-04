using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsQuestionData
    {

        public static int AddQuestion(int examid,int questionnumber,int rightanswer)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into questions values(@number,@examid,@rightanswer);select scope_identity();";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@number", questionnumber);
            command.Parameters.AddWithValue("@examid", examid);
            command.Parameters.AddWithValue("@rightanswer", rightanswer);

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

        public static DataTable GetAnswersList(int examid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select rightanswer from questions where examid="+examid+ " order by questionnumber ";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtanswers = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtanswers.Load(reader);
                }
                reader.Close();

            }
            finally { connection.Close(); }
            return dtanswers;
        }
    }
}
