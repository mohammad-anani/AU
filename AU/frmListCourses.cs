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
    public partial class frmListCourses : Form
    {
        string FilterByName = "";

        DataTable dtcourses = clsCourse.ListCourses().DefaultView.ToTable(false,"CourseID","CourseName");

        public frmListCourses()
        {
            InitializeComponent();
        }


        void RefreshList()
        {
            if (FilterByName != "")
            { dtcourses.DefaultView.RowFilter = "CourseName like '" + FilterByName + "%'"; }
            else
                dtcourses.DefaultView.RowFilter = "";
            dgvcourses.DataSource = dtcourses;
            lbltotal.Text = dgvcourses.Rows.Count.ToString();
        }

        private void frmListCourses_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName = textBox1.Text;
            RefreshList();
        }

        private void dgvcourses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvcourses.SelectedRows.Count == 0) return;
            Form form = new frmCourseCard(clsCourse.Find(Convert.ToInt32(dgvcourses.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtcourses = clsCourse.ListCourses().DefaultView.ToTable(false, "CourseID", "CourseName");
            RefreshList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddCourse();
            form.ShowDialog();
            dtcourses = clsCourse.ListCourses().DefaultView.ToTable(false, "CourseID", "CourseName");
            RefreshList();
        }
    }
}
