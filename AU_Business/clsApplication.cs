using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int PersonID { get; set; }

        public clsPerson Person { get; set; }

        public DateTime ApplicationDate { get; set; }

        public float Grade10avg { get; set; }

        public float Grade11avg { get;set; }

        public string Grade12School { get; set; }

        public string Grade12Specialization { get; set; }
        public float Grade12avg { get;set;}

        public float Bacavg { get; set; }

        public int MajorID { get; set; }

        public clsMajor Major { get; set; }

        public string Status { get; set; }

        public DateTime PreDeactivationDate { get; set; }

        public DateTime DeactivationDate { get; set; }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.PersonID = -1;
            this.Person = new clsPerson();
            this.ApplicationDate = DateTime.MinValue;
            this.Grade10avg = -1;
            this.Grade11avg = -1;
            this.Grade12avg = -1;
            this.Bacavg = -1;
            this.MajorID = -1;
            this.Major = new clsMajor();
            this.Grade12School = "";
            this.Grade12Specialization = "";
            this.PreDeactivationDate = DateTime.MinValue;
            this.DeactivationDate = DateTime.MinValue;
            this.Status = "";
        }

        private clsApplication(int applicationID, int personID, DateTime applicationDate, float grade10avg, float grade11avg, string grade12School, string grade12Specialization, float grade12avg, float bacavg, int majorID, string status, DateTime preDeactivationDate, DateTime deactivationDate)
        {
            this.ApplicationID = applicationID;
            this.PersonID = personID;
            this.Person=clsPerson.Find(personID);
            this.ApplicationDate = applicationDate;
            this.Grade10avg = grade10avg;
            this.Grade11avg = grade11avg;
            this.Grade12School = grade12School;
            this.Grade12Specialization = grade12Specialization;
            this.Grade12avg = grade12avg;
            this.Bacavg = bacavg;
            this.MajorID = majorID;
            this.Major = clsMajor.Find(majorID);
            this.Status = status;
            this.PreDeactivationDate = preDeactivationDate;
            this.DeactivationDate = deactivationDate;
        }

        public static DataTable ListApplications()
        {
            return clsApplicationData.ListApplications();
        }

        public static DataTable ListPreDeactivatedApplications()
        {
            return clsApplicationData.ListPreDeactivatedApplications();
        }

        public static int GetApplicationsCount()
        {
            return clsApplicationData.GetApplicationsCount();
        }


        public static string ConvertStatus(int status)
        {

            switch (status)
            {
                case 1:
                    return "New";
                case 2:
                    return "Rejected";
                    case 3:
                    return "Accepted";
                    case 4:
                    return "Completed";
                default:
                    return "";
            }

        }


        public  static int ConvertStatus(string status)
        {

            switch (status)
            {
                case "New":
                    return 1;
                case "Rejected":
                    return 2;
                case "Accepted":
                    return 3;
                case "Completed":
                    return 4;
                default:
                    return -1;
            }

        }


        public static int ConvertGrade12Specialization(string spec)
        {
            switch (spec)
            {
                case "Life Sciences":
                    return 1;
                        case "General Sciences":
                    return 2;
                case "Sociology And Economics":
                    return 3;
                case "Litterature And Humanities":
                    return 4;


                default:
                    return -1;
            }

        }

        public static string ConvertGrade12Specialization(int spec)
        {
            switch (spec)
            {
                case 1:
                    return "Life Sciences";
                case 2:
                    return "General Sciences";
                case 3:
                    return "Sociology And Economics";
                case 4:
                    return "Litterature And Humanities";


                default:
                    return "";
            }

        }

        public bool AddApplication()
        {
            this.ApplicationID = clsApplicationData.AddApplication(this.PersonID,this.ApplicationDate,this.Grade10avg,
                this.Grade11avg,this.Grade12School,ConvertGrade12Specialization(this.Grade12Specialization),this.Grade12avg,this.Bacavg,this.MajorID);

            return this.ApplicationID != -1;
        }

        public bool RejectApplication()
        {
            this.Status = "Rejected";
            return clsApplicationData.ChangeStatus(this.ApplicationID, 2);
        }

        public bool AcceptApplication()
        {
            this.Status = "Accepted";
            return clsApplicationData.ChangeStatus(this.ApplicationID, 3);
        }

        public bool CompleteApplication()
        {
            this.Status = "Completed";
            return clsApplicationData.ChangeStatus(this.ApplicationID, 4);
        }

        public bool CancelRejection()
        {
            this.Status = "New";
            return clsApplicationData.ChangeStatus(this.ApplicationID, 1);
        }

        public bool SetDeactivationDate()
        {
            return clsApplicationData.ChangeDeactivationDate(this.ApplicationID, DateTime.Now.AddDays(30));
        }

        public bool SetPreDeactivationDate()
        {
            return clsApplicationData.ChangePreDeactivationDate(this.ApplicationID, DateTime.Now.AddDays(30));
        }

        public bool CancelPreDeactivationDate()
        {
            return clsApplicationData.ChangePreDeactivationDate(this.ApplicationID, DateTime.MinValue);
        }

        public bool CancelDeactivationDate()
        {
            return clsApplicationData.ChangeDeactivationDate(this.ApplicationID, DateTime.MinValue);
        }

        public static bool DeleteApplication(int applicationID)
        {
            return clsApplicationData.DeleteApplication(applicationID);
        }

        public static clsApplication FindByApplicationID(int applicationID)
        {
          
            int PersonID = -1;
            DateTime ApplicationDate = DateTime.MinValue;
           float Grade10avg = -1;
            float Grade11avg = -1;
            float Grade12avg = -1;
            float Bacavg = -1;
            int MajorID = -1;
            string Grade12School = "";
            int Grade12Specialization = -1;
            DateTime PreDeactivationDate = DateTime.MinValue;
            DateTime DeactivationDate = DateTime.MinValue;
            int status = -1;

            if(clsApplicationData.FindApplicationByID(applicationID,ref PersonID,ref ApplicationDate,ref  Grade10avg,ref  Grade11avg,ref Grade12School
                ,ref Grade12Specialization,ref Grade12avg,ref Bacavg,
               ref MajorID,ref status,ref PreDeactivationDate,ref DeactivationDate))
            {
                return new clsApplication(applicationID,PersonID,ApplicationDate,Grade10avg,Grade11avg,Grade12School,
                    ConvertGrade12Specialization(Grade12Specialization),Grade12avg,Bacavg,MajorID,ConvertStatus(status)
                    ,PreDeactivationDate,DeactivationDate);
            }
            return new clsApplication();
        }

        public static clsApplication FindByPersonID(int personID)
        {
            int ApplicationID = -1;
            
            DateTime ApplicationDate = DateTime.MinValue;
            float Grade10avg = -1;
            float Grade11avg = -1;
            float Grade12avg = -1;
            float Bacavg = -1;
            int MajorID = -1;
            string Grade12School = "";
            int Grade12Specialization = -1;
            DateTime PreDeactivationDate = DateTime.MinValue;
            DateTime DeactivationDate = DateTime.MinValue;
            int status = -1;

            if (clsApplicationData.FindApplicationByPersonID(ref ApplicationID,  personID, ref ApplicationDate, ref Grade10avg, ref Grade11avg, ref Grade12School
                , ref Grade12Specialization, ref Grade12avg, ref Bacavg,
               ref MajorID, ref status, ref PreDeactivationDate, ref DeactivationDate))
            {
                return new clsApplication(ApplicationID, personID, ApplicationDate, Grade10avg, Grade11avg, Grade12School,
                    ConvertGrade12Specialization(Grade12Specialization), Grade12avg, Bacavg, MajorID, ConvertStatus(status)
                    , PreDeactivationDate, DeactivationDate);
            }
            return new clsApplication();
        }
    }
}
