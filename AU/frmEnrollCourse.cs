using AU_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AU
{
    public partial class frmEnrollCourse : Form
    {

        public clsScheduledCourse ScheduledCourse =new clsScheduledCourse();

        public clsEnrolledCourse EnrolledCourse =new clsEnrolledCourse();

        int StudentID { get; set; }
        public frmEnrollCourse(clsScheduledCourse scheduledcourse,int studentid)
        {
            
            InitializeComponent();
            ctrlScheduledCourseCard1.scheduledcourse = ScheduledCourse;
            ctrlScheduledCourseCard1.FillInfo();
            guna2Button2.Visible = false;
            string Activated = File.ReadAllText("AU_Settings.txt");
            if (Activated[1] == '1')
            {
                guna2Button1.Visible = true;
                guna2Button2.Visible = true;

            }
            else
            {
                guna2Button1.Visible = false;
                guna2Button2.Visible = false;
            }
            ScheduledCourse = scheduledcourse;

            guna2Button2.Visible = false;

            StudentID = studentid;
        }

        public frmEnrollCourse(clsEnrolledCourse EnrolledCourse)
        {
            InitializeComponent();
            this.EnrolledCourse = EnrolledCourse;
            ctrlScheduledCourseCard1.scheduledcourse = EnrolledCourse.ScheduledCourse;
            ctrlScheduledCourseCard1.FillInfo();
            guna2Button1.Visible = false;
            string Activated = File.ReadAllText("AU_Settings.txt");
            if (Activated[1] == '1')
            {
                guna2Button1.Visible = true;
                guna2Button2.Visible = true;

            }
            else
            {
                guna2Button1.Visible = false;
                guna2Button2.Visible = false;
                return;
            }
            guna2Button1.Visible = false;
            guna2Button2.Visible = EnrolledCourse.Grade == -1 ? true:false;
        }

        private void frmEnrollCourse_Load(object sender, EventArgs e)
        {
         
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {  
            if (MessageBox.Show("Confirm Drop?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            if ( clsEnrolledCourse.DropCourse(EnrolledCourse.EnrolledCourseID))
            {
                MessageBox.Show("Course Dropped Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Enrollment?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            EnrolledCourse.ScheduledCourseID = ScheduledCourse.ScheduledCourseID;
            EnrolledCourse.StudentID = StudentID;
                if (EnrolledCourse.EnrollCourse())
                {
                    MessageBox.Show("Course Enrolled Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            
        }
    }
}
