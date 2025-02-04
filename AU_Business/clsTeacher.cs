using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsTeacher
    {
        public int TeacherID {  get; set; }
        
        public int PersonID { get; set; }

        public clsPerson Person { get; set; }

        public string Specialization { get; set; }

        public enum enMode { Add=1,Update=2}

        public enMode Mode { get; set; }

        public clsTeacher()
        {
            this.TeacherID = -1;
            this.PersonID = -1;
            this.Specialization = "";
            this.Person= new clsPerson(); 
            this.Mode= enMode.Add;

        }

        private clsTeacher(int id, int personID,string spec)
        {
            this.TeacherID = id;
            this.PersonID = personID;
            this.Person=clsPerson.Find(personID);
            this.Specialization = spec;
            this.Mode = enMode.Update;
        }

        private bool AddTeacher()
        {
            this.TeacherID=clsTeacherData.AddTeacher(this.PersonID,this.Specialization);
            return this.TeacherID!=-1;
        }

        private bool UpdateTeacher()
        {
            return clsTeacherData.UpdateTeacher(this.TeacherID,this.Specialization);
        }

        public bool Save()
        {
            if(this.Mode==enMode.Add)
            {
                this.AddTeacher();
                this.Mode=enMode.Update;
                return true;
            }
            else if(this.Mode==enMode.Update)
            {
                return this.UpdateTeacher();
            }
            return false;
        }

        public static DataTable ListTeachers()
        {
            return clsTeacherData.GetTeachersList();
        }

        public static int GetTeachersCount()
        {
            return clsTeacherData.GetTeachersCount();
        }


        public static bool DeleteTeacher(int teacherid)
        {
            return clsTeacherData.DeleteTeacher(teacherid);
        }

        public static clsTeacher FindTeacherByID(int teacherid)
        {
            int personid = -1;
            string spec = "";

            if(clsTeacherData.FindTeacherByID(teacherid,ref personid,ref spec))
            {
                return new clsTeacher(teacherid,personid,spec);
            }
            return new clsTeacher();
        }
        public static clsTeacher FindTeacherByPersonID(int personid)
        {
            int teacherid = -1;
            string spec = "";

            if (clsTeacherData.FindTeacherByPersonID(ref teacherid, personid, ref spec))
            {
                return new clsTeacher(teacherid, personid, spec);
            }
            return new clsTeacher();
        }


    }
}
