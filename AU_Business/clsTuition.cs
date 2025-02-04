using AU_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsTuitionFees
    {
        public int TuitionFeesID { get; set; }

        public int StudentID { get; set; }

        public clsStudent Student { get; set; }

        public double YearlyPaid { get; set; }

        public double RemainingPrice {  get; set; }

        private clsTuitionFees(int TuitionFeesID, int studentID, double yearlyPaid)
        {
            this.TuitionFeesID = TuitionFeesID;
            this.StudentID = studentID;
            this.Student =clsStudent.FindStudentByID(studentID);
            this.YearlyPaid = yearlyPaid;
            this.RemainingPrice = this.Student.YearPrice*((double)1-(double)this.Student.Scholarship/(double)100)-this.YearlyPaid;
        }

        public clsTuitionFees()
        {
            this.TuitionFeesID = -1;
            this.StudentID = -1;
            this.Student =new clsStudent();
            this.YearlyPaid = -1;
            this.RemainingPrice = -1;
        }

        public static bool AddTuitions(int studentid)
        {
            return clsTuitionFeesData.AddTuitions(studentid)!=-1;
        }

        public bool UpdateTuitions()
        {
            return clsTuitionFeesData.UpdateTuitions(this.StudentID, this.YearlyPaid);
        }

        public static clsTuitionFees Find(int studentid)
        {
            double paid = -1;
            int TuitionFeesid = -1;

            if(clsTuitionFeesData.FindByStudentID(studentid,ref paid,ref TuitionFeesid))
            {
                return new clsTuitionFees(TuitionFeesid, studentid, paid);
            }
            return new clsTuitionFees();
        }

    }
}
