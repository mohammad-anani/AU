using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsNewsData
    {

        public static int AddNews(string title, string description, string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into news values" +
                " (@title,@desc,@image);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@desc", description);
            if(imagepath != "" )
            {
                command.Parameters.AddWithValue("@image", imagepath);
            }
            else
                command.Parameters.AddWithValue("@image",DBNull.Value);

            int newid = -1;

            try
            {
                connection.Open();

                object result= command.ExecuteScalar();

                if(result != null )
                {
                    newid=Convert.ToInt32(result);
                }
            }
            finally
            {
                connection.Close();

            }
            return newid;   
        }

        public static bool UpdateNews(int NewsID,string title, string description, string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update news set title=@title,description=@desc,imagepath=@image";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@desc", description);
            if (imagepath != "")
            {
                command.Parameters.AddWithValue("@image", imagepath);
            }
            else
                command.Parameters.AddWithValue("@image", DBNull.Value);

            bool isupdated= false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isupdated = true;
                }

            }
            finally {connection.Close(); }
            return isupdated;
        }

        public static DataTable ListNews()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from news order by newsid desc";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtnews=new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtnews.Load(reader);
                }    
                reader.Close();
            }
            finally { connection.Close(); }
            return dtnews;
        }

        public static bool FindNews(int NewsID,ref string title,ref string description,ref string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from news where newsid="+NewsID;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound= false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    title = (string)reader["title"];
                    description = (string)reader["description"];
                    imagepath = (string)reader["imagepath"];
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }
    }
}
