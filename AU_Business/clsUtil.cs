using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsUtil
    {

        public static List<object> DatatableToList(DataTable dt)
        {
            List<object> list = new List<object>();


            foreach (DataRow row in dt.Rows)
            {
                dynamic expando = new ExpandoObject();
                var expandoDict = (IDictionary<string, object>)expando;

                foreach (DataColumn column in dt.Columns)
                {
                 
                    expandoDict[column.ColumnName] = row[column];
                }

                list.Add(expando);
            }

            return list;
        }


    }
}
