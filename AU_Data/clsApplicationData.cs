using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsApplicationData
    {
        public static DataTable ListApplications()
        {
            SqlConnection  connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applicationsview";

            SqlCommand command=new SqlCommand(query, connection);

            DataTable dtApplications=new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtApplications.Load(reader);
                }
                reader.Close();
            }
         
            finally { connection.Close(); }
        return dtApplications;
        
        }

        public static DataTable ListPreDeactivatedApplications()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applications where predeactivationdate is not null and\r\n " +
                           "                predeactivationdate<GETDATE()";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtApplications = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtApplications.Load(reader);
                }
                reader.Close();
            }

            finally { connection.Close(); }
            return dtApplications;

        }



        public static int AddApplication(int personid,DateTime applicationdate, float grade10avg,float grade11avg,string grade12school,int grade12specialization
            ,float grade12avg,float bacavg,int majorid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into applications values" +
                "(@personid,@applicationdate,@grade10avg,@grade11avg,@grade12school,@grade12specialization,@grade12avg,@bacavg,@majorid,1,null,null);" +
                "select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@applicationdate", applicationdate);
            command.Parameters.AddWithValue("@grade10avg", grade10avg);
            command.Parameters.AddWithValue("@grade11avg", grade11avg);
            command.Parameters.AddWithValue("@grade12school",grade12school);
            command.Parameters.AddWithValue("@grade12specialization",grade12specialization);
            command.Parameters.AddWithValue("@grade12avg",grade12avg);
            command.Parameters.AddWithValue("@bacavg",bacavg);
            command.Parameters.AddWithValue("@majorid",majorid);

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
            finally {  connection.Close(); }
            return newid;
        }

        public static bool ChangeStatus(int applicationid, int status)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update applications " +
                "set status=@status where applicationid=" + applicationid;

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@status", status);

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

        public static bool ChangePreDeactivationDate(int applicationid,DateTime Date)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update applications " +
                "set predeactivationdate=@date where applicationid=" + applicationid;

            SqlCommand cmd = new SqlCommand(query, connection);

            if(Date!=DateTime.MinValue)
            cmd.Parameters.AddWithValue("@date", Date);
            else
                cmd.Parameters.AddWithValue("@date", DBNull.Value);

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

        public static bool ChangeDeactivationDate(int applicationid, DateTime Date)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update applications " +
                "set deactivationdate=@date where applicationid=" + applicationid;

            SqlCommand cmd = new SqlCommand(query, connection);

            if (Date != DateTime.MinValue)
                cmd.Parameters.AddWithValue("@date", Date);
            else
                cmd.Parameters.AddWithValue("@date", DBNull.Value);

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

        public static bool FindApplicationByID(int applicationid,ref int personid,ref DateTime applicationdate,ref float grade10avg,
            ref float grade11avg,ref string grade12school,ref int grade12specialization,ref float grade12avg,ref float bacavg,
            ref int majorid,ref int status,ref DateTime predeactivationdate,ref DateTime deactivationdate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString) ;

            string query = "select * from applications where applicationid=" + applicationid;

           SqlCommand command = new SqlCommand(query, connection);

            bool isfound=false;

            try
            {
                connection.Open();

                SqlDataReader reader=command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    personid = Convert.ToInt32(reader["personid"]);
                    applicationdate = (DateTime)reader["applicationdate"];
                    grade10avg = Convert.ToSingle(reader["grade10avg"]);
                    grade11avg = Convert.ToSingle(reader["grade11avg"]);
                    grade12school = (string)reader["grade12school"];
                    grade12specialization = Convert.ToInt32(reader["grade12specialization"]);
                    grade12avg = Convert.ToSingle(reader["grade12avg"]);
                    bacavg = Convert.ToSingle(reader["bacavg"]);
                    majorid = Convert.ToInt32(reader["majorid"]);
                    status = Convert.ToInt32(reader["status"]);
                    if(reader["predeactivationdate"]!=DBNull.Value)
                   { predeactivationdate = (DateTime)reader["predeactivationdate"]; }
                    if(reader["deactivationdate"] != DBNull.Value)
                   { deactivationdate = (DateTime)reader["deactivationdate"]; }
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool FindApplicationByPersonID(ref int applicationid, int personid, ref DateTime applicationdate, ref float grade10avg,
           ref float grade11avg, ref string grade12school, ref int grade12specialization, ref float grade12avg, ref float bacavg,
           ref int majorid, ref int status, ref DateTime predeactivationdate, ref DateTime deactivationdate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applications where personid = " + personid;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    applicationid = Convert.ToInt32(reader["applicationid"]);
                    applicationdate = (DateTime)reader["applicationdate"];
                    grade10avg = Convert.ToSingle(reader["grade10avg"]);
                    grade11avg = Convert.ToSingle(reader["grade11avg"]);
                    grade12school = (string)reader["grade12school"];
                    grade12specialization = Convert.ToInt32(reader["grade12specialization"]);
                    grade12avg = Convert.ToSingle(reader["grade12avg"]);
                    bacavg = Convert.ToSingle(reader["bacavg"]);
                    majorid = Convert.ToInt32(reader["majorid"]);
                    status = Convert.ToInt32(reader["status"]);
                    if (reader["predeactivationdate"] != DBNull.Value)
                    { predeactivationdate = (DateTime)reader["predeactivationdate"]; }
                    if (reader["deactivationdate"] != DBNull.Value)
                    { deactivationdate = (DateTime)reader["deactivationdate"]; }
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool DeleteApplication(int applicationid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from applications where applicationid=" + applicationid;

            SqlCommand command = new SqlCommand(query, connection);

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

        public static int GetApplicationsCount()
        {
            return clsDataSettings.GetRowsCount("Applications");
        }
    }
}
