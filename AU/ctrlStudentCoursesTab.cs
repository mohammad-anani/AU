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
    public partial class ctrlStudentCoursesTab : UserControl
    {
        public clsStudent Student=new clsStudent();
        public ctrlStudentCoursesTab()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            Student = clsStudent.FindStudentByID(Student.StudentID);
            if (Student.IsGrad)
            {
                lblyear.Text = "Graduated";
                lblcompletedcourses.Visible = false;
                label2.Visible= false;
            }
            else
            {
                lblyear.Text = Student.AcademicYear.ToString();
                lblcompletedcourses.Text = Student.YearPassedCourses.ToString() + "/" + Student.YearRequiredCourses.ToString();
            }
   

            DataTable dtenrolled = clsEnrolledCourse.ListEnrolledCoursesForStudent
                (Student.StudentID);
            if (dtenrolled.Rows.Count > 0)
            {
                dtenrolled= dtenrolled.DefaultView
                .ToTable(false, "EnrolledCourseID", "CourseName", "TeacherName", "Grade");
               
            }

            dgvEnnrolledCourses.DataSource = dtenrolled;

            if (dgvEnnrolledCourses.Rows.Count > 0)
            {
                dgvEnnrolledCourses.Columns[0].HeaderText = "ID";
                dgvEnnrolledCourses.Columns[1].HeaderText = "Course Name";
                dgvEnnrolledCourses.Columns[2].HeaderText = "Teacher Name";
            }
            
            dgvscheduledcourses.DataSource = clsScheduledCourse.ListScheduledCoursesForStudent(Student.StudentID);
            if (dgvscheduledcourses.Rows.Count > 0)
            {

                dgvscheduledcourses.Columns[0].HeaderText = "Course ID";
                dgvscheduledcourses.Columns[1].HeaderText = "Course Name";
                dgvscheduledcourses.Columns[2].HeaderText = "Teacher Name";
                dgvscheduledcourses.Columns[3].HeaderText = "Course Credits";
            }
            
            if(Student.IsGrad)
            {
                if(tabControl1.TabPages.Count>1)
               { tabControl1.TabPages[1].Dispose(); }
            }

        }

        private void ctrlStudentCoursesTab_Load(object sender, EventArgs e)
        {

        }

        private void dgvEnnrolledCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEnnrolledCourses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvEnnrolledCourses.SelectedRows.Count==0)return;

            Form form=new frmEnrollCourse(clsEnrolledCourse.Find(Convert.ToInt32(dgvEnnrolledCourses.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            FillInfo();

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void dgvscheduledcourses_DoubleClick(object sender, EventArgs e)
        {
            if(dgvscheduledcourses.SelectedRows.Count==0)return;

            if (clsEnrolledCourse.IsStudentEnrolledInCourse(Student.StudentID,
               Convert.ToInt32(dgvscheduledcourses.SelectedRows[0].Cells[0].Value)))
            {
                MessageBox.Show("You Have Already Enrolled in This Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form form = new frmEnrollCourse(clsScheduledCourse.Find(Convert.ToInt32(dgvscheduledcourses.SelectedRows[0].Cells[0].Value)),Student.StudentID);
            form.ShowDialog();
            FillInfo();
        }

        private void dgvscheduledcourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
