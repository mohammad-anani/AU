using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsEmail
    {
        public int EmailID { get; set; }

        public int FromPersonID { get; set; }

        public clsPerson FromPerson { get; set; }

        public int ToPersonID { get; set; }

        public clsPerson ToPerson { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsOpen { get; set; }

        public enum enMode { Add,Update}

        public enMode Mode { get; set; }

        public clsEmail()
        {
            this.EmailID = -1;
            this.FromPersonID = -1;
            this.ToPersonID = -1;
            this.Title = "";
            this.Body = "";
            this.IsOpen = false;
            this.FromPerson=new clsPerson();
            this.ToPerson=new clsPerson();
            this.Mode=enMode.Add;
        }

        private clsEmail(int  emailID,int frompersonid,int topersonid,string title,string body,bool isopen)
        {
            this.EmailID = emailID;
            this.FromPersonID = frompersonid;
            this.ToPersonID = topersonid;
            this.Title = title;
            this.Body = body;
            this.IsOpen = isopen;
            FromPerson=clsPerson.Find(frompersonid);
            ToPerson=clsPerson.Find(topersonid);
            this.Mode = enMode.Update;

        }

        public static DataTable ListSentEmails(int personid)
        {
            return clsEmailData.GetSentEmailsList(personid);
        }

        public static DataTable ListReceivedEmails(int personid)
        {
            return clsEmailData.GetReceivedEmailsList(personid);
        }

        private bool _SendEmail()
        {
            this.EmailID=clsEmailData.SendEmail(this.FromPersonID,this.ToPersonID,this.Title,this.Body);

            return this.EmailID != -1;
        }

        private bool _UpdateEmail()
        {
            return clsEmailData.UpdateEmail(this.EmailID, this.Title, this.Body);
        }

        public bool Save()
        {
            if(this.Mode == enMode.Add)
            {
                if(this._SendEmail())
                {
                    this.Mode= enMode.Update;
                    return true;
                }   
            }
            else if (this.Mode == enMode.Update)
            {
                return this._UpdateEmail();
            }
            return false;
        }

        public static clsEmail Find(int emailid)
        {
            int from = -1;
            int to = -1;
            string title = "";
            string body = "";
            bool isopen=false;

            if(clsEmailData.FindEmailByID(emailid,ref from,ref to,ref title,ref body,ref isopen))
            {
                return new clsEmail(emailid,from,to,title,body,isopen);
            }
            return new clsEmail();
        }

        public static bool DeleteEmail(int emailid)
        {
            return clsEmailData.DeleteEmail(emailid);
        }


        public bool OpenEmail()
        {
            return clsEmailData.OpenEmail(this.EmailID);
        }


        public static bool IsPersonHasNewEmails(int personid)
        {
            foreach(DataRow row in clsEmail.ListReceivedEmails(personid).Rows)
            {
                if (!(bool)row["IsOpen"])
                {
                    return true;
                }
                
            }
            return false;
        }

        public static bool SendEmailFromAdministrator(int topersonid,string title,string body)
        {
            return clsEmailData.SendEmail(1, topersonid,title,body)!=-1;
        }
    }
}
