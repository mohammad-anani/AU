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
    public partial class ctrlCourseCard : UserControl
    {

       public clsCourse course=new clsCourse();
        public ctrlCourseCard()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void FillInfo()
        {
            if (course == new clsCourse())
            {
                MessageBox.Show("Course Not Found");
                return;
            }
            lblcoursename.Text = course.CourseName;
            lbldepartmentname.Text = course.Department.DepartmentName;
            lblcredits.Text = course.CourseCredits.ToString();
            lbldescription.Text = course.CourseDescription;
            if(clsGLobalSettings.CurrentPerson.PersonID==1)
            {
                linkLabel1.Visible = true;
            }
            else
                linkLabel1.Visible=false;
        }
        private void ctrlCourseCard_Load(object sender, EventArgs e)
        {
      
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmAddCourse(course);
            form.ShowDialog();
            FillInfo();
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmDepartmentCard(course.Department);
            frm.ShowDialog();
        }
    }
}
