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
    public partial class frmListMajorCourses : Form
    {
        public clsMajor Major = new clsMajor();
        public frmListMajorCourses(clsMajor major)
        {
            InitializeComponent();
            Major = major;
        }


        void FillInfo()
        {
            lblmajorname.Text = Major.MajorName;
            DataTable dtCourses = clsMajorCourse.ListMajorCourses();
            dtCourses.DefaultView.RowFilter = "majorname = '" + Major.MajorName + "'";
            dtCourses = dtCourses.DefaultView.ToTable(false, "CourseName", "EnrollmentYear");
            dtCourses.DefaultView.Sort = "EnrollmentYear asc";
            dataGridView1.DataSource = dtCourses;
            if (clsGLobalSettings.CurrentPerson.PersonID == 1)
            {
                button1.Visible = true;
            }
            else
                button1.Visible = false;
        }
        private void frmListMajorCourses_Load(object sender, EventArgs e)
        {
            if (clsGLobalSettings.CurrentPerson.PersonID != 1)
            {
                label4.Visible = false;
            }
            FillInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddMajorCourse(Major);
            form.ShowDialog();
            FillInfo();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (clsGLobalSettings.CurrentPerson.PersonID != 1) { return; }


            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (clsMajorCourse.RemoveMajorCourse(clsMajorCourse.FindByCourse(clsCourse.Find(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()).CourseId).MajorCourseID))
            {
                MessageBox.Show("Course Successfully Removed From Major", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0) return;

            Form form = new frmCourseCard(clsCourse.Find(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }
    }
    }
