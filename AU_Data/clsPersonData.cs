using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AU_Data
{
    public class clsPersonData
    {
        public static int AddPerson(string firstname,string secondname,string lastname,string phone,DateTime dateofbirth,int gender,
            int countryid,string username,string password,string imagepath)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into persons values" +
                "(@firstname,@secondname,@lastname,@phone,@dateofbirth,@gender,@countryid,@username,@password,@imagepath);" +
                "select scope_identity();";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@secondname", secondname);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@countryid", countryid);
            command.Parameters.AddWithValue("@username",username);
            command.Parameters.AddWithValue("@password", password);
            if(imagepath != "")
            command.Parameters.AddWithValue("@imagepath", imagepath);
            else
            command.Parameters.AddWithValue("@imagepath", DBNull.Value);

            int newid=-1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    newid = Convert.ToInt32(result);
                }
             
                
            }
            finally {  connection.Close(); }    
            return newid;
        }

        public static bool FindPersonByID(int personid,ref string firstname,ref string secondname,ref string lastname,ref string phone,
            ref DateTime dateofbirth,ref int gender,ref int countryid,ref string username,ref string password,ref string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from persons where personid="+personid;

            SqlCommand command=new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    firstname = (string)reader["firstname"];
                    secondname = (string)reader["secondname"];
                    lastname = (string)reader["lastname"];
                    phone = (string)reader["phone"];
                    dateofbirth = (DateTime)( reader["dateofbirth"]);
                    gender = Convert.ToInt32(reader["gender"]);
                    countryid = (int)reader["countryid"];
                    username = (string)reader["username"];
                    password = (string)reader["password"];
                    if (reader["imagepath"] != DBNull.Value)
                        imagepath = (string)reader["imagepath"];
                    else
                        imagepath = "";
                }
               reader.Close();
            }
            finally
            {  connection.Close(); }
            return isfound;
        }


        public static bool FindPersonByUsernamePassword(ref int personid, ref string firstname, ref string secondname, ref string lastname, ref string phone,
           ref DateTime dateofbirth, ref int gender, ref int countryid,string username,string password, ref string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from persons where username=@username and password=@password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    personid = (int)reader["personid"];
                    firstname = (string)reader["firstname"];
                    secondname = (string)reader["secondname"];
                    lastname = (string)reader["lastname"];
                    phone = (string)reader["phone"];
                    dateofbirth = (DateTime)reader["dateofbirth"];
                    gender = Convert.ToInt32(reader["gender"]);
                    countryid = (int)reader["countryid"];
                  
                    if (reader["imagepath"] != DBNull.Value)
                        imagepath = (string)reader["imagepath"];
                    else
                        imagepath = "";
                }

                reader.Close();
            }
            finally
            { connection.Close(); }
            return isfound;
        }

        public static bool FindPersonByUsername(ref int personid, ref string firstname, ref string secondname, ref string lastname, ref string phone,
           ref DateTime dateofbirth, ref int gender, ref int countryid, string username,ref string password, ref string imagepath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from persons where username=@username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@username", username);
            

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    
                    personid = (int)reader["personid"];
                    firstname = (string)reader["firstname"];
                    secondname = (string)reader["secondname"];
                    lastname = (string)reader["lastname"];
                    phone = (string)reader["phone"];
                    dateofbirth = (DateTime)reader["dateofbirth"];
                    gender = Convert.ToInt32(reader["gender"]);
                    countryid = (int)reader["countryid"];
                    password= (string)reader["Password"];

                    if (reader["imagepath"] != DBNull.Value)
                        imagepath = (string)reader["imagepath"];
                    else
                        imagepath = "";
                }

                reader.Close();
            }
            finally
            { connection.Close(); }
            return isfound;
        }

        public static bool UpdatePerson(int personid, string firstname, string secondname, string lastname, string phone, DateTime dateofbirth, int gender,
            int countryid, string username, string password, string imagepath)
        {

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update persons " +
                "set firstname=@firstname,secondname=@secondname,lastname=@lastname,phone=@phone,dateofbirth=@dateofbirth," +
                "gender=@gender,countryid=@countryid,username=@username,password=@password,imagepath=@imagepath " +
                "where personid="+personid;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@secondname", secondname);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@countryid", countryid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            if (imagepath != "")
                command.Parameters.AddWithValue("@imagepath", imagepath);
            else
                command.Parameters.AddWithValue("@imagepath", DBNull.Value);

            bool isupdated= false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if(rowsaffected > 0)
                {
                    isupdated= true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }


        public static bool DeletePerson(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from Applications where PersonID=@id\r\ndelete from emails where To_PersonID=@id or From_PersonID=@id\r\ndelete from Persons where PersonID=@id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", personid);

            bool isdeleted= false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if(rowsaffected > 0)
                { 
                isdeleted= true;    
                }
            }
            finally { connection.Close(); }
            return isdeleted;
        }

        public static DataTable GetPersonsList()
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from personsview";

            SqlCommand command=new SqlCommand(query, sqlConnection); 

            DataTable dtPersons= new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtPersons.Load(reader);
                }
            }finally { sqlConnection.Close(); }

            return dtPersons;
        }

        public static DataTable GetUsernamesList()
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select username from persons";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            DataTable dtPersons = new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPersons.Load(reader);
                }
            }
            finally { sqlConnection.Close(); }

            return dtPersons;
        }

        public static int GetPersonsCount()
        {
            return clsDataSettings.GetRowsCount("Persons");
        }

      public static bool UsernameExists(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from persons where username=@username";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@username", username);

            bool exist= false;

            try
            {
                sqlConnection.Open();

                object result = sqlCommand.ExecuteScalar();

                if(result!=null)
                {
                    exist = true;
                }

            }
            finally { sqlConnection.Close(); }
            return exist;
        }


        public static DataTable GetUsernamesList(string query)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtusernames = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtusernames.Load(reader);
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return dtusernames;
        }

    }


}
