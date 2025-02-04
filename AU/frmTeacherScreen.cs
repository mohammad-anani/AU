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
    public partial class frmTeacherScreen : Form
    {
        public frmTeacherScreen()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeacherScreen_Load(object sender, EventArgs e)
        {
            if (clsGLobalSettings.CurrentPerson.ImagePath != "")
            {
                pbimage.ImageLocation = clsGLobalSettings.CurrentPerson.ImagePath;
            }
            lblusername.Text = clsGLobalSettings.CurrentPerson.Username;
            ctrlPersonCard1.person = clsGLobalSettings.CurrentPerson;
            ctrlPersonCard1.fillinfo();
            ctrlTeacherCard1.Teacher=clsGLobalSettings.CurrentTeacher;
            ctrlTeacherCard1.FillInfo();
            ctrlTeacherCourses1.Teacher = clsGLobalSettings.CurrentTeacher;
            ctrlTeacherCourses1.FillInfo();
            ctrlEmailsList1.Person = clsGLobalSettings.CurrentPerson;
            ctrlTeacherSessions1.TeacherID = clsGLobalSettings.CurrentTeacher.TeacherID;
            ctrlTeacherSessions1.FillInfo();
            ctrlNews1.FillInfo();
            dgvexams.DataSource = clsExam.ListExamsForTeachers(clsGLobalSettings.CurrentTeacher.TeacherID);
            guna2TabControl1.SelectedIndex = 3;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson(clsGLobalSettings.CurrentPerson);
            form.ShowDialog();
            ctrlPersonCard1.fillinfo();
            ctrlTeacherCard1.Teacher = clsTeacher.FindTeacherByPersonID(clsGLobalSettings.CurrentPerson.PersonID);
            ctrlTeacherCard1.FillInfo();
        }

        private void ctrlTeacherSessions1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(guna2TabControl1.SelectedIndex==9)
            {
                this.Close();

            }
        }

        private void ctrlEmailsList1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form form =new frmAddTeacher(clsGLobalSettings.CurrentTeacher);
            form.ShowDialog();
            ctrlTeacherCard1.FillInfo();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void ctrlTeacherCourses1_OnCompleted()
        {
            ctrlTeacherSessions1.TeacherID = clsGLobalSettings.CurrentTeacher.TeacherID;
            ctrlTeacherSessions1.FillInfo();
        }

        private void ctrlTeacherCourses1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlNews1_Load(object sender, EventArgs e)
        {
           
        }

        private void ctrlNews2_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddExam();
            frm.ShowDialog();
            dgvexams.DataSource = clsExam.ListExamsForTeachers(clsGLobalSettings.CurrentTeacher.TeacherID);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvexams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvexams_DoubleClick(object sender, EventArgs e)
        {
            if(dgvexams.SelectedRows.Count == 0)return;

            if (MessageBox.Show("Are You Sure You Want To Complete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsExam Exam = clsExam.Find(dgvexams.SelectedRows[0].Cells[0].Value.ToString());
            Exam.IsTaken= true;
            if(Exam.UpdateExam())
            {
                MessageBox.Show("Exam Successfully Completed.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dgvexams.DataSource = clsExam.ListExamsForTeachers(clsGLobalSettings.CurrentTeacher.TeacherID);
            }
        }
    }
}
