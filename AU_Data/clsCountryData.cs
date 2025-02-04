using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsCountryData
    {
        public static DataTable GetCountriesList()
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from countries";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            DataTable dtCountries = new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtCountries.Load(reader);
                }
            }
            finally { sqlConnection.Close(); }

            return dtCountries;

        }

        public static bool FindCountryByID(int countryId,ref string countryname)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select countryname from countries where countryid=" + countryId;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound= false;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if(result != null)
                {
                    isfound = true;
                    countryname = (string)result;
                }


            }
            finally { connection.Close(); }
            return isfound;
        }


        public static bool FindCountryByName(ref int countryid,string countryname)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select countryid from countries where countryname=@countryname";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@countryname", countryname);

            bool isfound = false;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    isfound = true;
                    countryid = (int)result;
                }


            }
            finally { connection.Close(); }
            return isfound;
        }
    }
}
