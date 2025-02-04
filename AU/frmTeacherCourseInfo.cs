using AU_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace AU
{
    public partial class frmTeacherCourseInfo : Form
    {
        int ScheduledCourseID = -1;
        public frmTeacherCourseInfo(int scheduledcourseid)
        {
            InitializeComponent();
            ScheduledCourseID=scheduledcourseid;
        }


        public delegate void OnCompleted();
        public event OnCompleted Completed;


        private void frmTeacherCourseInfo_Load(object sender, EventArgs e)
        {
            dgvstudents.DataSource = clsEnrolledCourse.ListEnrolledCoursesForTeacher(ScheduledCourseID);
            if (dgvstudents.Rows.Count > 0)
            {
                dgvstudents.Columns[0].HeaderText = "ID";
                dgvstudents.Columns[1].HeaderText = "Student Full Name";
                dgvstudents.Columns[0].ReadOnly = true;
                dgvstudents.Columns[1].ReadOnly = true;
                dgvstudents.Columns[2].ReadOnly = false;
            }
        }

        int rowsaffected = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Save?","Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                { return; }

           

            foreach(DataGridViewRow row in dgvstudents.Rows)
            {
                if (row.Cells[2].Value != DBNull.Value)
                {
                    if (!clsEnrolledCourse.SetGrade(Convert.ToInt32(row.Cells[0].Value), float.Parse(row.Cells[2].Value.ToString())))
                        return;
                    else
                        rowsaffected++;
                }
            }
            MessageBox.Show("Grades Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (rowsaffected == dgvstudents.RowCount)
            {
                if (MessageBox.Show("ALl Grades Set.Complete Course?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { this.Close(); return; }
                clsScheduledCourse.CompleteScheduledCourse(ScheduledCourseID);
                MessageBox.Show("Course Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Completed?.Invoke();
            }

        }

        
    }
}
