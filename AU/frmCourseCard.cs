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
    public partial class frmCourseCard : Form
    {
        public clsCourse course =new clsCourse();
        public frmCourseCard(clsCourse Course)
        {
            InitializeComponent();
            course = Course;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCourseCard_Load(object sender, EventArgs e)
        {
            ctrlCourseCard1.course = course;
            ctrlCourseCard1.FillInfo();
            if(clsGLobalSettings.CurrentPerson.PersonID!=1)
            {
                guna2Button3.Visible = false;
            }
            else
                guna2Button3.Visible=true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Data."
  , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (clsCourse.DeleteCourse(course.CourseId))
            {
                MessageBox.Show("Course and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }
    }
}
