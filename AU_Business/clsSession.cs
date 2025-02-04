using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsSession
    {
        public static int AddSession(int scheduledcourseid,DateTime Date)
        {
            return clsSessionsData.AddNewSession(scheduledcourseid, Date);
        }

        public static bool GetStudentAttendance(int sessionid,int studentid,bool ispresent)
        {
            return clsSessionsData.GetStudentAttendance(sessionid, studentid,ispresent)!=-1;
        }

        public static DataTable ListSessionsForStudent(int studentid)
        {
            return clsSessionsData.ListSessionsForStudent(studentid);
        }

        public static DataTable ListStudentsAttendances(int scheduledcourseid)
        {
            return clsSessionsData.ListStudentsAttendance(scheduledcourseid);
        }

    }
}
