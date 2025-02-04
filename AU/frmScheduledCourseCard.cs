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
    public partial class frmScheduledCourseCard : Form
    {
        clsScheduledCourse course=new clsScheduledCourse();
        public frmScheduledCourseCard(clsScheduledCourse course)
        {
            InitializeComponent();
            this.course = course;
            if(clsGLobalSettings.CurrentPerson.PersonID==1)
            {
                guna2Button2.Visible = true;
            }
            else
                guna2Button2.Visible=false;
        }

        private void frmScheduledCourseCard_Load(object sender, EventArgs e)
        {
            ctrlScheduledCourseCard1.scheduledcourse = course;
            ctrlScheduledCourseCard1.FillInfo();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Sessions."
               , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (clsScheduledCourse.RemoveScheduledCourse(course.ScheduledCourseID))
            {
                MessageBox.Show("Scheduled Course and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }
    }
}
