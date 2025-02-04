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
    public partial class ctrlScheduledCourseCard : UserControl
    {
        public clsScheduledCourse scheduledcourse=new clsScheduledCourse();
        public ctrlScheduledCourseCard()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if (scheduledcourse.ScheduledCourseID == -1)
            {
                return;
            }

            lblcourse.Text = scheduledcourse.Course.CourseName;
            lblteacher.Text = scheduledcourse.Teacher.Person.FullName();
        }

        private void llteacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmTeacherCard(scheduledcourse.Teacher);
            form.ShowDialog();
        }

        private void llcourse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form=new frmCourseCard(scheduledcourse.Course);
            form.ShowDialog();
        }
    }
}
