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
    public partial class frmListScheduledCourses : Form
    {
        string FilterByName = "";

        DataTable dtcourses=clsScheduledCourse.ListScheduledCoursesForAdministrator();

        public frmListScheduledCourses()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            {
                dtcourses.DefaultView.RowFilter = "CourseName like '" + FilterByName + "%' or" +
                    " TeacherName like '" + FilterByName + "%'";
            }
            else
                dtcourses.DefaultView.RowFilter = "";

            dgvmajors.DataSource = dtcourses;
            lbltotal.Text = dgvmajors.Rows.Count.ToString();
        }
        private void frmListScheduledCourses_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void dgvmajors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvmajors.SelectedRows.Count==0) return;

            Form form = new frmScheduledCourseCard(clsScheduledCourse.Find(Convert.ToInt32(dgvmajors.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtcourses = clsScheduledCourse.ListScheduledCoursesForAdministrator();
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName= textBox1.Text;
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddScheduledCourse();
            form.ShowDialog();
            dtcourses = clsScheduledCourse.ListScheduledCoursesForAdministrator();
            RefreshList();
        }

        private void dgvmajors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
