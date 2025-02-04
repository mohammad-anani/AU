using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    internal class clsDataSettings
    {
        public static string ConnectionString = "server=.;database=AU;trusted_connection=true";

        public static int GetRowsCount(string tablename)
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select Count(*) from " + tablename ;

            SqlCommand command = new SqlCommand(query, sqlConnection);

           

            int rowscount = -1;

            try
            {
                sqlConnection.Open();

                object result= command.ExecuteScalar();

                if (result != null)
                {
                    rowscount=(int)result;
                }
            }
            finally { sqlConnection.Close(); }

            return rowscount;
        }

    }
}
