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
    public partial class ctrlTeacherCourses : UserControl
    {
        public clsTeacher Teacher=new clsTeacher();
        public ctrlTeacherCourses()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            DataTable dtcourses = clsScheduledCourse.ListScheduledCoursesForteacher(Teacher.TeacherID);
            if(dtcourses.Rows.Count > 0)
            {
                dgvscheduledcourses.DataSource = dtcourses.DefaultView.ToTable
                    (false,"ScheduledCourseID","CourseName");
                dgvscheduledcourses.Columns[0].HeaderText = "Course ID";
                dgvscheduledcourses.Columns[1].HeaderText = "Course Name";
            }
            dgvscheduledcourses.DataSource = dtcourses;
        }

        private void ctrlTeacherCourses_Load(object sender, EventArgs e)
        {
        }

        private void dgvscheduledcourses_DoubleClick(object sender, EventArgs e)
        {
            if (dgvscheduledcourses.SelectedRows.Count == 0) return;

            frmTeacherCourseInfo form = new frmTeacherCourseInfo(Convert.ToInt32(dgvscheduledcourses.SelectedRows[0].Cells[0].Value));
            form.Completed += Form_Completed;
            form.ShowDialog();
            FillInfo();
        }

        public event Action OnCompleted;
        protected virtual void Completed()
        {
            Action action = OnCompleted;
            if(action != null)
            {
                OnCompleted();
            }
        }

        private void Form_Completed()
        {
           if(OnCompleted != null) OnCompleted();
        }

        private void dgvscheduledcourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
