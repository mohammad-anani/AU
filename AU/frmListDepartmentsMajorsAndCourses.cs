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
    public partial class frmListDepartmentsMajorsAndCourses : Form
    {

        clsDepartment Department=new clsDepartment();
        public frmListDepartmentsMajorsAndCourses(clsDepartment Department)
        {
            InitializeComponent();
            this.Department = Department;
        }

        void FillInfo()
        {
            lbldep.Text = Department.DepartmentName;

            DataTable dtCourses = clsCourse.ListCourses();
            dtCourses.DefaultView.RowFilter = "DepartmentID ='" + Department.DepartmentID + "'";
            dgvcourses.DataSource = dtCourses.DefaultView.ToTable(false, "CourseID", "CourseName");

            DataTable dtMajors = clsMajor.ListMajors();
            dtMajors.DefaultView.RowFilter = "DepartmentName='" + Department.DepartmentName + "'";
            dgvmajors.DataSource = dtMajors.DefaultView.ToTable(false, "MajorID", "MajorName");
        }

        private void frmListDepartmentsMajorsAndCourses_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void dgvmajors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvmajors.SelectedRows.Count == 0) return;

            Form frm = new frmMajorCardForAdministrator(clsMajor.Find(Convert.ToInt32(dgvmajors.SelectedRows[0].Cells[0].Value)));
            frm.ShowDialog();
            FillInfo();
        }

        private void dgvcourses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvcourses.SelectedRows.Count == 0) return;

            Form frm = new frmCourseCard(clsCourse.Find(Convert.ToInt32(dgvcourses.SelectedRows[0].Cells[0].Value)));
            frm.ShowDialog();
            FillInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddDepartment(Department);
            form.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("This Deletion Will Delete Related Majors and Courses and EVERYTHING Related To Them"
                , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.No)
            return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            return;

            if(clsDepartment.DeleteDepartment(Department.DepartmentID))
            {
                MessageBox.Show("Department and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }
    }
}
