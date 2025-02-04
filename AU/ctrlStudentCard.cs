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
    public partial class ctrlStudentCard : UserControl
    {
        public clsStudent Student =new clsStudent();
        public ctrlStudentCard()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if(Student.StudentID==-1)
            {
                return;
            }
            lblfullname.Text = Student.Person.FullName();
            lblmajor.Text = Student.Major.MajorName;
            if(!Student.IsGrad)
{ lblyear.Text = Student.AcademicYear.ToString(); }
            else
            { lblyear.Text = "Graduated"; }

            if(Student.CumulativeGPA!=-1)
            lblgpa.Text=Student.CumulativeGPA.ToString();
            if(Student.Person.ImagePath!="")
            pictureBox1.ImageLocation = Student.Person.ImagePath;
            
            if(Student.Person.PersonID==clsGLobalSettings.CurrentPerson.PersonID)
            {
                llpersoninfo.Visible = false;
            }

            if(Student.Scholarship!=-1)
            {
                lblscholarship.Text=Student.Scholarship.ToString();
            }
            
        }

        private void ctrlStudentCard_Load(object sender, EventArgs e)
        {

        }

        private void llpersoninfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmPersonCard(Student.Person);
            form.ShowDialog();
            FillInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form=new frmMajorCard(Student.Major);
            form.ShowDialog();
            FillInfo();
        }
    }
}
