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
    public partial class frmStudentScreen : Form
    {
        public frmStudentScreen()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 9)
            {
                this.Close();
            }
        }

        private void frmStudentScreen_Load(object sender, EventArgs e)
        {
            if (clsGLobalSettings.CurrentPerson.ImagePath != "")
            {
                pbimage.ImageLocation = clsGLobalSettings.CurrentPerson.ImagePath;
            }
            lblusername.Text = clsGLobalSettings.CurrentPerson.Username;
            ctrlPersonCard1.person = clsGLobalSettings.CurrentPerson;
            ctrlPersonCard1.fillinfo();
            ctrlStudentCard1.Student = clsGLobalSettings.CurrentStudent;
            ctrlStudentCard1.FillInfo();
            ctrlStudentCoursesTab1.Student = clsGLobalSettings.CurrentStudent;
            ctrlStudentCoursesTab1.FillInfo();
            ctrlEmailsList1.Person = clsGLobalSettings.CurrentPerson;
            ctrlStudentSessions1.Student = clsGLobalSettings.CurrentStudent;
            ctrlStudentSessions1.FillInfo();
            ctrlNews1.FillInfo();
            dgvexams.DataSource=clsExam.ListExamsForStudents(clsGLobalSettings.CurrentStudent.StudentID);
            if(dgvexams.Rows.Count > 0 )
            {
                dgvexams.Columns[0].HeaderText = "ID";
                dgvexams.Columns[1].HeaderText = "Course Name";
                dgvexams.Columns[3].HeaderText = "Number of Questions";
            }
            guna2TabControl1.SelectedIndex = 3;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson(clsGLobalSettings.CurrentPerson);
            form.ShowDialog();
            ctrlPersonCard1.fillinfo();
            ctrlStudentCard1.Student = clsStudent.FindStudentByPersonID(clsGLobalSettings.CurrentPerson.PersonID);
            ctrlStudentCard1.FillInfo();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void ctrlStudentSessions1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void ctrlStudentSessions1_Load_1(object sender, EventArgs e)
        {

        }

        private void ctrlNews1_Load(object sender, EventArgs e)
        {
         
        }

        private void ctrlEmailsList1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvexams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvexams.SelectedRows.Count == 0) return;


            if (clsEnrolledCourse.StudentHasGradeForCourse(clsGLobalSettings.CurrentStudent.StudentID, Convert.ToInt32(dgvexams.SelectedRows[0].Cells[0].Value)))
            {
                MessageBox.Show("Student Has Grade For This Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frm=new frmEnterCode(clsScheduledCourse.Find(Convert.ToInt32(dgvexams.SelectedRows[0].Cells[0].Value)));
            frm.ShowDialog();
            ctrlStudentCoursesTab1.FillInfo();
        }

        private void dgvexams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
