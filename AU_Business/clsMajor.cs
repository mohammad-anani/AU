using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsMajor
    {
        public int MajorID { get; set; }

        public string MajorName { get; set; }

        public int DepartmentID { get; set; }

        public clsDepartment Department { get; set; }
        public int CompletionYears { get; set; }

        public int TotalNumberOfCourses { get; set; }

        public int TotalCredits { get; set; }

        public float TotalPrice { get; set; }

        public enum enMode { Add,Update}

        public enMode Mode { get; set; }

        public clsMajor()
        {
            this.MajorID = -1;
            this.MajorName = "";
            this.DepartmentID = -1;
            this.Department = new clsDepartment();
            this.CompletionYears = -1;
            this.TotalPrice = -1;
            this.TotalCredits = -1;
            this.TotalNumberOfCourses = -1;
            this.Mode=enMode.Add;
        }

        private clsMajor(int majorID, string majorName, int departmentID, int completionYears, int totalNumberOfCourses, int totalCredits, float totalPrice)
        {
            this.MajorID = majorID;
            this.MajorName = majorName;
            this.DepartmentID = departmentID;
            this.Department = clsDepartment.Find(departmentID);
            this.CompletionYears = completionYears;
            this.TotalNumberOfCourses = totalNumberOfCourses;
            this.TotalCredits = totalCredits;
            this.TotalPrice = totalPrice;
            this.Mode = enMode.Update;
        }

        public static DataTable ListMajors()
        {
            return clsMajorData.GetMajorsList();
        }

        public static int GetMajorsCount()
        {
            return clsMajorData.GetMajorsCount(); 
        }

        private bool _AddMajor()
        {
            this.MajorID = clsMajorData.AddMajor(this.MajorName, this.CompletionYears, this.DepartmentID);

            return this.MajorID != -1;
        }

        private bool _UpdateMajor()
        {
            return clsMajorData.UpdateMajor(this.MajorID,this.MajorName,this.CompletionYears,this.DepartmentID);
        }

        public bool Save()
        {
            if (this.Mode == enMode.Add)
            {
                if(this._AddMajor())
                {
                    return true;
                }

            }
            else if (this.Mode == enMode.Update)
            {
                if(this._UpdateMajor())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteMajor(int  majorID)
        {
            return clsMajorData.DeleteMajor(majorID);
        }

        public static clsMajor Find(int majorID)
        {
            
            string MajorName = "";
            string DepartmentName = "";
            int CompletionYears = -1;
            float TotalPrice = -1;
            int TotalCredits = -1;
            int TotalNumberOfCourses = -1;
           
            if(clsMajorData.FindMajorByID(majorID,ref MajorName,ref CompletionYears,ref DepartmentName,ref TotalNumberOfCourses,ref TotalCredits,ref TotalPrice))
            {
                return new clsMajor(majorID,MajorName,clsDepartment.Find(DepartmentName).DepartmentID,CompletionYears,TotalNumberOfCourses,TotalCredits,TotalPrice);
            }
            return new clsMajor();

        }

        public static clsMajor Find(string name)
        {

            int majorid = -1;
            string Departmentname = "";
            int CompletionYears = -1;
            float TotalPrice = -1;
            int TotalCredits = -1;
            int TotalNumberOfCourses = -1;

            if (clsMajorData.FindMajorByName(ref majorid,  name, ref CompletionYears, ref Departmentname, ref TotalNumberOfCourses, ref TotalCredits, ref TotalPrice))
            {
                return new clsMajor(majorid, name, clsDepartment.Find(Departmentname).DepartmentID, CompletionYears, TotalNumberOfCourses, TotalCredits, TotalPrice);
            }
            return new clsMajor();

        }


    }
}
