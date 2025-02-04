using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AU_Data
{
    public class clsMajorData
    {

        public static DataTable GetMajorsList()
        {

            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from majorsview";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            DataTable dtMajors = new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMajors.Load(reader);
                }
            }
            finally { sqlConnection.Close(); }

            return dtMajors;

        }


        public static int GetMajorsCount()
        {
            return clsDataSettings.GetRowsCount("Majors");
        }

        public static int AddMajor(string name, int years, int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into majors values " +
                "(@name,@years,@depid);select scope_identity();";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@years", years);
            sqlCommand.Parameters.AddWithValue("@depid", departmentid);

            int newid = -1;

            try
            {
                connection.Open();

                object result = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    newid = Convert.ToInt32( result);
                }

            }
            finally { connection.Close(); }
            return newid;
        }


        public static bool UpdateMajor(int majorid, string name, int years, int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update majors set majorname=@name,completionyears=@years,departmentid=@id" +
                " where majorid=" + majorid;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@years", years);
            command.Parameters.AddWithValue("@id", departmentid);

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

        public static bool DeleteMajor(int majorid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from graduates where studentid=(select studentid from students where majorid=@id);delete from borrowings where studentid=(select studentid from students where majorid=@id);delete from tuitionfees where studentid=(select studentid where majorid=@id);delete from Applications where Applications.MajorID=@id\r\ndelete from MajorCourses where MajorID=@id\r\ndelete from students where Students.MajorID=@id\r\ndelete from Majors where MajorID=@id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", majorid);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }


            }
            finally { connection.Close(); }
            return isdeleted;
        }

        public static bool FindMajorByID(int majorid,ref string name,ref int years,ref string departmentname,ref int totalcourses,
            ref int totalcredits,ref float totalprice)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from majorsview where majorid=" + majorid;

            SqlCommand command =new SqlCommand(query, connection);

            bool isfound=false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    name = (string)reader["majorname"];
                    years = Convert.ToInt32(reader["completionyears"]);
                    departmentname = (string)(reader["departmentname"]);
                    if(Convert.ToInt32(reader["totalnumberofcourses"]) != 0)
                {    totalcourses = Convert.ToInt32(reader["totalnumberofcourses"]);
                    totalcredits = Convert.ToInt32(reader["totalcredits"]);
                        totalprice = Convert.ToSingle(reader["totalprice"]);
                    }
                }

                reader.Close();
            }
            finally{ connection.Close(); }
            return isfound;

        }

        public static bool FindMajorByName(ref int majorid,string name, ref int years, ref string departmentname, ref int totalcourses,
          ref int totalcredits, ref float totalprice)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from majorsview where majorname='"+name+"'";

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    majorid = Convert.ToInt32(reader["majorid"]);
                    years = Convert.ToInt32(reader["completionyears"]);
                    departmentname = (string)reader["departmentname"];
                    if (Convert.ToInt32(reader["totalnumberofcourses"])!=0)
                    {totalcourses = Convert.ToInt32(reader["totalnumberofcourses"]);
                    totalcredits = Convert.ToInt32(reader["totalcredits"]);
                        totalprice = Convert.ToSingle(reader["totalprice"]);
                    }
                }

                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;

        }
    }
}
