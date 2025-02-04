using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AU_Data
{
    public class clsBorrowingData
    {

        public static DataTable ListBorrowings(bool all)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select borrowings.borrowingid,books.BookName,studentFullName=Persons.FirstName+" +
                "' '+Persons.SecondName+' '+Persons.LastName,\r\nborrowings.DueDate from Borrowings\r\njoin Students on Students.StudentID=Borrowings" +
                ".StudentID\r\njoin Persons on Students.PersonID=Persons.PersonID\r\njoin books on" +
                " Books.BookID=Borrowings.BookID\r\n" + (all ? "": "where Borrowings.ReturnDate is null");

            SqlCommand cmd = new SqlCommand(query, connection);

            DataTable dtborrowings = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtborrowings.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtborrowings;
        }

        public static int AddBorrowing(int bookid, int studentid, DateTime borrowdate, DateTime DueDate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into borrowings values " +
                "(@book,@student,@date,@duedate,null,null,null);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            int newid = -1;

            command.Parameters.AddWithValue("@book", bookid);
            command.Parameters.AddWithValue("@student", studentid);
            command.Parameters.AddWithValue("@date", borrowdate);
            command.Parameters.AddWithValue("@duedate", DueDate);

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

        public static bool ReturnBook(int borrowid, DateTime returndate, double rating,double PaidFees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update borrowings set returndate=@date,rating=@rating,Paidfees=@fees where borrowingid=@id";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@date", returndate);
            sqlCommand.Parameters.AddWithValue("@rating", rating);
            sqlCommand.Parameters.AddWithValue("@id", borrowid);
            sqlCommand.Parameters.AddWithValue("@fees", PaidFees);
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

        public static bool FindBorrowing(int borrowid,ref int bookid,ref int studentid,ref DateTime borrowdate,ref DateTime duedate,ref DateTime returndate,ref double rating,ref double paidfees)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from borrowings where BorrowingID=" + borrowid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    bookid = Convert.ToInt32(reader["bookid"]);
                    studentid = Convert.ToInt32(reader["studentid"]);
                    borrowdate = Convert.ToDateTime(reader["borrowdate"]);
                    duedate = Convert.ToDateTime(reader["duedate"]);

                    if(reader["returndate"] != DBNull.Value)
              {      returndate = Convert.ToDateTime(reader["returndate"]);
                    paidfees = Convert.ToDouble(reader["paidfees"]);
                        rating = Convert.ToDouble(reader["rating"]);
                    }
                    isfound = true;
                }
                reader.Close();
            }
            finally { connection.Close();}
            return isfound;
        }
    }
}
