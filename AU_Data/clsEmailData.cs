using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsEmailData
    {

        public static DataTable GetSentEmailsList(int personid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Select emailsview.emailid,emailsview.senderusername,emailsview.receiverusername," +
                "emailsview.title from EmailsView join emails on emailsview.emailid=emails.emailid where emails.from_personid="+personid;

            SqlCommand command=new SqlCommand(query, connection);

            DataTable dtEmails = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtEmails.Load(reader);
                }
                reader.Close();
            }
        
            finally { connection.Close(); }

            return dtEmails;
        }

        public static DataTable GetReceivedEmailsList(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Select emailsview.* from EmailsView join emails on emailsview.emailid=emails.emailid where emails.to_personid=" + personid;

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtEmails = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtEmails.Load(reader);
                }
                reader.Close();
            }

            finally { connection.Close(); }

            return dtEmails;
        }

        public static DataTable GetUnopenedEmailsList(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Select emailsview.* from EmailsView join emails on emailsview.emailid=emails.emailid where emails.to_personid=" + personid +" and emails.IsOpen=0";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtEmails = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtEmails.Load(reader);
                }
                reader.Close();
            }

            finally { connection.Close(); }

            return dtEmails;
        }

        public static int SendEmail(int frompersonid, int topersonid, string title, string body)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into emails values (@from,@to,@title,@body,0);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@from", frompersonid);
            command.Parameters.AddWithValue("@to", topersonid);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@body", body);

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

        public static bool DeleteEmail(int emailid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from emails where emailid=" + emailid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }

            }
            finally { connection.Close(); }
            return isdeleted;
        }


        public static bool FindEmailByID(int id, ref int from, ref int to, ref string title, ref string body, ref bool isopen)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from emails where emailid=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    from = Convert.ToInt32(reader["from_personid"]);
                    to = Convert.ToInt32(reader["to_personid"]);
                    title = Convert.ToString(reader["Title"]);
                    body = Convert.ToString(reader["body"]);
                    isopen = (bool)reader["isopen"];
                    isfound = true;

                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
            
        }


        public static bool UpdateEmail(int emailid,string title,string body)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update emails set title=@title,body=@body where emailid=" + emailid;

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@body", body);

            bool isupdated=false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
}

        public static bool OpenEmail(int emailid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update emails set isopen=1 where emailid=" + emailid;

            SqlCommand cmd = new SqlCommand(query, connection);

           

            bool isupdated = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }
    }
}
