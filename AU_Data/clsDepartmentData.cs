using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Data
{
    public class clsDepartmentData
    {
        public static DataTable GetDepartmentsList()
        {
         
            SqlConnection sqlConnection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from departments";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            DataTable dtDepartments = new DataTable();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDepartments.Load(reader);
                }
            }
            finally { sqlConnection.Close(); }

            return dtDepartments;
       
        }

        public static bool FindDepartmentByID(int departmentid,ref string name,ref float pricepercredit)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from departments where departmentid=" + departmentid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound=false; 

            try
            {
                connection.Open();

                SqlDataReader reader= cmd.ExecuteReader();

                if(reader.Read())
                {
                    isfound=true;
                    name = (string)reader["departmentname"];
                    pricepercredit = Convert.ToSingle(reader["pricepercredit"]);
                }


            }
            finally {  connection.Close(); }    

            return isfound;
        }

        public static bool FindDepartmentByName(ref int departmentid, string name, ref float pricepercredit)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from departments where departmentname=@name";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@name", name);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    departmentid= (int)reader["departmentid"];
                    pricepercredit = Convert.ToSingle( reader["pricepercredit"]);
                }


            }
            finally { connection.Close(); }

            return isfound;
        }

        public static int GetDepartmentsCount()
        {
            return clsDataSettings.GetRowsCount("Departments");
        }

        public static int AddDepartment(string name,float pricepercredit)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into departments values " +
                "(@name,@ppc);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@ppc", pricepercredit);

            int newid = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null) {
                    newid = Convert.ToInt32( result);
                }

            }
            finally { connection.Close(); }
            return newid;
        }

        public static bool UpdateDepartment(int departmentid,string name,float pricepercredit)
        {
            SqlConnection connection = new SqlConnection( clsDataSettings.ConnectionString);

            string query = "update departments set departmentname=@name,pricepercredit=@ppc " +
                "where departmentid="+departmentid;

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@ppc", pricepercredit);

            bool isupdated=false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected >0)
                {
                    isupdated = true;
                }

            }
            finally { connection.Close(); }
            return isupdated;
        }

        public static bool DeleteDepartment(int departmentid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "\r\n\r\ndelete from exams where scheduledcourseid in" +
                " (select scheduledcourseid from scheduledcourses where courseid" +
                " in (select courseid from courses where departmentid=@depid));" +
                "delete from graduates where studentid in (select studentid from" +
                " students where majorid=(select majorid from majors where" +
                " departmentid=@depid));delete from borrowings where studentid" +
                " in(select studentid from students where majorid=(select majorid " +
                "from majors where departmentid=@depid));delete from tuitionfees" +
                " where studentid=(select studentid from students where majorid" +
                "=(select majorid from majors where departmentid=@depid));delete" +
                " from Applications where Applications.MajorID=(select MajorID" +
                " from Majors where DepartmentID=@depid)\r\ndelete from SessionAttendances" +
                " where SessionID=(select SessionID from Sessions join ScheduledCourses\r\n " +
                "      on Sessions.ScheduledCourseID=ScheduledCourses.ScheduledCourseID join Courses " +
                "on ScheduledCourses.CourseID=Courses.CourseID\r\n   " +
                "    where Courses.DepartmentID=@depid)\r\ndelete from sessions" +
                " where sessions.ScheduledCourseID=\r\n   " +
                "    (select ScheduledCourseID from ScheduledCourses join Courses" +
                " on ScheduledCourses.CourseID=Courses.CourseID\r\n    " +
                "   where Courses.DepartmentID=@depid)\r\ndelete from EnrolledCourses" +
                " where EnrolledCourses.ScheduledCourseID=(select ScheduledCourseID fr" +
                "om ScheduledCourses join Courses on ScheduledCourses.CourseID=Courses." +
                "CourseID\r\n       where Courses.DepartmentID=@depid)\r\ndelete from" +
                " ScheduledCourses where ScheduledCourses.CourseID=(select CourseID from" +
                " Courses where DepartmentID=@depid)\r\ndelete from MajorCourses where" +
                " MajorCourses.MajorID=(select MajorID from Majors where DepartmentID=@depid)\r\n" +
                "                               or MajorCourses.CourseID=(select CourseID from Courses" +
                " where DepartmentID=@depid)\r\ndelete from students where Students.MajorID=(select" +
                " MajorID from Majors where DepartmentID=@depid)\r\ndelete from courses where" +
                " DepartmentID=@depid\r\ndelete from Majors where  DepartmentID=@depid\r\ndelete " +
                "from Departments where DepartmentID=@depid\r\n";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@depid", departmentid);

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


    }
}
