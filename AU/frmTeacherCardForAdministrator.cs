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
    public partial class frmTeacherCardForAdministrator : Form
    {
        clsTeacher Teacher=new clsTeacher();
        public frmTeacherCardForAdministrator(clsTeacher Teacher)
        {
            InitializeComponent();
            this.Teacher = Teacher;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form=new frmTeacherCourses(Teacher);
            form.ShowDialog();
        }

        private void frmTeacherCardForAdministrator_Load(object sender, EventArgs e)
        {
            ctrlTeacherCard1.Teacher = Teacher;
            ctrlTeacherCard1.FillInfo();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Scheduled Courses and Sessions."
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (clsTeacher.DeleteTeacher(Teacher.TeacherID))
            {
                MessageBox.Show("Teacher and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }
    }
}
