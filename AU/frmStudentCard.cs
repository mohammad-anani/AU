using AU_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AU
{
    public partial class frmStudentCard : Form
    {
        clsStudent Student =new clsStudent();
        public frmStudentCard(clsStudent Student)
        {
            InitializeComponent();
            this.Student = Student;
        }

        void RefreshInfo()
        {
            Student = clsStudent.FindStudentByID(Student.StudentID);
            ctrlStudentCard1.Student = Student;
            ctrlStudentCard1.FillInfo();
            lblcompletedcourses.Visible = (!Student.IsGrad);
            label1.Visible=(!Student.IsGrad);
            lblcompletedcourses.Text = Student.YearPassedCourses.ToString() + "/" + Student.YearRequiredCourses.ToString();
            btnadvance.Enabled = (Student.YearPassedCourses >= 2*(Student.YearRequiredCourses)/3 
                && Student.YearPassedCourses != 0);
            btnadvance.Visible = (Student.AcademicYear < Student.Major.CompletionYears);
            btngraduate.Enabled = (Student.TotalRequiredCourses == Student.TotalPassedCourses && !Student.IsGrad);
            btngraduate.Visible = (Student.TotalRequiredCourses == Student.TotalPassedCourses || Student.IsGrad);

            
        }
           
        private void frmStudentCard_Load(object sender, EventArgs e)
        {
            RefreshInfo();


        }

        int CalculateScholarship()
        {
            if(Student.CumulativeGPA<3.2)
            {
                return 0;
            }
            
            if(Student.CumulativeGPA>=3.8)
            {
                return 100;
            }

            return Convert.ToInt32((Student.CumulativeGPA - 3.2) * 100 / 0.8);
        }

        private void btnadvance_Click(object sender, EventArgs e)
        {
            if(clsTuitionFees.Find(Student.StudentID).RemainingPrice>0)
            {
                MessageBox.Show("Student Hasn't Paid All His Year Tuition Fees.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Confrim Advance Year?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                return;

            Student.Scholarship= CalculateScholarship();
            if(Student.AdvanceAcademicYear())
            {
                MessageBox.Show("Student Advanced a Year.");
                clsTuitionFees fees = clsTuitionFees.Find(Student.StudentID);
                fees.YearlyPaid = 0;
                fees.UpdateTuitions();
                clsEmail.SendEmailFromAdministrator(Student.PersonID, "New Year,New Challenges!", "Dear Student,You Successfully advanced to the next year " +
                         "after a hard work!" + (Student.Scholarship > 0 ? "Due to your excellence,you are granted a " + Student.Scholarship + "% scholarship for the new year" : "") +
                         ".We hope for you the best time at AU.\nBest regards,AU administration.");
                RefreshInfo();
                

            }
        }

        private void btnsessions_Click(object sender, EventArgs e)
        {
            Form form = new frmStudentSessions(Student);
            form.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form =new frmListStudentEnrolledCourses(Student);
            form.ShowDialog();
            RefreshInfo();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Data to it."
       , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (clsStudent.DeleteStudent(Student.StudentID))
            {
                MessageBox.Show("Student and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form frm = new frmStudentTuitionFees(clsTuitionFees.Find(Student.StudentID));
            frm.ShowDialog();
        }

        private void btngraduate_Click(object sender, EventArgs e)
        {
            if (clsTuitionFees.Find(Student.StudentID).RemainingPrice > 0)
            {
                MessageBox.Show("Student Hasn't Paid All His Year Tuition Fees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confrim Graduate?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsGraduate Grad=new clsGraduate();
            Grad.StudentID=Student.StudentID;
            Grad.GraduationDate=DateTime.Now;
            if(Grad.AddGraduate())
            {
                Student.NullScholarship();
                clsEmail.SendEmailFromAdministrator(Student.PersonID, "The Tassel Was Worth The Hassel!", "Dear " + Student.Person.FirsrtName + ",Congratulations on Graduation.We hope for you a shiny future!");
                MessageBox.Show("Student Successfully Graduated.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsTuitionFees fees = clsTuitionFees.Find(Student.StudentID);
                fees.YearlyPaid = 0;
                fees.UpdateTuitions();
                btngraduate.Visible = false;
               
            }
        }
    }
}
