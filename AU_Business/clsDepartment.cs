using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsDepartment
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public float PricePerCredit { get; set; }

        public enum enMode { Add,Update}

        public enMode Mode { get; set; }

        public clsDepartment()
        {
            this.DepartmentID = -1;
            this.DepartmentName = "";
            this.PricePerCredit = -1;
            this.Mode=enMode.Add;
        }

        private clsDepartment(int departmentID, string departmentName, float pricePerCredit)
        {
           this.DepartmentID = departmentID;
           this.DepartmentName = departmentName;
           this.PricePerCredit = pricePerCredit;
            this.Mode=enMode.Update;
        }

        public static DataTable ListDepartments()
        {
            return clsDepartmentData.GetDepartmentsList();
        }

        public static int GetDepartmentsCount()
        {
            return clsDepartmentData.GetDepartmentsCount();

        }
        public static clsDepartment Find(int departmentID)
        {
            string name = "";
            float pricepercredit = -1;

            if(clsDepartmentData.FindDepartmentByID(departmentID,ref name,ref pricepercredit))
                {
                return new clsDepartment(departmentID,name,pricepercredit);
            }
            return new clsDepartment();
        }


        public static clsDepartment Find(string departmentname)
        {
            int id=-1;
            float pricepercredit = -1;

            if (clsDepartmentData.FindDepartmentByName(ref id, departmentname, ref pricepercredit))
            {
                return new clsDepartment(id, departmentname, pricepercredit);
            }
            return new clsDepartment();
        }

        public static bool DeleteDepartment(int departmentID)
        {
            return clsDepartmentData.DeleteDepartment(departmentID);
        }

        private bool _AddDepartment()
        {
            this.DepartmentID=clsDepartmentData.AddDepartment(this.DepartmentName,this.PricePerCredit);

            return this.DepartmentID != -1;
        }

        private bool _UpdateDepartment()
        {
            return clsDepartmentData.UpdateDepartment(this.DepartmentID,this.DepartmentName,this.PricePerCredit);
        }

        public bool Save()
        {
            if (this.Mode == enMode.Add)
            {
                if (this._AddDepartment())
                    return true;
            }
            else if (this.Mode == enMode.Update)
            {
                if (this._UpdateDepartment())
                    return true;
            }
            return false;
        }

        
    }
}
