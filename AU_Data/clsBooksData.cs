using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsBooksData
    {
        public static int AddBook(string bookname, string bookauthor, int numberofcopies)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into books values(@name,@author,@copies);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", bookname);
            command.Parameters.AddWithValue("@author", bookauthor);
            command.Parameters.AddWithValue("@copies", numberofcopies);

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

        public static bool UpdateBook(int bookid, string bookname, string bookauthor, int numberofcopies)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update books set bookname=@name,bookauthor=@author,numberofcopies=@copies where bookid=" + bookid;


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", bookname);
            command.Parameters.AddWithValue("@author", bookauthor);
            command.Parameters.AddWithValue("@copies", numberofcopies);

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

        public static bool FindBook(int bookid, ref string bookname, ref string bookauthor, ref int numberofcopies,ref int availablecopies)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from booksview where bookid=" + bookid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    bookname = reader["bookname"].ToString();
                    bookauthor = reader["bookauthor"].ToString();
                    numberofcopies = Convert.ToInt32(reader["numberofcopies"]);
                    availablecopies = Convert.ToInt32(reader["availablecopies"]);
                    isfound = true;

                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }


        public static DataTable ListBooks()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select bookid,bookname,bookauthor,availablecopies,Rating from booksview";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            DataTable table = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    table.Load(reader);
                }

                reader.Close();

            }
            finally { connection.Close(); }
            return table;
        }


        public static bool DeleteBook(int bookid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from borrowings where bookid=" + bookid + ";delete from books where bookid=" + bookid;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rows = sqlCommand.ExecuteNonQuery();

                if (rows > 0)
                {
                    isdeleted = true;
                }
            }
            finally { connection.Close(); }
            return isdeleted;
        }

    }
}
